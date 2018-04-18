using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainPlayer : Character
{

    [SerializeField]
    private GameObject livesText;  //text on screen showing lives left
    [SerializeField]
    private GameEnder gameEnder;

    public GameObject bulletType;
  
    //initialization
	void Start () {
        

        //set mods
        if (PlayerPrefs.GetInt("modding") == 1)
        {
            lives = PlayerPrefs.GetInt("lives");
            speed = PlayerPrefs.GetFloat("speed");
            if (GameSettings.playerBullets != null && GameSettings.playerBullets.Count > 0)
            {
                
                shootStyle = this.gameObject.AddComponent<Shoot>();
                
                foreach (var bulletDef in GameSettings.playerBullets)
                {
                    Shoot.BulletDef bd = new Shoot.BulletDef(bulletDef.offset, bulletDef.direction, bulletDef.speed, bulletType);
                    shootStyle.bulletDefs.Add(bd);
                }
            }
        }

        livesText = GameObject.Find("LivesText");

        //set lives text
        livesText.GetComponent<TextMesh>().text = "x" + lives; 

        isEnemy = false;
        destroyMask = new CollisionUtil.Mask().addLayer("EnemyBullet");

        //set movement
        movement = gameObject.AddComponent(typeof(KeyboardMovement)) as KeyboardMovement;

        //pass original shooting style to pickups
        PickUps.oldStyle = shootStyle;
	}
	
	// Update is called once per frame
	void Update () {
        //move the character
        movement.move(speed);

        //Blink if hit a
        SpareMe();

        //for shooting bullets
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shootStyle.fire();
        }
	}

	protected void OnCollisionEnter2D(Collision2D col)
	{
        if (!mercy && destroyMask.hasLayer(col.gameObject.layer))
        {
            //destroys bullet
            Destroy(col.gameObject);
            lives--;
            base.OnCollisionEnter2D(col);
        }
	}

	public override void OnDamage()
    {
        livesText.GetComponent<TextMesh>().text = "x" + lives;

        if (lives == 0)
        {
            GameEnder.gameOver = true;
			gameEnder.EndGame ();
		}
    }


}
