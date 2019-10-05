using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardLayoutDetector : MonoBehaviour
{
    public Text kb;

    private void Awake()
    {
        new KeyboardLayoutWatcher().KeyboardLayoutChanged += (o, n) =>
        {
            kb.text = $"{o} -> {n}"; // old and new KB layout
        };
    }
}
