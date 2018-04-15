using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnder : MonoBehaviour {

	//public List<Object> contents;

	public float endDelay = 3.0f;
    public static bool gameOver = false;
	
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (gameOver)
        {
            Score.multiActive = false;
        }
		
	}

	public void EndGame() {
		Invoke ("End", endDelay);

	}

	private void End() {
		SceneManager.LoadScene("EndScene");
	}
}
