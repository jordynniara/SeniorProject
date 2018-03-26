using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

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
    protected CollisionUtil.Mask destroyMask;

    public abstract void OnDamage();

    //Removes enemies lives upon bullet collision
    void OnCollisionEnter2D(Collision2D col)
    {
        if (!mercy)
        {

            if (destroyMask.hasLayer(col.gameObject.layer))
            {
                //destroys bullet
                Destroy(col.gameObject);
            }
            lives--;
            if (lives == 0)
            {
                //destroy character
                Destroy(gameObject);
            }

            mercy = true;
            mercyTimer = 2.0f;
            blinkTimer = 0.25f;
            GetComponent<Collider2D>().enabled =  !mercy;
            OnDamage();
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
                GetComponent<Collider2D>().enabled = !mercy;
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
