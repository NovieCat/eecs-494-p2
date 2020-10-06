using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Color change referenced from:
// https://answers.unity.com/questions/209573/how-to-change-material-color-of-an-object.html
public class Follower : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.cyan;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<HasPower>().GetPower() <= 0) {
            GetComponent<FollowTarget>().enabled = false;
            GetComponent<LineToTarget>().RemoveLine();
            GetComponent<LineToTarget>().enabled = false;
            gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Player") {
            if (GetComponent<HasPower>().GetPower() != 0) {
                GameControl.instance.ReloadStage();     //  TODO game over
            }
        }
    }
}
