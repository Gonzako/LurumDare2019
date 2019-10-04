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

    private void Update()
    {
        float distance = Vector3.Distance(start.position, end.position);
        float speedForDistance = lerpSpeed / distance;

        positionPercent += Time.deltaTime * direction * speedForDistance;

        sprite.position = Vector3.Lerp(start.position, end.position, positionPercent);

        if (positionPercent >= 1 && direction == 1)
        {
            direction = -1;
        }else if(positionPercent <=0 && direction == -1)
        {
            direction = 1;
        }
    }
}
