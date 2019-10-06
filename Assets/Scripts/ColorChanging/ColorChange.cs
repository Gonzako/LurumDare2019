using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{

    public Color[] colors = new Color[3];
    SpriteRenderer sprite;
    private int colorIndex = 0;
     

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = colors[colorIndex];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ChangeColor();
        }
    }

    private void ChangeColor()
    {
        colorIndex++;
        if (colorIndex != 3)
        {
            sprite.color = colors[colorIndex];
        }else if(colorIndex == 3)
        {
            colorIndex = 0;
            sprite.color = colors[colorIndex];
        }
        
    }

}
