using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffLight : MonoBehaviour
{

    GameObject player;
    public float threshhold;
    Light source;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        source = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, player.transform.position) > threshhold)
        {
            if(source.enabled)
                source.enabled = false;
        }
        else
        {
            if(!source.enabled)
                source.enabled = true;
        }
    }
}
