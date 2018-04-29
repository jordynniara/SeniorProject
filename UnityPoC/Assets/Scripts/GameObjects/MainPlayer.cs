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
	private GameObject infinityText;
    [SerializeField]
    private GameEnder gameEnder;

    public GameObject bulletType;
  
    //initialization
	void Start () {
        

        //set mods
        if (PlayerPrefs.GetInt("modding") == 1)
        {
            lives = GameSettings.lives[0];
            speed = GameSettings.speedValues[0];
            if (GameSettings.shotTypes[0] != null)
            {
                
                shootStyle = this.gameObject.AddComponent<Shoot>();

                foreach (var bulletDef in GameSettings.shotTypes[0])
                {
                    Shoot.BulletDef bd = new Shoot.BulletDef(bulletDef.offset, bulletDef.direction, bulletDef.speed, bulletType);
                    shootStyle.bulletDefs.Add(bd);
                }
            }
        }

        livesText = GameObject.Find("LivesText");

        //set lives text
		if (SettingManager.changeNumLives) {
			livesText.GetComponent<TextMesh> ().text = "x" + lives; 
			infinityText.gameObject.SetActive (false);
		} 
		else {
            // for infinite lives
			livesText.GetComponent<TextMesh> ().text = "x";
		}

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

        //Blink if hit
		SpareMe ();

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

			if (SettingManager.changeNumLives) {
				lives--;
			}

            base.OnCollisionEnter2D(col);
        }
	}

	public override void OnDamage()
    {
		if (SettingManager.changeNumLives) {
			livesText.GetComponent<TextMesh> ().text = "x" + lives;
		}
		else {
			livesText.GetComponent<TextMesh> ().text = "x";
		}

        if (lives == 0)
        {
            GameEnder.gameOver = true;
			gameEnder.EndGame ();
		}
    }


}
