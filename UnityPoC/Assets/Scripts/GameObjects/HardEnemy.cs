using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardEnemy : Enemy{


    void Start()
    {
        base.initEnemy();

        //set shooting style and bullet prefab
        /*
        shootStyle = gameObject.AddComponent(typeof(SingleShoot)) as SingleShoot;

        if(this.name.Contains("Professor"))
        {
            shootStyle.bullet = (GameObject)Resources.Load("Assignment");
        }else if(name.Contains(("Admin")))
        {
            shootStyle.bullet = (GameObject)Resources.Load("Fees s");
        }

        //set bullet speed
        if (bulletSpeed > 0)
            shootStyle.speed = bulletSpeed;*/
        //set target for bullet to destroy
		
        //shootStyle.damage = gameObject.AddComponent(typeof(PlayerDamage)) as PlayerDamage;
        //Enemy shoot bullet repeatedly
        InvokeRepeating("invokeFire", Random.Range(1, 3), Random.Range(3, 5));
    }

    //used for InvokeRepeating in Start()
    private void invokeFire()
    {
        shootStyle.fire();
    }
	
	// Update is called once per frame
	void Update () 
    {
        movement.move(speed);	

        SpareMe();
	}
}
