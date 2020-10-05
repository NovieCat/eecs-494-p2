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
        Debug.Log("Got collision with: " + other.tag);
        if(other.tag == "Follower") {
            Debug.Log(other.GetComponent<Follower>().GetPower());
            int newPower = other.GetComponent<Follower>().GetPower() - 1;
            if (newPower < 0) {
                other.GetComponent<Follower>().SetPower(0);
            } else {
                other.GetComponent<Follower>().SetPower(newPower);
            }
            Debug.Log(other.GetComponent<Follower>().GetPower());

            // "Deactivate" gate
            Destroy(this.gameObject);
        }
    }
}
