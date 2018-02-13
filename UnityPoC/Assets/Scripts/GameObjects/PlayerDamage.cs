using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage:Damage
{
    private void Start()
    {
        target = "Player";
    }

    //inflict damae
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == target)
        {
            col.gameObject.SendMessage("Damage");//Destroys player and reduces lives

            Destroy(col.otherCollider.gameObject); //Destroys bullet

        }
    }
}

