using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseTrigger : MonoBehaviour
{

    public AudioClip noise;
    AudioSource gmAudio;

    void Awake()
    {
        gmAudio = GameObject.FindGameObjectWithTag("GameController").GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        gmAudio.PlayOneShot(noise);
    }
}
