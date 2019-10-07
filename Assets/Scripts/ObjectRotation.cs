using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    public bool rotate;
    public bool clockWise;
    public float rotationAmount = 25f;

    void FixedUpdate()
    {
        if (rotate)
        {
            if(clockWise) {
                transform.Rotate(0, 0, -rotationAmount * Time.deltaTime);
            } else
            {
                transform.Rotate(0, 0, rotationAmount * Time.deltaTime);
            }            
        }
    }
}
