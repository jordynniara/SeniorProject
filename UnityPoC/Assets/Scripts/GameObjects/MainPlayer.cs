using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : Character{

    //initialization
	void Start () {
        lives = 1;
        isEnemy = false;

        //set movement
        movement = gameObject.AddComponent(typeof(KeyboardMovement)) as KeyboardMovement;

        //set shooting style and bullet prefab
        shootStyle =  gameObject.AddComponent(typeof(SingleShoot)) as SingleShoot;
        shootStyle.bullet = (GameObject)Instantiate(Resources.Load("PinkPellet"));
        //set bullet speed
        if (bulletSpeed > 0)
            shootStyle.speed = bulletSpeed;

        //set target for bullet to destroy
        shootStyle.damage = gameObject.AddComponent(typeof(EnemyDamage)) as EnemyDamage;
	}
	
	// Update is called once per frame
	void Update () {
        //move the character
        movement.move(speed);

        //for shooting bullets
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shootStyle.fire(Shoot.SHOOT_UPWARD);
        }
	}
    
}
