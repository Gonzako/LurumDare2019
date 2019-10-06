using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField]
    private Transform start;
    [SerializeField]
    private Transform end;
    [SerializeField]
    private Transform sprite;
    [SerializeField]
    private float lerpSpeed = 1;

    private float positionPercent;
    private int direction = 1;

    private AudioSource audioSource;
    public AudioClip[] sndSaw;
    bool sndAlreadyPlayed;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        float distance = Vector3.Distance(start.position, end.position);
        float speedForDistance = lerpSpeed / distance;

        positionPercent += Time.deltaTime * direction * speedForDistance;

        sprite.position = Vector3.Lerp(start.position, end.position, positionPercent);

        if (positionPercent >= 1 && direction == 1)
        {
            direction = -1;
            if(gameObject.name.StartsWith("Saw"))
            {
                sndAlreadyPlayed = false;
                if (CONST.isSoundEnabled) PlaySawSound();
            }
        }
        else if(positionPercent <=0 && direction == -1)
        {
            direction = 1;
            if (gameObject.name.StartsWith("Saw"))
            {
                sndAlreadyPlayed = false;
                if (CONST.isSoundEnabled) PlaySawSound();
            }
        }
    }

    private void PlaySawSound()
    {
        if (!audioSource.isPlaying && !sndAlreadyPlayed)
        {
            audioSource.clip = sndSaw[UnityEngine.Random.Range(0, sndSaw.Length)];
            audioSource.Play();
            sndAlreadyPlayed = true;
        }
    }
}
