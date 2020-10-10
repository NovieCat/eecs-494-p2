using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Color change referenced from:
// https://answers.unity.com/questions/209573/how-to-change-material-color-of-an-object.html
public class Follower : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite neutralizedSprite;

    // Start is called before the first frame update
    void Start()
    {
        // gameObject.GetComponent<Renderer>().material.color = Color.cyan;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<HasPower>().GetPower() <= 0) {
            StopFollowing();
            GetComponent<Rigidbody>().useGravity = true;
            spriteRenderer.sprite = neutralizedSprite;
            transform.Find("HealthText").gameObject.SetActive(false);

            if (GetComponent<Rigidbody>().velocity == Vector3.zero) {
                GetComponent<SphereCollider>().enabled = true;
            }
        }
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Player") {
            if (GetComponent<HasPower>().GetPower() != 0) {
                // Game Over
                StopFollowing();
                collisionInfo.gameObject.GetComponent<HasPower>().SetPower(0);
            }
        }
    }

    void StopFollowing(){
        GetComponent<FollowTarget>().enabled = false;
        GetComponent<LineToTarget>().RemoveLine();
        GetComponent<LineToTarget>().enabled = false;
    }
}
