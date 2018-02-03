using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour {

    public SingleShoot bullet;
	// Use this for initialization
	void Start () {
        bullet = GetComponent<SingleShoot>();
        InvokeRepeating("Attack", Random.Range(3, 11), Random.Range(5, 21));
	}

    void Attack()
    {
        bullet.fire(-1);
    }
}
