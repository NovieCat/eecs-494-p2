﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player") {
            //Goal
            GameControl.instance.ReloadStage();     //TODO victory
        }
    }
}
