using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGrounding : MonoBehaviour
{

    [SerializeField]
    private Transform[] positions;

    [SerializeField]
    private float maxDistance;

    [SerializeField]
    private LayerMask layerMask;

    private Transform groundedObject;
    private Vector3? groundedObjectLastPosition;

    public bool IsGrounded { get; private set; }
    public Vector2 GroundedDirection { get; private set; }

    private AudioSource audioSource;
    public AudioClip[] sndJumpEnds;
    bool sndAlreadyPlayed;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {


        foreach (var position in positions)
        {
            CheckFootForGroundingTransform(position);            
            if (IsGrounded)
                break;
        }

        StickToMovingObjects();

    }

    private void StickToMovingObjects()
    {
        if (groundedObject!= null)
        {
            if (groundedObjectLastPosition.HasValue && 
                groundedObjectLastPosition != groundedObject.position &&
                groundedObject.CompareTag("Moving"))
            {
                Vector3 delta = groundedObject.position - groundedObjectLastPosition.Value;
                transform.position += delta; 
            }
            groundedObjectLastPosition = groundedObject.position;

            if (IsGrounded && !sndAlreadyPlayed)
                PlayJumpEndsSound();
        }
        else
        {
            groundedObjectLastPosition = null;
            sndAlreadyPlayed = false;
        }
    }
    
    private void CheckFootForGroundingTransform(Transform foot)
    {
        var raycastHit = Physics2D.Raycast(foot.position, -foot.up, maxDistance, layerMask);

        Debug.DrawRay(foot.position, -foot.up * maxDistance, Color.red);

        if (raycastHit.collider != null)
        {
            if(groundedObject != raycastHit.collider.transform)
            {
                groundedObjectLastPosition = raycastHit.collider.transform.position;                
            }
            groundedObject = raycastHit.collider.transform;
            IsGrounded = true;
            GroundedDirection = -foot.up;
        }
        else
        {
            groundedObject = null;
            IsGrounded = false;
        }
    }

    private void PlayJumpEndsSound()
    {
        audioSource.clip = sndJumpEnds[UnityEngine.Random.Range(0, sndJumpEnds.Length)];
        audioSource.Play();
        sndAlreadyPlayed = true;
    }
}
