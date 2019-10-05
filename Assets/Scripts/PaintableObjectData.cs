using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintableObjectData : MonoBehaviour
{
    public int layerToChangeInto = 11;
    private int currentLayer;
    public bool IsPainted { get { return isPainted; } set { isPainted = value; changeLayerToWalkable();  } }
    bool isPainted;


    private void changeLayerToWalkable()
    {
        Debug.Log("tried to change layer");
        if (isPainted)
        {
            transform.gameObject.layer = layerToChangeInto;
        }
        else
        {
            transform.gameObject.layer = currentLayer;
        }
    }




    #region UnityAPI
    private void Awake()
    {
        currentLayer = gameObject.layer;
    }
    #endregion
}
