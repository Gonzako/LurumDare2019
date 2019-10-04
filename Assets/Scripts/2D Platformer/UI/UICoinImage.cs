using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICoinImage : MonoBehaviour
{

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        GameManager.Instance.OnCoinsChanged += Pulse;
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnCoinsChanged -= Pulse;
    }

    //this might get used if, up to a certain number of coins, we want to play a different animation or something like this
    private void Pulse(int coins)
    {
        animator.SetTrigger("CoinPulse");
    }

}
