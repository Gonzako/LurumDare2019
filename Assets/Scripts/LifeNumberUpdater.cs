using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeNumberUpdater : MonoBehaviour
{
    GameManager gameManager;

    Text thisText;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        thisText = GetComponent<Text>();
        thisText.text = "x " + gameManager.Lives.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        thisText.text = "x " + gameManager.Lives.ToString();
    }
}
