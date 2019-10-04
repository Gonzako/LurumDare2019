using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBox : MonoBehaviour, ITakeShellHits
{
    [SerializeField]
    private SpriteRenderer enabledSprite;
    [SerializeField]
    private SpriteRenderer disabledSprite;
    [SerializeField]
    private SpriteRenderer coin;

    [SerializeField]
    private int totalCoins = 1;

    private Animator animator;
    private int remainingCoins;

    public void HandleShellHit(ShellFlipped shellFlipped)
    {
        if (remainingCoins > 0)
        {
            TakeCoin();
        }        
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        remainingCoins = totalCoins;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (remainingCoins <= 0 &&
            collision.WasHitByPlayer() &&
            collision.WasBottom())
        {
            Destroy(gameObject);
        }

        if (remainingCoins > 0 &&
            collision.WasHitByPlayer() &&
            collision.WasBottom())
        {
            TakeCoin();
        }       
    }

    private void TakeCoin()
    {
        GameManager.Instance.AddCoin();
        remainingCoins--;
        animator.SetTrigger("FlipCoin");

        if (remainingCoins <= 0)
        {
            enabledSprite.enabled = false;
            disabledSprite.enabled = true;
            coin.enabled = false;
        }        
    }
}
