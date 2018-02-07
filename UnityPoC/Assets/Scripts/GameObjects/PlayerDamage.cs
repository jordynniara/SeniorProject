using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour {
    //inflict damae
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.SendMessage("Damage");//Destroys player and reduces lives

            Destroy(col.otherCollider.gameObject); //Destroys bullet

        }
    }
}
