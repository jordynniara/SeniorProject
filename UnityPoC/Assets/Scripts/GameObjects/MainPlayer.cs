using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainPlayer : Character{

    private float mercyTimer = 0.0f;
    private float blinkTimer = 0.0f;
    private bool mercy = false;
    private bool blink = false;
    public Text livesText;

    //initialization
	void Start () {
		lives = PlayerPrefs.GetInt ("lives");
		speed = PlayerPrefs.GetFloat ("speed");
        livesText.text = "x " + lives;
        isEnemy = false;

        //set movement
        movement = gameObject.AddComponent(typeof(KeyboardMovement)) as KeyboardMovement;

        //set shooting style and bullet prefab
        shootStyle =  gameObject.AddComponent(typeof(SingleShoot)) as SingleShoot;
        shootStyle.bullet = (GameObject)Resources.Load("PinkPellet");
        //set bullet speed
        if (bulletSpeed > 0)
            shootStyle.speed = bulletSpeed;

        //set target for bullet to destroy
        shootStyle.damage = gameObject.AddComponent(typeof(EnemyDamage)) as EnemyDamage;
	}
	
	// Update is called once per frame
	void Update () {
        //move the character
        movement.move(speed);


        if (mercy)
        {
            mercyTimer -= Time.deltaTime;
            blinkTimer -= Time.deltaTime;
            
            if (mercyTimer <= 0.0f) {
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
        //for shooting bullets
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shootStyle.fire(Shoot.SHOOT_UPWARD);
        }
	}

    public new void Damage()
    {
        if (!mercy)
        {
            base.Damage();
            livesText.text = "x " + lives;
            if (lives == 0)
            {

                SceneManager.LoadScene("MainMenu");
            }
            mercy = true;
            mercyTimer = 2.0f;
            blinkTimer = 0.25f;
        }
    }

}
