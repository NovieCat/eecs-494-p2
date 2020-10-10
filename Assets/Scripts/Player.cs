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
        invincible = true;
        StartCoroutine(IFrameEffect());
    }

    IEnumerator IFrameEffect() {
        Color tmp = GetComponentInChildren<TextMesh>().color;
        
        // Show damage
        GetComponentInChildren<SpriteRenderer>().material.color = Color.grey;
        GetComponentInChildren<TextMesh>().color = Color.red;

        // Wait for invincibility to fall off
        yield return new WaitForSeconds(1.0f);

        // Return player to original status
        GetComponentInChildren<SpriteRenderer>().material.color = Color.white;
        GetComponentInChildren<TextMesh>().color = tmp;
        invincible = false;
    }
}
