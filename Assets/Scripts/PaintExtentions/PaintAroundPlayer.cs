﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Es.InkPainter;
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
    private Brush brush;

    [SerializeField]
    private UseMethodType useMethodType = UseMethodType.WorldPoint;
    [SerializeField]
    bool erase;

    private Camera cam;

    private Vector3 getPointOfContact(Collider2D otherCol)
    {
        RaycastHit2D _hit = Physics2D.Raycast(transform.position, transform.position - otherCol.transform.position);
        return _hit.point;
    }

    #region UnityAPI

    private void Update()
    {
        brush.RotateAngle += 40 * Time.deltaTime;
        if (brush.RotateAngle > 360)
            brush.RotateAngle = 0;
    }

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
        if (stuff != null)

            switch (useMethodType)
            {
                case UseMethodType.RaycastHitInfo:
                    //success = erase ? paintObject.Erase(brush, hitInfo) : paintObject.Paint(brush, hitInfo);
                    break;

                case UseMethodType.WorldPoint:
                    success = erase ? stuff.Erase(brush, pointOfContact) : stuff.Paint(brush, pointOfContact, null, cam);
                    data.IsPainted = true;
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

        if (!success)
            Debug.LogError("Failed to paint.");
    } 
    #endregion
}

