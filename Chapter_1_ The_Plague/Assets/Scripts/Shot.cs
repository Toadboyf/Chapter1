using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public Transform lookTarget;
    public bool rotating;
    public void CutToShot () {
        Camera.main.transform.parent = null;
        Camera.main.transform.localPosition = transform.position;
        Camera.main.transform.localRotation = transform.rotation;
    }
    public void CutToLookShot () {
        Camera.main.transform.localPosition = transform.position;
        Camera.main.transform.localRotation = transform.rotation;
        Camera.main.transform.parent = transform;
    }

    void Update()
    {
        if(rotating)
        {
            transform.LookAt(lookTarget, Vector3.up);
        }
    }

    void OnDrawGizmosSelected () {
        if (!Application.isPlaying) {
            CutToShot();
        }
    }
}
