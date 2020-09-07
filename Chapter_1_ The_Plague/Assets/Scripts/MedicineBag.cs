using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicineBag : MonoBehaviour
{
    public GameManager gm;
    public ShotZone triggerSound;
    void OnDestroy()
    {
        gm.SpawnManInHouse();
        triggerSound.canNoise = true;
    }  
}
