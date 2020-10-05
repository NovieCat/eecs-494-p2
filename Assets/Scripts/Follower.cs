using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    public int power = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (power <= 0) {
            GetComponent<FollowTarget>().enabled = false;
            GetComponent<LineToTarget>().enabled = false;
        }
    }

    public int GetPower(){
        return power;
    }

    public void SetPower(int newPower){
        power = newPower;
    }
}
