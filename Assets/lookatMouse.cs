using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookatMouse : MonoBehaviour
{
    Camera cam;
    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        var dif = Input.mousePosition - cam.WorldToScreenPoint(transform.parent.position);
        var angle = Mathf.Atan2(dif.y, dif.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);


    }

}
