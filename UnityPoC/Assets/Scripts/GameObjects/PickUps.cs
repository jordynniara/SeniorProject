﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour
{

    private MainPlayer candice;
    private GameObject livesText;  //text on screen showing lives left
    private GameObject scoreText;
        
    private CollisionUtil.Mask pickUpMask;

    private PickUpCountdown countdown;

    public const int TYPE_SCORE = 1;
    public const int TYPE_DBL_SHOOT = 2;
    public const int TYPE_TRPL_SHOOT = 3;

    public static Shoot oldStyle;


    private class PickUpCountdown
    {
        public bool abilityTimerActive = false; //if the timer for this pickup is running
        private bool destroyReady; //outer class can destroy the pickup
        public float abilityTimer = 5f; //time based ability last 5sec
        public int type; //the type of pickup it is
        private MainPlayer candice;
        public float destroyTimer = 4f; //pickups only stay on screen for 5 sec;
        public bool destroyTimerActive = false;

        public PickUpCountdown(int t) 
        {
            type = t;
        }
        public PickUpCountdown(MainPlayer c)
        {
            candice = c;
        }

        //countdown for if pickup isn't picked up
        public bool destroyCountdown()
        {
            if(destroyTimerActive && !abilityTimerActive)
            {
                destroyTimer -= Time.deltaTime;
            }

            if(destroyTimer <= 0.0f)
            {
                //time to destroy
                return destroyReady = true;
            }
            //not time destroy
            return destroyReady = false;
        }

        //countdown for if pickup is picked up
        public bool abilityCountdown()
        {
            if (abilityTimerActive && !destroyTimerActive)
            {
                abilityTimer -= Time.deltaTime;
            }

            if (abilityTimer <= 0.0f)// when time runs out
            {
                //revert what was changed
                if (type == TYPE_SCORE)
                {
                    revertScore();
                }
                else if (type == TYPE_DBL_SHOOT) 
                {
                    revertShoot(TYPE_DBL_SHOOT);
                }
                else if(type == TYPE_TRPL_SHOOT)
                {
                    revertShoot(TYPE_TRPL_SHOOT);
                }

                //pickup can be fully destroyed now
                return destroyReady = true;
            }
            return destroyReady = false;
        }

        private void revertScore()
        {
            //reset multiplier
            Score.multiplier = 1;

            //reset score text
            Score.multiActive = false;

            abilityTimerActive = false;

        }

        private void revertShoot(int div)
        {
            //get original number of bullets - that's where it will start
            int startIndex = candice.shootStyle.bulletDefs.Count / div;

            //get the number of bullets to remove
            int count = (div == 2) ? startIndex : startIndex * 2; 
            //remove bullets
            candice.shootStyle.bulletDefs.RemoveRange(startIndex, count); 

            abilityTimerActive = false;
        }
    }

    // Use this for initialization
    void Start()
    {
        pickUpMask = new CollisionUtil.Mask().addLayer("Player");

        //Get the game objects from the game board
        candice = GameObject.Find("Candice").GetComponent<MainPlayer>();
        scoreText = GameObject.Find("ScoreText");
        livesText = GameObject.Find("LivesText");

        countdown = new PickUpCountdown(candice);
        countdown.destroyTimerActive = true;

    }

    // Update is called once per frame
    void Update()
    {
        bool destroyReady;
        //only countdown if the timer is currently active
        if (countdown.destroyTimerActive)
        {
             destroyReady = countdown.destroyCountdown();
            //destroy the pickup when the countdown ends
            if (destroyReady)
            {
                Destroy(gameObject);
            }
        }
        else if(countdown.abilityTimerActive)
        {
            destroyReady = countdown.abilityCountdown();
            //destroy the pickup when the countdown ends
            if (destroyReady)
            {
                Destroy(gameObject);
            }
        }
        
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (!pickUpMask.hasLayer(coll.gameObject.layer))
            return;

        switch (this.gameObject.name)
        {
            case "dblShootPickUp(Clone)":
                {
                    countdown.destroyTimerActive = false; // turn off destory timer
                    countdown.type = TYPE_DBL_SHOOT; // set the type of pickup for reversion
                    countdown.abilityTimer = 5f; //set how long the ability should last
                    countdown.abilityTimerActive = true; //turn on the ability timer

                    moreAmmo(1);

                    break;
                }
            case "triShootPickUp(Clone)":
                {
                    countdown.destroyTimerActive = false;
                    countdown.type = TYPE_TRPL_SHOOT;
                    countdown.abilityTimer = 5f;
                    countdown.abilityTimerActive = true;

                    moreAmmo(2);

                    break;
                }
            case "pointMultiPickUp(Clone)":
                
                {
                    countdown.destroyTimerActive = false;
                    countdown.type = TYPE_SCORE;
                    countdown.abilityTimer = 8f;
                    countdown.abilityTimerActive = true;

                    //multiply the score by 2
                    Score.multiplier *= 2;

                    //to change score text w/ multiplier
                    Score.multiActive = true;

                    break;
                }
            case "exLivesPickUp(Clone)":
                {
                    countdown.destroyTimerActive = false;

                    //not timer based so can be destoryed immediately
                    Destroy(this.GetComponent<GameObject>());

                    //get the current lives, increase and display
                    candice.lives++;

                    livesText.GetComponent<TextMesh>().text = "x" + candice.lives;
                    break;
                }
        }

        //if it hasn't already been destroyed
        if(this != null)
        {
            //remove the sprite and the box collider - keep object for the ability timer
            this.GetComponent<SpriteRenderer>().enabled = false;
            this.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    public void moreAmmo(int multi)
    {
        int currentNumBullets = oldStyle.bulletDefs.Count;
        float direction = oldStyle.bulletDefs[0].direction;

        //TODO: FIX ANGLING
        float degreeChange = 30 / multi;

        //add multi times current number of bullets (ie: if current =3 add either 3 more or 6 more bullets)
        for (int i = 0; i < currentNumBullets * multi; i++)
        {
            //create new bullet definition
            Shoot.BulletDef bulletDef = new Shoot.BulletDef((new Vector2(.2f, 0f)),
                                                            (direction - degreeChange), //angle bullet 30 degrees from the last
                                                            candice.bulletSpeed,
                                                            oldStyle.bulletDefs[0].bullet);
            //add new bullet definition
            candice.shootStyle.bulletDefs.Add(bulletDef);

            //for next angling
            degreeChange *= -1;
        }
    }
}