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


        //Esto significa que si la velocidad es 0 no hace el flip
        //Si estamos totalmente parados nos quedamos mirando a la 
        //direccion que sea que estuvieramos mirando
        if (speed != 0)
        {
            spriteRenderer.flipX = speed > 0;
        }
        
    }
}
