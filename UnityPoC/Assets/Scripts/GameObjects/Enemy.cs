using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Character
{
<<<<<<< HEAD
=======
    public float spawnRate; //rate at which enemy type is spawned - increases w/ level 
>>>>>>> e7a2049c5f6908187b1abcf42437694535e4848a
    //initialization
	public int scoreValue = 0;

    public void initEnemy()
    {
        isEnemy = true;
        movement = gameObject.AddComponent(typeof(RandomMovement)) as RandomMovement;
    }

    public void Damage()
    {
        base.Damage();
<<<<<<< HEAD
        if(lives==0)
            Spawn.numEnemiesDestroyed++;
=======
		if (lives == 0) {
			Level.numEnemies--;
			Score.score += scoreValue;
		}
>>>>>>> e7a2049c5f6908187b1abcf42437694535e4848a
    }
}
