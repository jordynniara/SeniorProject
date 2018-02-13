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

    //Removes enemies lives upon bullet collision
    public void Damage()
    {
        print("hit!");
        lives--;
        if(lives == 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        
    }

}
