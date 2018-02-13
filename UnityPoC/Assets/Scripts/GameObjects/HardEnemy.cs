using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardEnemy : Enemy{

    void Start()
    {
        base.initEnemy();

        //set shooting style and bullet prefab
        shootStyle = gameObject.AddComponent(typeof(SingleShoot)) as SingleShoot;
        shootStyle.bullet = (GameObject)Instantiate(Resources.Load("BluePellet"));
        //set bullet speed
        if (bulletSpeed > 0)
            shootStyle.speed = bulletSpeed;
        //set target for bullet to destroy
        shootStyle.damage = gameObject.AddComponent(typeof(PlayerDamage)) as PlayerDamage;
        //Enemy shoot bullet repeatedly
        InvokeRepeating("invokeFire", Random.Range(3, 11), Random.Range(5, 21));

        //set spawnFreq to medium number
    }

    //used for InvokeRepeating in Start()
    private void invokeFire()
    {
        shootStyle.fire(Shoot.SHOOT_DOWNWARD);
    }
	
	// Update is called once per frame
	void Update () 
    {
        movement.move(speed);	
	}
}
