using UnityEngine;
using System.Collections;
using System;

//Client class of Bullet. Single pellet style shooting
public class SingleShoot : Shoot
{
    //move bullet accross screen
    public override void fire(int direction)
    {
        // Create the Bullet from the Bullet Prefab
        GameObject newBullet = (GameObject)Instantiate(bullet,
                                                       transform.position,
                                                       transform.rotation);
        

        // move the bullet
        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, direction*speed);

        // Destroy the bullet after 2 seconds
        Destroy(newBullet, 2.0f);
    }


}
