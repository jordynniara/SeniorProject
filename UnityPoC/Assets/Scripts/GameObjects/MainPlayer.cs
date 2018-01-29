using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : MonoBehaviour, Movement{
	public float speed = 3.5f;
    public GameObject bullet;
    //public Transform bulletSpawn; //for bullet location
    
    //initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		move();
        
        //for shooting bullets
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
	}
    
    public void move()
    {
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.UpArrow))
		{
			transform.position += Vector3.up * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			transform.position += Vector3.down * speed * Time.deltaTime;
		}
    }
    
    public void Fire()
    {
        // Create the Bullet from the Bullet Prefab
        bullet = (GameObject)Instantiate (
            bullet,
            transform.position,
            transform.rotation);

        // Add velocity to the bullet
        

        // Destroy the bullet after 2 seconds
        Destroy(bullet, 5.0f);
    }
}
