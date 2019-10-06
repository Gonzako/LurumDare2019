using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    public int Lives { get; set; }

    public event Action<int> OnLivesChanged;
    public event Action<int> OnCoinsChanged;

    public int coins;
    public int currentLevelIndex;

    private AudioSource audioSource;
    public AudioClip[] sndDeath;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Started");
            audioSource = GetComponent<AudioSource>();
            //Singleton Logic
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Lives = 3;
            //GameManager Logic
            //if(currentLevelIndex == 0)
            //    currentLevelIndex++;    
            //RestartGame();
        }        
    }

    internal void KillPlayer()
    {
        Lives--;

        
        if (CONST.isSoundEnabled) PlayDeathSound();
        if (OnLivesChanged != null)
        {
            OnLivesChanged(Lives);
        }

        if (Lives <= 0)
        {
            RestartLevel();
        }

        else
        {               
            SendPlayerToCheckpoint();
        }

        if (Lives == 0)
        {
            Lives = 3;
        }


    }

    private void SendPlayerToCheckpoint()
    {
        var checkpointManager = FindObjectOfType<CheckpointManager>();

        var checkpoint = checkpointManager.GetLastCheckpointThatWasPassed();

        var player = FindObjectOfType<PlayerMovementController>();
        player.transform.position = checkpoint.transform.position;
    }

    internal void AddCoin()
    {
        coins++;
        if (OnCoinsChanged != null)
        {
            OnCoinsChanged(coins);
        }
    }

    public void MoveToNextLevel()
    {
        currentLevelIndex++;
        SceneManager.LoadScene(currentLevelIndex);
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(currentLevelIndex);
    }

    private void RestartGame()
    {
        currentLevelIndex = 1;

        Lives = 3;
        coins = 0;
        if (OnCoinsChanged != null)
        {
            OnCoinsChanged(coins);
        }
        SceneManager.LoadScene(currentLevelIndex);
    }

    private void PlayDeathSound()
    {
        audioSource.clip = sndDeath[UnityEngine.Random.Range(0, sndDeath.Length)];
        audioSource.Play();
    }
}
