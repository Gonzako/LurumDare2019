using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellFlipped : MonoBehaviour
{
    [SerializeField]
    private float shellSpeed = 5f;

    private new Collider2D collider;
    private new Rigidbody2D rigidbody2D;

    private Vector2 direction = Vector2.zero;

    private void Awake()
    {
        collider = GetComponent<Collider2D>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = new Vector2(direction.x * shellSpeed, rigidbody2D.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.WasHitByPlayer())
        {
            HandlePlayerCollision(collision);
        }
        else
        {
            if (collision.WasSide())
            {
                LaunchShell(collision);
                var takeShellHits = collision.collider.GetComponent<ITakeShellHits>();
                if (takeShellHits != null)
                {
                   takeShellHits.HandleShellHit(this);
                }
            }            
        }
    }

    private void HandlePlayerCollision(Collision2D collision)
    {
        var playerMovementController = collision.collider.GetComponent<PlayerMovementController>();
        //this means it is not moving
        if (direction.magnitude == 0)
        {
            LaunchShell(collision);
            if (collision.WasTop())
            {
                playerMovementController.Bounce();
            }                
        }
        else //if the thing is moving
        {
            //if collision was on top we stop the thing
            if (collision.WasTop())
            {
                direction = Vector2.zero;
                playerMovementController.Bounce();
            }
            else //if its not on top it kills us
            {
                GameManager.Instance.KillPlayer();
            }
        }
    }

    private void LaunchShell(Collision2D collision)
    {
        float floatDirection = collision.contacts[0].normal.x > 0 ? 1f : -1f;
        direction = new Vector2(floatDirection, 0);

    }
}
