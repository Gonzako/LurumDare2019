using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class MusicPlayer : MonoBehaviour {

	AudioSource audioSource;

	static MusicPlayer musicPlayer;

    void Awake() {
        audioSource = this.GetComponent<AudioSource>();

        if (musicPlayer != null) {
            Destroy(gameObject);
        } else {
            musicPlayer = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }

        if (!CONST.isMusicEnabled) audioSource.volume = 0f;
    }

    private void Update()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (!CONST.isMusicEnabled)
            {
                audioSource.volume = 0f;
            } else
            {
                audioSource.volume = 0.4f;
            }
        }
    }
}
