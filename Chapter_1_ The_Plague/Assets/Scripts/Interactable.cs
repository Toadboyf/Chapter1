using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    Text textPrompt;
    public Transform cameraShot;
    public LayerMask newCullMask;
    public Transform floatingPos;
    public float rotSpeed;
    public string normalPrompt;
    public string grabPrompt;
    public bool notRetrievable;
    bool looking;
    public bool waitingForInput;
    public bool required;
    public Interactable itemToOpen;
    Vector3 camStartingPos;
    Quaternion camStartingRot;
    LayerMask camMask;
    int waitASec = 400;

    void Awake()
    {
        GameObject ui = GameObject.FindGameObjectWithTag("UIPopup");
        textPrompt = ui.GetComponent<Text>();
    }
    void Update()
    {
        if(waitingForInput)
        {   
            if(waitASec > 0)
                waitASec -= 1;

            //float and rotate object
            transform.Rotate(Vector3.up * rotSpeed, Space.World);

            if(Input.anyKeyDown && waitASec <= 0)
            {
                waitingForInput = false;
                waitASec = 0;
                Time.timeScale = 1;
                if(textPrompt.text == grabPrompt)
                {
                    textPrompt.text = "";
                }
                Camera.main.transform.position = camStartingPos;
                Camera.main.transform.rotation = camStartingRot;
                Camera.main.cullingMask = camMask;
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInteract>().heldItems.Add(this);
                //if a required object, open the object affected before destroy
                if(required)
                {
                    itemToOpen.notRetrievable = false;
                }
                Destroy(gameObject);
            }
        }
    }
    public void Interact()
    {
        if(!looking && !notRetrievable)
        {
            looking = true;
            //Set text for UI while looking at object
            textPrompt.text = grabPrompt;
            //Set Camera pos and rot to zoom in on object
            camStartingPos = Camera.main.transform.position;
            camStartingRot = Camera.main.transform.rotation;
            Camera.main.transform.rotation = cameraShot.rotation;
            Camera.main.transform.position = cameraShot.position;
            //While camera zoomed on object, cull Player model from rendering
            camMask = Camera.main.cullingMask;
            Camera.main.cullingMask = newCullMask;
            //Disable Item Collider
            gameObject.GetComponent<BoxCollider>().enabled = false;
            //Set obj position to floating one
            transform.position = floatingPos.position;
            transform.rotation = floatingPos.rotation;
            //Set waitingforinput
            waitingForInput = true;
            //disable player movement
            Time.timeScale = 0;
        }
        else if(notRetrievable)
        {
            if(textPrompt.text != normalPrompt)
            {
                textPrompt.text = normalPrompt;
                StartCoroutine(PromptTimer());
            }
        }
    }

    IEnumerator PromptTimer()
    {
        yield return new WaitForSecondsRealtime(3f);
        if(textPrompt.text == normalPrompt)
        {
            textPrompt.text = "";
        }
    }
}
