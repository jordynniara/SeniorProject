using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Character
{
	public int scoreValue = 0;
    public int modValue;

    public GameObject bulletType;

    public void initEnemy()
    {
        isEnemy = true;
        movement = gameObject.AddComponent(typeof(RandomMovement)) as RandomMovement;
        destroyMask = new CollisionUtil.Mask().addLayer("PlayerBullet");

        if (PlayerPrefs.GetInt("modding") == 1)
        {

            if (GameSettings.lives[modValue] > 0)
                lives = GameSettings.lives[modValue];
            if (GameSettings.speedValues[modValue] > 0.0f)
                speed = GameSettings.speedValues[modValue];
            if (GameSettings.shotTypes[modValue] != null)
            {

                shootStyle = this.gameObject.AddComponent<Shoot>();

                foreach (var bulletDef in GameSettings.shotTypes[modValue])
                {
                    Shoot.BulletDef bd = new Shoot.BulletDef(bulletDef.offset, bulletDef.direction, bulletDef.speed, bulletType);
                    shootStyle.bulletDefs.Add(bd);
                }
            }
        }
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
