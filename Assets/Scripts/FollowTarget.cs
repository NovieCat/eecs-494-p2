using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Referenced from:
// https://answers.unity.com/questions/750933/make-a-gameobject-follow-player-footsteps.html
public class FollowTarget : MonoBehaviour
{
    public float followSpeed = 1.0f;
    public float speedUpDist = 7.0f;
    public GameObject followTarget;

    // Update is called once per frame
    void Update()
    {
        float speed = followSpeed;
        if (Vector3.Distance(transform.position, followTarget.transform.position) > speedUpDist) {
            speed *= 2;
        }
        transform.position = Vector3.MoveTowards(transform.position,
                                                 followTarget.transform.position,
                                                 speed * Time.deltaTime);
    }
}
