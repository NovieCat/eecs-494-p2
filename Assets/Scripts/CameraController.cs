using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    GameObject currentRoom;
    private Vector3 offset;
    private float cameraXDist; //camera's x axis distance to left of view
    private float cameraYDist; //camera's y axis distance to bottom of view

    // Start is called before the first frame update
    // Referenced from:
    // https://answers.unity.com/questions/230190/how-to-get-the-width-and-height-of-a-orthographic.html
    void Start()
    {
        cameraYDist = GetComponent<Camera>().orthographicSize;
        cameraXDist = cameraYDist * GetComponent<Camera>().aspect;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Room") {
            Debug.Log("Current room: " + other.gameObject.name);
            currentRoom = other.gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        BoxCollider currRoom = player.GetComponent<Player>().GetCurrentRoom().GetComponent<BoxCollider>();
        Vector3 roomOffset = player.GetComponent<Player>().GetCurrentRoom().transform.position;

        float xClampLower = currRoom.center.x - currRoom.size.x/2 + cameraXDist + roomOffset.x;
        float xClampUpper = currRoom.center.x + currRoom.size.x/2 - cameraXDist + roomOffset.x;
        float yClampLower = currRoom.center.y - currRoom.size.y/2 + cameraYDist + roomOffset.y;
        float yClampUpper = currRoom.center.y + currRoom.size.y/2 - cameraYDist + roomOffset.y;
        // Debug.Log("X axis clamped on: " + xClampLower + ", " + xClampUpper);
        // Debug.Log("Y axis clamped on: " + yClampLower + ", " + yClampUpper);

        transform.position = new Vector3(
            Mathf.Clamp(player.transform.position.x, xClampLower, xClampUpper),
            Mathf.Clamp(player.transform.position.y, yClampLower, yClampUpper),
            // player.transform.position.x,
            // player.transform.position.y,
            -10
        );
        // Debug.Log("Camera transform (post): " + transform.position);
    }
}
