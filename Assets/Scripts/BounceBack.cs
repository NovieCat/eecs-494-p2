using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBack : MonoBehaviour
{
    public float knockback_power = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionStay(Collision collisionInfo)
    {
        Debug.Log("Got collision with: " + collisionInfo.gameObject.tag);
        if (collisionInfo.gameObject.tag == "Player") return;
        
        /* Perform Knockback (code snippet from lecture example) */
        Rigidbody other_rb = collisionInfo.gameObject.GetComponentInParent<Rigidbody>();
        if(other_rb != null)
        {
            if (other_rb.transform.position.x > transform.position.x) {
                other_rb.velocity = new Vector3(1, 0, 0) * knockback_power;
            }
            else if (other_rb.transform.position.x < transform.position.x) {
                other_rb.velocity = new Vector3(-1, 0, 0) * knockback_power;
            }
        }
    }
}
