using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingScript : MonoBehaviour
{

    Animator anim;
    CharacterController playerController;
    public float moveSpeed;
    public float rotSpeed;
    float gravity = 9.8f;
    float vSpeed = 0;
    public bool disabled;
    public AudioClip[] walkSounds;
    AudioSource audioSource;
    AudioClip lastPlayedClip;
    AudioClip currentClip;

    void Awake()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        playerController = GetComponent<CharacterController>();
        disabled = false;
    }

    void Update()
    {
        if(!disabled)
        {
            float moveForward = Input.GetAxis("Vertical");
            float rotTurn = Input.GetAxis("Horizontal");

            Vector3 vel = transform.forward * moveForward * moveSpeed;

            if(playerController.isGrounded)
            {
                vSpeed = 0;
            }
            if(rotTurn != 0)
            {
                transform.Rotate(transform.up, rotSpeed * rotTurn * Time.deltaTime);
            }
            if(moveForward != 0)
            {
                anim.SetBool("Walking", true);
            }
            else
            {
                anim.SetBool("Walking", false);
            }

            vSpeed -= gravity * Time.deltaTime;
            vel.y = vSpeed;
            playerController.Move(vel * Time.deltaTime);
        }
    }

    void PlayRandomWalkNoise()
    {
        int randClip;
        do
        {
            randClip = Random.Range(0, walkSounds.Length);
            currentClip = walkSounds[randClip];
        }
        while(currentClip == lastPlayedClip);

        audioSource.PlayOneShot(currentClip);
        lastPlayedClip = currentClip;
    }
}
