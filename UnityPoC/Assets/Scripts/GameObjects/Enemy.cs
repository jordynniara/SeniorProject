using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Character
{
    //initialization
    public void initEnemy()
    {
        isEnemy = true;
        movement = gameObject.AddComponent(typeof(RandomMovement)) as RandomMovement;
    }
}
