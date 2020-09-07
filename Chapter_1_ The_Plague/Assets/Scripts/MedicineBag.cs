using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicineBag : MonoBehaviour
{
    public GameManager gm;

    void OnDestroy()
    {
        gm.SpawnManInHouse();
    }
}
