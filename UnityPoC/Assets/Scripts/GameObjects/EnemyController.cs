using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {

	public float speed;//speed at which enemies move

    private Vector3 finalPosition; //holds next movement position
    private float xpos; //holds x-coordniate of final position (is randomized)
    private float timer; //timer to control movements
    public float timeToMove = 3; 
    public float timerSpeed = 1; //degree of  which to change frame rate
    public int lives = 1; //Health lives

	// Use this for initialization
	void Start () {
        xpos = Random.Range(-8, 8); //range on x-axis in which enemy can move
        finalPosition = new Vector3(xpos, transform.position.y, transform.position.z); //final position - only moves along x-axis
	}

    //updates at each frame
    private void Update()
    {
        MoveEnemy();

    }

    //translates enemy across axis
    void MoveEnemy()
    { 
       //time til next time to move
        timer += Time.deltaTime * timerSpeed;
        if (timer >= timeToMove)
        {
            //interpolates between original position and final position at speed per sec
            transform.position = Vector3.Lerp(transform.position, finalPosition, Time.deltaTime * speed);
            if (Vector3.Distance(transform.position, finalPosition) <= 0.01f)
            {
                //sprite is on or close to final position
                xpos = Random.Range(-4.5f, 4.5f);//create a new x position
                finalPosition = new Vector3(xpos, transform.position.y, transform.position.z);//create new final pos
                timer = 0.0f;//reset timer
            }
        }
	}

    void Damage()
    {
        lives--;
        if (lives <= 0)
        {
            Destroy(gameObject);
        }
    }
}