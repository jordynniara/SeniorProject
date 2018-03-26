using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainPlayer : Character
{


    private GameObject livesText;  //text on screen showing lives left
    [SerializeField]
	private GameObject scoreText;
    [SerializeField]
    private GameEnder gameEnder;

    //initialization
	void Start () {
        if (PlayerPrefs.GetInt("modding") == 1)
        {
            lives = PlayerPrefs.GetInt("lives");
            speed = PlayerPrefs.GetFloat("speed");
        }

        scoreText = GameObject.Find("Score");
        livesText = GameObject.Find("Lives");

        //set lives text
        livesText.GetComponent<TextMesh>().text = "x" + lives; 

        //livesText.text = "x " + lives;
        isEnemy = false;
        destroyMask = new CollisionUtil.Mask().addLayer("EnemyBullet");
        //set movement
        movement = gameObject.AddComponent(typeof(KeyboardMovement)) as KeyboardMovement;
        /*
        //set shooting style and bullet prefab
        shootStyle =  gameObject.AddComponent(typeof(SingleShoot)) as SingleShoot;
        shootStyle.bullet = (GameObject)Resources.Load("Snake");

        //set bullet speed
        if (bulletSpeed > 0)
            shootStyle.speed = bulletSpeed;
            */
        //set target for bullet to destroy
        //shootStyle.damage = gameObject.AddComponent(typeof(EnemyDamage)) as EnemyDamage;

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
            shootStyle.fire();
        }
	}

    public override void OnDamage()
    {
        livesText.GetComponent<TextMesh>().text = "x" + lives;

        if (lives == 0)
        {
            GameEnder.gameOver = true;
			gameEnder.EndGame ();
            scoreText.GetComponent<Score>().DisplayScore();
		}
    }


}
