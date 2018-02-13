using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shoot:MonoBehaviour
{
    public float speed=3;
    public GameObject bullet; //to set bullet prefab
    public Damage damage; //to set damage type

    public const int SHOOT_DOWNWARD = -1;
    public const int SHOOT_UPWARD = 1;


    public virtual void fire(int direction)//1 is up -1 is down
    {
        //to be overridden by child classes
    }
}
