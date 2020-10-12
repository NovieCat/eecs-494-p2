using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    GameObject currentRoom;

    private void Update() {
        if (GetComponent<HasPower>().GetPower() <= 0) {
            if (GameControl.instance.GetInEndSequence()) return;
            // GameControl.instance.PlayEndGameSound(false);
            StartCoroutine(GameControl.instance.EndGameEffect(this.gameObject, false));
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
}
