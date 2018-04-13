using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot:MonoBehaviour
{

    
    [System.Serializable]
    public struct BulletDef
    {
        public Vector2 offset;
        public float direction;
        public float speed;
        public GameObject bullet;

        public BulletDef(Vector2 offset, float dir, float speed, GameObject bull)
        {
            this.offset = offset;
            direction = dir;
            this.speed = speed;
            bullet = bull;
        }

        public Vector2 directionAsVector()
        {
            return new Vector2(Mathf.Cos(direction * Mathf.Deg2Rad), Mathf.Sin(direction * Mathf.Deg2Rad));
        }
    }

    public Shoot(BulletDef bd)
    {
        bulletDefs.Add(bd);
    }


    public List<BulletDef> bulletDefs;
    //public Damage damage; //to set damage type

    public void fire()
    {
        foreach (BulletDef bulletDef in bulletDefs) 
        {
            // Create the Bullet from the Bullet Prefab
            GameObject newBullet = (GameObject)Instantiate(bulletDef.bullet,
                                                           transform.position + (Vector3)bulletDef.offset,
                                                           transform.rotation);

            // move the bullet
            newBullet.GetComponent<Rigidbody2D>().velocity = bulletDef.directionAsVector() * bulletDef.speed;

            // Destroy the bullet after 4 seconds
            Destroy(newBullet, 4.0f);
        }
    }
}
