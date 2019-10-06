using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalSceneManager : MonoBehaviour
{
    AudioSource audioSource;

    public Text txtMessage;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        TextValue();
    }

    public void GoToMainMenu()
    {
        StartCoroutine(ButtonSound("mainMenu"));
    }

    public void RestartGame()
    {
        StartCoroutine(ButtonSound("restartGame"));
    }

    public void TextValue()
    {
        txtMessage.text = "Congrats!\nYou won!";
    }

    public void ChangeSFXValue()
    {
        StartCoroutine(ButtonSound("changeSFX"));
    }

    IEnumerator ButtonSound(string obj)
    {
        if (CONST.isSoundEnabled) audioSource.Play();
        yield return new WaitForSeconds(0.2f);
        if (obj == "mainMenu")
        {
            FindObjectOfType<GameManager>().currentLevelIndex = 0;
            FindObjectOfType<GameManager>().Lives = 3;
            SceneManager.LoadScene(0);
        }
        if (obj == "restartGame")
        {
            FindObjectOfType<GameManager>().currentLevelIndex = 1;
            FindObjectOfType<GameManager>().Lives = 3;
            SceneManager.LoadScene(1);
        }
    }
}
