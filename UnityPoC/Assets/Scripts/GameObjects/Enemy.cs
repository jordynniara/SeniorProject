using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Character
{
    public float spawnRate; //rate at which enemy type is spawned - increases w/ level
    //initialization
    public void initEnemy()
    {
        isEnemy = true;
        movement = gameObject.AddComponent(typeof(RandomMovement)) as RandomMovement;
    }

    public void Damage()
    {
        base.Damage();
        if(lives==0)
            Level.numEnemies--;
    }
}
