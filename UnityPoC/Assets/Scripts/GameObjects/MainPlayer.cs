using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : MonoBehaviour{
    [SerializeField]
    private SingleShoot bullet;
    private int  lives = 3;

    //initialization
	void Start () {
        bullet = GetComponent<SingleShoot>();
	}
	
	// Update is called once per frame
	void Update () {
        //for shooting bullets
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bullet.fire(1);
        }
	}

    void Damage(){

        lives--;
        if (lives <= 0)
        {
            Destroy(gameObject);
        }
    }
    
}
