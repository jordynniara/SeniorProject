using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSelection : MonoBehaviour {

	public AudioSource backgroundMusic;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt ("modding") == 1) {
			try {
				backgroundMusic.clip = GameSettings.music [GameSettings.music.Count-1];
				backgroundMusic.Play ();
			}
			catch (Exception e) {
				Debug.Log (e.Message);
			}
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
