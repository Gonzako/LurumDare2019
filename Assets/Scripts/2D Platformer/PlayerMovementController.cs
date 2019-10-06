using System;
using UnityEngine;

[RequireComponent(typeof(CharacterGrounding))]
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovementController : MonoBehaviour, IMove
{

    [SerializeField]
    private float moveSpeed = 2;
    [SerializeField]
    private float jumpForce = 400;
    [SerializeField]
    private float bounceForce = 200;
    [SerializeField]
    private float wallJumpForce = 300;

    private new Rigidbody2D rigidbody2D;
    private CharacterGrounding characterGrounding;
    
    public float Speed { get; private set; }
    private Animator animator;
    private AudioSource audioSource;
    public AudioClip[] sndJump;
    public AudioClip[] sndPaint;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        characterGrounding = GetComponent<CharacterGrounding>();
        audioSource = GetComponent<AudioSource>();
    }

    //button checks in update to see if we pressed the button during the last frame
    private void Update()
    {

        if (Input.GetButtonDown("Jump") && characterGrounding.IsGrounded)
        {

            rigidbody2D.AddForce(Vector2.up * jumpForce);
            if (CONST.isSoundEnabled) PlayJumpSound();
            animator.SetBool("IsJumping", true);
            if (characterGrounding.GroundedDirection != Vector2.down)
            {
                rigidbody2D.AddForce(characterGrounding.GroundedDirection*-1f * wallJumpForce);
            }
        }

        if (CONST.isSoundEnabled) PlayPaintSound();
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Speed = horizontal;

        Vector3 movement = new Vector3(horizontal, 0);

        transform.position += movement * Time.deltaTime * moveSpeed;
    }

    internal void Bounce()
    {
        rigidbody2D.AddForce(Vector2.up * bounceForce);
    }

    private void PlayJumpSound()
    {
        audioSource.clip = sndJump[UnityEngine.Random.Range(0, sndJump.Length)];
        audioSource.Play();
    }

    private void PlayPaintSound()
    {
        if (!audioSource.isPlaying && PaintableObjectData.paintingSound)
        {
            audioSource.clip = sndPaint[UnityEngine.Random.Range(0, sndPaint.Length-1)];
            audioSource.Play();
        }
    }
}
