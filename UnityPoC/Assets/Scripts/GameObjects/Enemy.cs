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
        destroyMask = new CollisionUtil.Mask().addLayer("PlayerBullet");
    }

    protected void OnCollisionEnter2D(Collision2D col)
    {
        if (!mercy && destroyMask.hasLayer(col.gameObject.layer))
        {
            //destroys bullet
            Destroy(col.gameObject);
            lives--;
            base.OnCollisionEnter2D(col);
        }
    }

    public override void OnDamage()
    {
		if (lives == 0) {
            Spawn.numEnemiesDestroyed++;
            Score.UpdateScore(scoreValue);
		}
    }
}
