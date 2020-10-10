using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool needsGhost = true;
    private bool gotGhost = false;

    private void Start() {
        if (needsGhost) {
            GetComponent<Renderer>().material.color = Color.grey;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (needsGhost) {
            if (other.tag == "Follower") {
                gotGhost = true;
                Destroy(other.gameObject); // TODO fade?
                GetComponent<Renderer>().material.color = Color.yellow;
            }
            if (other.tag == "Player" && gotGhost) {
                //Goal
                StartCoroutine(GameControl.instance.EndGameEffect(other.gameObject, true));
            }
        }

        else if (other.tag == "Player") {
            //Goal
            StartCoroutine(GameControl.instance.EndGameEffect(other.gameObject, true));
        }
    }
}
