using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{

    public List<string> heldItems = new List<string>();
    public Transform checkPos;
    public float checkRadius;
    public LayerMask interactableMask;
    public bool disabled;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(!disabled)
            {
                //Use CheckSphere to see if near any interactables
                if(Physics.CheckSphere(checkPos.position, checkRadius, interactableMask))
                {
                    Collider[] hits = Physics.OverlapSphere(checkPos.position, checkRadius, interactableMask);
                    if(hits != null)
                    {
                        Collider closestTarget = hits[0];
                        float closestAngle = Mathf.DeltaAngle(hits[0].transform.eulerAngles.y, transform.eulerAngles.y);
                        foreach(Collider c in hits)
                        {
                            //decide priority for selection by player angle
                            //Check for angle to objects
                            float tempAngle;
                            tempAngle = Mathf.DeltaAngle(c.transform.eulerAngles.y, transform.eulerAngles.y);
                            if(Mathf.Abs(tempAngle) < closestAngle)
                            {
                                closestTarget = c;
                                closestAngle = tempAngle;
                            }
                        }
                        closestTarget.gameObject.GetComponent<Interactable>().Interact();
                    }
                }
            }
        }
    }
}
