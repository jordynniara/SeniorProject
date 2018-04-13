using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnder : MonoBehaviour {

	public List<Object> contents;

	public float endDelay = 3.0f;
    public static bool gameOver = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (gameOver)
        {
            Spawn.spawnEnabled = false;
            Score.multiActive = false;
        }
            
            //contents.Add(FindObjectOfType(typeof(Character)));
		
	}

	public void EndGame() {
		Invoke ("End", endDelay);
		//foreach (GameObject obj in contents)
			//Destroy (obj);

	}

	private void End() {
		SceneManager.LoadScene("EndScene");
        //GameObject scoreObject = GameObject.Find("Score");
        //scoreObject.GetComponent<TextMesh>().text = "Score: " + Score.score;
	}
}
