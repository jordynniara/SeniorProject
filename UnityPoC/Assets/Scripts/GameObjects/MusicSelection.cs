using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSelection : MonoBehaviour {

	public AudioSource backgroundMusic;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt ("modding") == 1) {
			backgroundMusic.clip = GameSettings.music [GameSettings.music.Count-1];
			backgroundMusic.Play ();
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
