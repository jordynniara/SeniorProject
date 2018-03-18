using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainPlayer : Character{

    public Text livesText;  //text on screen showing lives left
	public Text scoreText;
	public GameEnder gameEnder;

    //initialization
	void Start () {
        if (PlayerPrefs.GetInt("modding") == 1)
        {
            lives = PlayerPrefs.GetInt("lives");
            speed = PlayerPrefs.GetFloat("speed");
        }
        livesText.text = "x " + lives;
        isEnemy = false;

        //set movement
        movement = gameObject.AddComponent(typeof(KeyboardMovement)) as KeyboardMovement;

        //set shooting style and bullet prefab
        shootStyle =  gameObject.AddComponent(typeof(SingleShoot)) as SingleShoot;
        shootStyle.bullet = (GameObject)Resources.Load("Snake");
        //set bullet speed
        if (bulletSpeed > 0)
            shootStyle.speed = bulletSpeed;

        //set target for bullet to destroy
        shootStyle.damage = gameObject.AddComponent(typeof(EnemyDamage)) as EnemyDamage;

        print("lives" + lives);
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
            shootStyle.fire(Shoot.SHOOT_UPWARD);
        }
	}

    public new void Damage()
    {
		base.Damage();
        livesText.text = "x " + lives;

        if (lives == 0)
        {
			gameEnder.EndGame ();
	        scoreText.transform.position = new Vector3(0, 0, scoreText.transform.position.z);
			scoreText.fontSize = 300;
			scoreText.alignment = TextAnchor.MiddleCenter;
		}
    }


}
