using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirection : MonoBehaviour
{
    bool facingRight = true;

    // Update is called once per frame
    void Update()
    {
        
        //Horizontal
        float horizontalAxis = Input.GetAxis("Horizontal");
        if (facingRight && horizontalAxis < 0) {
            facingRight = false;
            this.transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (!facingRight && horizontalAxis > 0) {
            facingRight = true;
            this.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public bool IsFacingRight() {
        return facingRight;
    }
}
