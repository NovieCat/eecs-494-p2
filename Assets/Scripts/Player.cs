using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    GameObject currentRoom;
    private bool invincible;

    private void Update() {
        if (GetComponent<HasPower>().GetPower() <= 0) {
            GameControl.instance.ReloadStage();     //  TODO game over
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Room") {
            Debug.Log("Current room: " + other.gameObject.name);
            currentRoom = other.gameObject;
        }
    }

    public GameObject GetCurrentRoom() {
        return currentRoom;
    }

    public bool IsInvincible(){
        return invincible;
    }

    public void IFramesTriggered() {
        Debug.Log("Player IFrames Triggered");
        invincible = true;
        StartCoroutine(IFrameEffect());
    }

    IEnumerator IFrameEffect() {
        // Set player's opacity to half
        // Color tempColor = GetComponent<Renderer>().material.GetColor("_Color");
        // tempColor.a = 0.5f;
        // GetComponent<Renderer>().material.SetColor("_Color", tempColor);
        gameObject.GetComponent<Renderer>().material.color = Color.grey;

        // Wait for invincibility to fall off
        yield return new WaitForSeconds(1.0f);

        // Return player to original status
        // tempColor.a = 1.0f;
        // GetComponent<Renderer>().material.SetColor("_Color", tempColor);
        gameObject.GetComponent<Renderer>().material.color = Color.white;
        invincible = false;
    }
}
