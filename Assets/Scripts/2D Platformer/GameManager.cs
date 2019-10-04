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

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            //Singleton Logic
            Instance = this;
            DontDestroyOnLoad(gameObject);
            //GameManager Logic
            RestartGame();
        }
        
    }

    internal void KillPlayer()
    {
        Lives--;

        if (OnLivesChanged != null)
        {
            OnLivesChanged(Lives);
        }

        if (Lives <= 0)
        {
            RestartGame();
        }

        else
        {               
            SendPlayerToCheckpoint();
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

    private void RestartGame()
    {
        currentLevelIndex = 0;

        Lives = 3;
        coins = 0;
        if (OnCoinsChanged != null)
        {
            OnCoinsChanged(coins);
        }
        SceneManager.LoadScene(0);
    }
}
