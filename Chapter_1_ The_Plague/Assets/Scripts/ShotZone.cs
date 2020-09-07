﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotZone : MonoBehaviour
{
    public Light[] lightsOn;
    public Light[] lightsOff;
    public Shot targetShot;
    public NoiseTrigger sound;
    public bool canNoise = false;
    void OnTriggerEnter (Collider c) {
        if (c.CompareTag("Player")) {
            TurnLightsOn();
            TurnLightsOff();
            targetShot.CutToShot();
            if(canNoise)
            {
                sound.PlaySound();
                canNoise = false;
            }
        }
    }

    void TurnLightsOn()
    {
        if(lightsOn != null)
        {
            foreach(Light light in lightsOn)
            {
                light.enabled = true;
            }
        }
    }
    void TurnLightsOff()
    {
        if(lightsOff != null)
        {
            foreach(Light light in lightsOff)
            {
                light.enabled = false;
            }
        }
    }
}
