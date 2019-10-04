using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public bool Passed { get; private set; }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        var player = collider.GetComponent<PlayerMovementController>();

        if(player != null)
        {
            Passed = true;
        }
    }
}
