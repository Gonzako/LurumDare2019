using UnityEngine;

public class BreakableBox : MonoBehaviour, ITakeShellHits
{
    public void HandleShellHit(ShellFlipped shellFlipped)
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.WasHitByPlayer() &&
            collision.WasBottom())
        {
            Destroy(gameObject);
        }
    }
}
