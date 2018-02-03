using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : MonoBehaviour{
    [SerializeField]
    private SingleShoot bullet;

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
    
}
