using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmptyIntro : MonoBehaviour
{
    public GameObject conversationalPanel;
    Text dialogText;
    public string[] dialogLines;
    AudioSource audioSource;

    bool moreText;
    bool isWriting;

    int actualLine = 0;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        dialogText = conversationalPanel.transform.GetChild(0).GetComponent<Text>();
        conversationalPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad >= 7f && !conversationalPanel.activeSelf)
            AdvanceText();

        if(moreText && !isWriting)
        {
            moreText = false;
            StartCoroutine(WriteText());
        }

        if ((Input.anyKeyDown || Input.GetMouseButtonDown(0)) && !isWriting)
            AdvanceText();
    }

    public void AdvanceText()
    {
        if (!moreText)
        {
            if (conversationalPanel.activeSelf)
            {
                moreText = true;
            }
            else
            {
                conversationalPanel.SetActive(true);
                StartCoroutine(WriteText());
            }
        }
    }

    IEnumerator WriteText()
    {
        isWriting = true;
        dialogText.text = "";
        moreText = false;
        if (actualLine >= dialogLines.Length)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
        } else
        {

            char[] texto = dialogLines[actualLine].ToCharArray();

            for (int i = 0; i < dialogLines[actualLine].Length; i++)
            {
                dialogText.text += texto[i];
                yield return new WaitForSeconds(0.025f);
                audioSource.Play();
            }
            actualLine++;            
        }
        isWriting = false;
    }
}
