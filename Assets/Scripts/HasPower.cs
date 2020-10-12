using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasPower : MonoBehaviour
{
    public int power = 1;
    public bool hasIFrames = false;

    private bool invincible;

    public int GetPower(){
        return power;
    }

    public void SetPower(int newPower){
        power = newPower;
    }

    public bool GetInvincible(){
        return invincible;
    }

    public void SetInvincible(bool isInvincible){
        if (hasIFrames) invincible = isInvincible;
    }

    public void IFramesTriggered() {
        if (!hasIFrames) return;

        invincible = true;
        StartCoroutine(IFrameEffect());
    }

    IEnumerator IFrameEffect() {
        // Debug.Log("In IFrameEffect");
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
