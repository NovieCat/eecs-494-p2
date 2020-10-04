﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Referenced from:
// https://answers.unity.com/questions/750933/make-a-gameobject-follow-player-footsteps.html
public class FollowTarget : MonoBehaviour
{
    public float followSpeed = 1.0f;
    public GameObject followTarget;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,
                                                 followTarget.transform.position,
                                                 followSpeed * Time.deltaTime);
    }
}