using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]

public class CharacterAnimation : MonoBehaviour
{
    private Animator animator;
    private IMove mover;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        mover = GetComponent<IMove>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    private void Update()
    {
        float speed = mover.Speed;
        animator.SetFloat("Speed", Mathf.Abs(speed));

        if (speed == 0)
        {
            animator.SetBool("isMoving", false);
            Debug.Log("NOT FCKIN RUNNING");
        }
        else {
            animator.SetBool("isMoving", true);
            Debug.Log("IS RUNNING");
            spriteRenderer.flipX = speed > 0;
        }
    }
}
