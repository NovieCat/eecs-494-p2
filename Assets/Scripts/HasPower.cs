using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasPower : MonoBehaviour
{
    public int power = 1;

    public int GetPower(){
        return power;
    }

    public void SetPower(int newPower){
        power = newPower;
    }
}
