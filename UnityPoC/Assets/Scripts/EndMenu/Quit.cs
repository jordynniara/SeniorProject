using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour {

    public AudioSource audio;
	void OnMouseUpAsButton () {
		Application.Quit();	
		Debug.Log("Game is exiting");
        audio.Play();
	}
}
