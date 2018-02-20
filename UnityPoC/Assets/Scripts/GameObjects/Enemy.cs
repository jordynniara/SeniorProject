using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Character
{
    //initialization
    public void initEnemy()
    {
        lives = 1;
        isEnemy = true;
        movement = gameObject.AddComponent(typeof(RandomMovement)) as RandomMovement;
    }
}
