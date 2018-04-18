using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnder : MonoBehaviour {

	//public List<Object> contents;

	public float endDelay = 3.0f;
    public static bool gameOver = false;
    public static bool toLeaderboard = false;
    public HighScore highScore;
	
    // Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (gameOver)
        {
            Score.multiActive = false;
        }
	}

	public void EndGame() {
		Invoke ("End", endDelay);
        //attempt to add score to score high score list
        //if (highScore.NewScoreCheck(Score.score))
            //toLeaderboard = true;
	}

	private void End() {
        if(toLeaderboard)
		    SceneManager.LoadScene("HighScoreInput");
        else
            SceneManager.LoadScene("EndScene");
	}
}
