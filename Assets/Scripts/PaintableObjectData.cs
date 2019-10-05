using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintableObjectData : MonoBehaviour
{
    public int layerToChangeInto = 11;
    public int numbersThatCanBePainted = 3;
    private int currentLayer;
    public bool canBePainted { get { numbersPainted++; isPainted = true ;changeLayerToWalkable();  return numbersPainted < numbersThatCanBePainted;  }  }

    bool isPainted;
    private int numbersPainted = 0;

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
