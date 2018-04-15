using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSelection : MonoBehaviour {

	public AudioSource backgroundMusic;

	// Use this for initialization
	void Start () {
//		Debug.Log ("modding: " + PlayerPrefs.GetInt("modding"));
//		Debug.Log("lives: " + PlayerPrefs.GetInt("lives"));
//		Debug.Log("speed: " + PlayerPrefs.GetFloat("speed"));

		if (PlayerPrefs.GetInt ("modding") == 1) {
			backgroundMusic.clip = GameSettings.music [0];
			backgroundMusic.Play ();
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
