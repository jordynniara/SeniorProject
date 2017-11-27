using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//So basically in the move method, we need to check if whatever arrow key/wasd whatever you want is pressed, then move this object in that direction
public class KeyboardMovement : MonoBehaviour, Movement{
	public float speed = 3.5f;
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

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        move();
	}
}
