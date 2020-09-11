using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public AudioClip doorOpen;
    public AudioClip doorClose;
    AudioSource doorAudio;
    public GameManager gameManager;
    public Interactable oppositeDoor;

    void Awake()
    {
        doorAudio = GetComponent<AudioSource>();
    }

    public void OpenDoor()
    {
        doorAudio.PlayOneShot(doorOpen);
    }

    public void CloseDoor()
    {
        doorAudio.PlayOneShot(doorClose);
        oppositeDoor.gameObject.layer = 8;
    }
}
