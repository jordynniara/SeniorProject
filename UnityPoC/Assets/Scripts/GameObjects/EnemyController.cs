using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {

	private Transform enemies;
	public float speed;
    Vector3 finalPosition;
    private float xpos;
    private float timer;
    public float timeToMove = 3;
    public float timerSpeed = 1;

	// Use this for initialization
	void Start () {
        xpos = Random.Range(-5, 5);
        finalPosition = new Vector3(xpos, transform.position.y, transform.position.z);
		enemies = GetComponent<Transform> ();
	}

    private void Update()
    {
        timer += Time.deltaTime * timerSpeed;
        if (timer >= timeToMove)
        {
            transform.position = Vector3.Lerp(transform.position, finalPosition, Time.deltaTime * speed);
             if (Vector3.Distance(transform.position, finalPosition) <= 0.01f)
            {
                xpos = Random.Range(-4.5f, 4.5f);
                finalPosition = new Vector3(xpos, transform.position.y, transform.position.z);
                timer = 0.0f;
            }
        }
    }

    void MoveEnemy()
	{
        
         // Make the speed dependent on the distance to the targe
        //Using for each causes game to slow down signficantly
        //Need a better way to control bounds
    	//foreach (Transform enemy in enemies) {
    	//	if (enemy.position.x < -10.5 || enemy.position.x > 10.5) {
    	//		speed = -speed;
    	//		return;
    	//	}
    	//}
	}

}