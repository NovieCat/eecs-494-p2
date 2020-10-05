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
        if (Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded()) {
            newVelocity.y = jumpPower;
        }

        rigid.velocity = newVelocity;
    }

    // check if player is grounded
    public bool IsGrounded(){
        Collider col = this.GetComponent<Collider>();

        // Ray from the center of the collider down.
        Ray ray = new Ray(col.bounds.center, Vector3.down);

        // A bit smaller than the actual radius so it doesn't catch on walls.
        float radius = col.bounds.extents.x - .05f;

        // A bit below the bottom
        float fullDistance = col.bounds.extents.y + .05f;
        
        if (Physics.SphereCast(ray, radius, fullDistance)) return true;
        else return false;
    }
}
