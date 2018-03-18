using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Character
{
	public int scoreValue = 0;

    public void initEnemy()
    {
        isEnemy = true;
        movement = gameObject.AddComponent(typeof(RandomMovement)) as RandomMovement;
    }

    public void Damage()
    {
        base.Damage();
		if (lives == 0) {
            Spawn.numEnemiesDestroyed++;
			Score.score += scoreValue;
		}
    }
}
