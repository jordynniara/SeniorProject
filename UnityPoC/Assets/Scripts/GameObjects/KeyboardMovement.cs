using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//So basically in the move method, we need to check if whatever arrow key/wasd whatever you want is pressed, then move this object in that direction
public class KeyboardMovement : MonoBehaviour, Movement {
    public float speed;
    public void move()
    {
        
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        move();
	}
}
