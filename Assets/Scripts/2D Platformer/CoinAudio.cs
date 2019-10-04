using System;
using UnityEngine;

public class CoinAudio : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();   
    }

    void Start()
    {
        GameManager.Instance.OnCoinsChanged += PlayCoinAudio;
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnCoinsChanged -= PlayCoinAudio;
    }

    private void PlayCoinAudio(int coins)
    {
        audioSource.Play();
    }
}
