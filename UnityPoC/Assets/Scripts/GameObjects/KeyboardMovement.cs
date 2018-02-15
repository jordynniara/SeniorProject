using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//So basically in the move method, we need to check if whatever arrow key/wasd whatever you want is pressed, then move this object in that direction
public class KeyboardMovement : MonoBehaviour, Movement{
    //screen boundaries-should not be hard coded
    private const float MIN_Y = -4.30f;
    private const float MAX_Y = 4.30f;
    private const float MIN_X = -5.82f;
    private const float MAX_X = 5.82f;

    public void move(float speed)
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

    //keeps characters in bounds
    public void keepInBounds()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(transform.position.x, MIN_X, MAX_X);
        pos.y = Mathf.Clamp(transform.position.y, MIN_Y, 0);
        transform.position = pos;
        print(pos);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        keepInBounds();
	}


}
