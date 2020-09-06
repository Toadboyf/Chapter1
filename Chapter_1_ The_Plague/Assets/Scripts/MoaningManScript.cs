using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoaningManScript : MonoBehaviour
{
    Animator anim;
    void Awake()
    {
        anim = GetComponent<Animator>();
        //Set anim speed to random
        anim.speed = Random.Range(0.2f, 0.8f);
    }
}
