using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public static int score = 0;
	public Text scoreLabel;

	//public float scoreDelay = 3f;

	public GameObject scoreObject;

	// Use this for initialization
	void Awake () {
		scoreLabel = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		scoreLabel.text = "Score: " + score;
	}

//	void DisplayScore() {
//		scoreObject = scoreLabel;
//		scoreObject.SetActive(false);
//	}

}
