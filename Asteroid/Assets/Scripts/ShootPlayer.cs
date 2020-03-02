using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShootPlayer : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            StartCoroutine(PollBull.inst.SpawnBull());
        }
    }
}
