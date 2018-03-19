using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public static int score = 0;
	//public Text scoreLabel;

	//public float scoreDelay = 3f;

	//public GameObject scoreObject;

	// Use this for initialization
	void Awake () {
        //scoreObject = GameObject.Find("Score");
	}
	
	// Update is called once per frame
	void Update () {
		this.GetComponent<TextMesh>().text = "Score: " + score;
	}

    public void DisplayScore()
    {
        this.GetComponent<TextMesh>().anchor = TextAnchor.MiddleCenter;
        this.transform.position = new Vector3(0, 2, this.transform.position.z);
        this.GetComponent<TextMesh>().characterSize = 2;
        this.GetComponent<TextMesh>().alignment = TextAlignment.Center;
    }

//	void DisplayScore() {
//		scoreObject = scoreLabel;
//		scoreObject.SetActive(false);
//	}

}
