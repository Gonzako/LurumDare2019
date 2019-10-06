using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Es.InkPainter.Sample;
public class PaintableObjectData : MonoBehaviour
{
    public int layerToChangeInto = 11;
    public int numbersThatCanBePainted = 15;
    [SerializeField]
    private float timeToWait = 0.1f;
    private int currentLayer;
    public int indiceColor  = 0;
    public bool canBePainted { get { return checkIfCanBePainted(); } }

    public static bool paintingSound;
    public Color allowedColour;
    public bool colorLimiter = false;

    private Es.InkPainter.Sample.ColorChange colours;

    private void Start()
    {
        colours = FindObjectOfType<ColorChange>();
        allowedColour = colours.colors[Mathf.Clamp(indiceColor, 0, colours.colors.Length-1)];

    }

    private bool checkIfCanBePainted()
    {
       if (!colorLimiter)
        {
            if (Time.time > counter)
            {
                paintingSound = true;
                Debug.Log("PaintSound");
                counter = Time.time + timeToWait;
                numbersPainted++;
                isPainted = true;
                changeLayerToWalkable();
                return numbersPainted < numbersThatCanBePainted;
            }
            else
            {
                paintingSound = false;
                return false;
            }
        }
        else if (Time.time > counter && colours.getCurrentColour() == allowedColour)
            {

                paintingSound = true;
                Debug.Log("PaintSound");
                counter = Time.time + timeToWait;
                numbersPainted++;
                isPainted = true;
                changeLayerToWalkable();
                return numbersPainted < numbersThatCanBePainted;
            }
            else
            {
                paintingSound = false;
                return false;
            }

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
