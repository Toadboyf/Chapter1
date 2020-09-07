using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealCamera : MonoBehaviour
{
    public WalkingScript playerWalk;
    public PlayerInteract playerScript;
    public Transform cameraSpot;
    public Transform cameraReturnLoc;
    bool inMotion = false;
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if(inMotion)
        {
            Camera.main.transform.position = cameraSpot.position;
            Camera.main.transform.rotation = cameraSpot.rotation;
        }
    }

    public void StartCutscene()
    {
        playerWalk.gameObject.GetComponent<Animator>().enabled = false;
        playerWalk.disabled = true;
        playerScript.disabled = true;
        Camera.main.transform.position = cameraSpot.position;
        Camera.main.transform.rotation = cameraSpot.rotation;
        inMotion = true;
        anim.enabled = true;
    }

    public void EndCutscene()
    {
        playerWalk.gameObject.GetComponent<Animator>().enabled = true;
        playerWalk.disabled = false;
        playerScript.disabled = false;
        inMotion = false;
        anim.enabled = false;
        Camera.main.transform.position = cameraReturnLoc.position;
        Camera.main.transform.rotation = cameraReturnLoc.rotation;
    }
}
