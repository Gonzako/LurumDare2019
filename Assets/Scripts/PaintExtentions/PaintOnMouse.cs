using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintOnMouse : MonoBehaviour
{

    public GameObject sploch1;
    public GameObject sploch2;
    public GameObject sploch3;
    public GameObject splochToActivate;

    private int splochNumber;

    private void OnMouseDown()
    {
        splochToActivate = determinateSplotch(Random.Range(1, 3));

        
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private GameObject determinateSplotch(int n)
    {
        GameObject x;

        switch(n)
        {
            case 1:
                x = sploch1;
                break;
            case 2:
                x = sploch2;
                break;
            case 3:
                x = sploch3;
                break;
            default:
                x = new GameObject();
                break;
        }
        return x;
    }
}
