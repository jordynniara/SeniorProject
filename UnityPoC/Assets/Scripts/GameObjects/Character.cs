using UnityEngine;
using System.Collections;

public abstract class Character : MonoBehaviour
{
    protected bool isEnemy; //denotes whether or not the character is an enemy
    public int lives; //number lives character has left
    public float speed; //speed of character's movement
    public float bulletSpeed; //set speed of bullet through weilding character
    protected Movement movement; //to define character's movement
    public Shoot shootStyle; //to define character's shooting style 
    private float mercyTimer = 0.0f; //used for time between player being hit and when it can get hit again
    private float blinkTimer = 0.0f; //amount of time player will blink for during mercy
    private bool mercy = false; //is player is in mercy
    private bool blink = false; // if player is blinking

    //Removes enemies lives upon bullet collision
    public void Damage()
    {
        if (!mercy)
        {
            lives--;
            if (lives == 0)
            {
                Destroy(gameObject);
            }

            mercy = true;
            mercyTimer = 2.0f;
            blinkTimer = 0.25f;
        }
    }

    public void SpareMe()
    {
        if (mercy)
        {
            mercyTimer -= Time.deltaTime;
            blinkTimer -= Time.deltaTime;

            if (mercyTimer <= 0.0f)
            {
                mercy = false;
                blink = false;
            }
            else if (blinkTimer <= 0.0f)
            {
                blink = !blink;
                blinkTimer = 0.25f;
            }
            GetComponent<SpriteRenderer>().enabled = !blink;
        }
    }


}
