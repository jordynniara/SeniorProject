using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeEnemy : Enemy {


	// Use this for initialization
    void Start()
    {
        //init enemy from base class
        base.initEnemy();

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
