using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Es.InkPainter;
using System;

public class PaintAroundPlayer : MonoBehaviour
{       /// <summary>
        /// Types of methods used to paint.
        /// </summary>
    [System.Serializable]
    private enum UseMethodType
    {
        RaycastHitInfo,
        WorldPoint,
        NearestSurfacePoint,
        DirectUV,
    }
    [SerializeField]
    Vector3 offSet;
    [SerializeField]
    public Brush brush;
    public LayerMask layerToPropagate;
    [SerializeField]
    private UseMethodType useMethodType = UseMethodType.WorldPoint;
    [SerializeField]
    bool erase;

    private Camera cam;
    public float randomWeight = 10;

    private Vector3 getPointOfContact(Collider2D otherCol)
    {
        RaycastHit2D _hit = Physics2D.Raycast(transform.position, transform.position - otherCol.transform.position);
        Vector3 _point = _hit.point + UnityEngine.Random.insideUnitCircle * randomWeight;

        return _point;
    }

    private void CheckForNeighBours(Vector3 worldPos, Collider2D origin)
    {

        Debug.Log("Tried to paint neighbour0");
        var lastLayer = origin.gameObject.layer;
        origin.gameObject.layer = Physics2D.IgnoreRaycastLayer;

        for (int i = -1; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector3.up * i + Vector3.right * j, 1, layerToPropagate);
                if (hit.collider != null)
                {
                    var paintObject = hit.collider.GetComponent<InkCanvas>();
                    if(paintObject != null)
                    {
                        Debug.Log("Tried to paint neighbour1");
                        paintObject.Paint(brush, hit.point, null, cam);
                    }

                }
            
            }
        }
        origin.gameObject.layer = lastLayer;
           
    }

    #region UnityAPI

    private void Start()
    {
        cam = Camera.main;
    }

    private void OnTriggerStay2D(Collider2D other)
    {

            Debug.Log("OntriggerStay worked");
            bool success = true;
            var stuff = other.transform.GetComponent<InkCanvas>();
            var data = other.transform.GetComponent<PaintableObjectData>();
            var pointOfContact = getPointOfContact(other);
            if (stuff != null && data.canBePainted)
            {
                CheckForNeighBours(pointOfContact, other);
                switch (useMethodType)
                {
                    case UseMethodType.RaycastHitInfo:
                        //success = erase ? paintObject.Erase(brush, hitInfo) : paintObject.Paint(brush, hitInfo);
                        break;

                    case UseMethodType.WorldPoint:
                        brush.RotateAngle += 41;
                        if (brush.RotateAngle > 360)
                            brush.RotateAngle = brush.RotateAngle - 360;
                        success = erase ? stuff.Erase(brush, pointOfContact) : stuff.Paint(brush, pointOfContact, null, cam);
                        break;

                    case UseMethodType.NearestSurfacePoint:
                        //success = erase ? paintObject.EraseNearestTriangleSurface(brush, hitInfo.point) : paintObject.PaintNearestTriangleSurface(brush, hitInfo.point);
                        break;

                    case UseMethodType.DirectUV:
                        /*if (!(hitInfo.collider is MeshCollider))
                            Debug.LogWarning("Raycast may be unexpected if you do not use MeshCollider.");
                        success = erase ? paintObject.EraseUVDirect(brush, hitInfo.textureCoord) : paintObject.PaintUVDirect(brush, hitInfo.textureCoord);
                        */
                        break;
                }
            }
            if (!success)
                Debug.LogError("Failed to paint.");
       
    } 
    #endregion
}

