﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Es.InkPainter.Sample
{

    public class ColorChange : MonoBehaviour
    {

        public Color[] colors = new Color[3];
        SpriteRenderer sprite;
        private int colorIndex = 0;
        private PaintAroundPlayer paintAround;

        // Start is called before the first frame update
        void Start()
        {
            sprite = GetComponent<SpriteRenderer>();
            sprite.color = colors[colorIndex];
            paintAround = GetComponentInChildren<PaintAroundPlayer>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                ChangeColor();
            }
            else if (Input.GetMouseButtonDown(1))
            {
                ChangeColorReverse();
            }
        }

        public Color getCurrentColour()
        {
            return colors[colorIndex];

        }

        public Color getRandomColour()
        {
            return colors[Random.Range(0, colors.Length - 1)];
        }

        private void ChangeColor()
        {
            colorIndex++;
            if (colorIndex != 3)
            {
                sprite.color = colors[colorIndex];
                paintAround.brush.Color = colors[colorIndex];
            }
            else if (colorIndex == 3)
            {
                colorIndex = 0;
                sprite.color = colors[colorIndex];
                paintAround.brush.Color = colors[colorIndex];
            }
        }

        private void ChangeColorReverse()
        {
            colorIndex--;
            if (colorIndex != -1)
            {
                sprite.color = colors[colorIndex];
                paintAround.brush.Color = colors[colorIndex];
            }
            else if (colorIndex == -1)
            {
                colorIndex = 2;
                sprite.color = colors[colorIndex];
                paintAround.brush.Color = colors[colorIndex];
            }

        }
    }


}
