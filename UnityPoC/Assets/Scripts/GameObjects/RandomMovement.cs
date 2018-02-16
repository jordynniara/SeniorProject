using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//I guess this one will need some sort of timer and after a certain amount of time changes, just move in a different direction
public class RandomMovement : MonoBehaviour, Movement {
    public float timeToMove;
    public int spawnFreq; //frequency enemy spanws on screen

    //screen boundaries- should not be hard coded
    private const float MIN_Y = 0;
    private const float MAX_Y = 4.30f;
    private const float MIN_X = -5.82f;
    private const float MAX_X = 5.82f;

    Rigidbody2D rb;
    Vector2 movement;//used to generate new random position

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        keepInBounds();
    }

    //keeps characters in bounds - might need to be moved to game manager class
    public void keepInBounds(){
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(transform.position.x, MIN_X, MAX_X);
        pos.y = Mathf.Clamp(transform.position.y, MIN_Y, MAX_Y);
        transform.position = pos;
    }

    public void move(float speed)
    {
        //Generates new position (based on frame rate)
        timeToMove -= Time.deltaTime;
        if (timeToMove <= 0)
        {
            movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            timeToMove += speed;
        }

        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.collider.tag == "Enemy"){
            movement.x *= -1;
            movement.y *= -1;
            rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
        }
            
    }
}
