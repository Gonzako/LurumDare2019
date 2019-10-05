using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintableObjectData : MonoBehaviour
{
    public int layerToChangeInto = 11;
    public int numbersThatCanBePainted = 3;
    [SerializeField]
    private float timeToWait = 0.2f;
    private int currentLayer;
    public bool canBePainted { get { return checkIfCanBePainted(); } }

    private bool checkIfCanBePainted()
    {
        if (Time.time > counter)
        {
            counter = Time.time + timeToWait;
            numbersPainted++;
            isPainted = true;
            changeLayerToWalkable();
            return numbersPainted < numbersThatCanBePainted;
        }
        else return false;
    }

    bool isPainted;
    private int numbersPainted = 0;
    private float counter;

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
    private void Update()
    {
        
    }
    private void Awake()
    {
        currentLayer = gameObject.layer;
    }
    #endregion
}
