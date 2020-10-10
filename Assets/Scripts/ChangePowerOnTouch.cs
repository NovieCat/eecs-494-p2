using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePowerOnTouch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Color matColor = GetComponent<Renderer>().material.GetColor("_Color");
        matColor.a = 0.5f;
        GetComponent<Renderer>().material.SetColor("_Color", matColor);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Got collision with: " + other.tag + " " + (other.GetComponent<HasPower>() == null));
        if (other.GetComponent<HasPower>() == null) return;
        if (other.GetComponent<HasPower>().GetInvincible()) return;

        // Trigger IFrames
        other.GetComponent<HasPower>().IFramesTriggered();

        Debug.Log(other.GetComponent<HasPower>().GetPower());
        int newPower = other.GetComponent<HasPower>().GetPower() - 1;
        if (newPower < 0) {
            other.GetComponent<HasPower>().SetPower(0);
        } else {
            other.GetComponent<HasPower>().SetPower(newPower);
        }
        Debug.Log(other.GetComponent<HasPower>().GetPower());

        if (other.tag == "Follower") {
            // "Deactivate" gate
            Destroy(this.gameObject);
        }
    }
}
