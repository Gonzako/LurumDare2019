using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UICoinsText : MonoBehaviour
{
    private TextMeshProUGUI tmproText;

    private void Awake()
    {
        tmproText = GetComponent<TextMeshProUGUI>();
        tmproText.text = GameManager.Instance.coins.ToString();
    }

    private void Start()
    {
        GameManager.Instance.OnCoinsChanged += HandleCoinsChanged;
    }

    private void HandleCoinsChanged(int coins)
    {
        tmproText.text = coins.ToString();
    }

}
