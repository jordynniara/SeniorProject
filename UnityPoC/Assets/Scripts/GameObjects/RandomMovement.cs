using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//I guess this one will need some sort of timer and after a certain amount of time changes, just move in a different direction
public class RandomMovement : MonoBehaviour, Movement {
    private Vector3 finalPosition; //holds next movement position
    private float xpos; //holds x-coordniate of final position (is randomized)
    private float timer; //timer to control movements
    public float timeToMove;
    public float timerSpeed; //degree of  which to change frame rate
    public int spawnFreq; //frequency enemy spanws on screen

    // Use this for initialization
    void Start()
    {
        timeToMove = 1;
        timerSpeed = 1; //degree of  which to change frame rate
        xpos = Random.Range(-5, 5); //range on x-axis in which enemy can move
        finalPosition = new Vector3(xpos, transform.position.y, transform.position.z); //final position - only moves along x-axis
    }

    // Update is called once per frame
    void Update()
    {
        //move();
    }

    public void move(float speed)
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
}
