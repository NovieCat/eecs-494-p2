using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rigid;

    public float moveSpeed = 5;
    public float jumpPower = 10;

    void Awake()
    {
        rigid = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newVelocity = rigid.velocity;

        // Horizontal
        newVelocity.x = Input.GetAxis("Horizontal") * moveSpeed;

        // Vertical
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            newVelocity.y = jumpPower;
        }

        rigid.velocity = newVelocity;
    }
}
