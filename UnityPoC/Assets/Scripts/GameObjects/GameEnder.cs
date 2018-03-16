using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnder : MonoBehaviour {

	public List<GameObject> contents;

	public float endDelay = 3.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void EndGame() {
		Invoke ("End", endDelay);
		foreach (GameObject obj in contents)
			Destroy (obj);

	}

	private void End() {
		SceneManager.LoadScene("EndScene");

	}
}
