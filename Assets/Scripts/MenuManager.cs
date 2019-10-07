using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    AudioSource audioSource;

    public Text txtMusic;
    public Text txtSFX;
    public GameObject controlsPanel;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        controlsPanel.SetActive(false);
        txtMusic.text = "Music: ON";
        txtSFX.text = "SFX: ON";
    }

    public void GoToNextLevel()
    {
        StartCoroutine(ButtonSound("nextLevel"));
    }

    public void OpenControlsPanel()
    {
        StartCoroutine(ButtonSound("controlsPanel"));
    }

    public void ChangeMusicValue()
    {
        StartCoroutine(ButtonSound("changeMusic"));
    }

    public void ChangeSFXValue()
    {
        StartCoroutine(ButtonSound("changeSFX"));
    }

    IEnumerator ButtonSound(string obj)
    {
        if(CONST.isSoundEnabled) audioSource.Play();
        yield return new WaitForSeconds(0.2f);
        if (obj == "controlsPanel")
        {
            controlsPanel.SetActive(true);
        }

        if (obj == "nextLevel")
        {
            GameManager.Instance.MoveToNextLevel();
            /*
            FindObjectOfType<GameManager>().currentLevelIndex++;
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            */
        }
        if(obj == "changeMusic")
        {
            if(txtMusic.text.EndsWith("ON"))
            {
                txtMusic.text = "Music: OFF";
                CONST.isMusicEnabled = false;
            } else
            {
                txtMusic.text = "Music: ON";
                CONST.isMusicEnabled = true;
            }
        }
        if(obj == "changeSFX")
        {
            if (txtSFX.text.EndsWith("ON"))
            {
                txtSFX.text = "SFX: OFF";
                CONST.isSoundEnabled = false;
            }
            else
            {
                txtSFX.text = "SFX: ON";
                CONST.isSoundEnabled = true;
            }
        }
    }
}
