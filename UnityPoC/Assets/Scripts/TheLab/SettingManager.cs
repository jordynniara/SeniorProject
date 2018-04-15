using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
//using UnityEditor;
using UnityEngine.SceneManagement;

public class SettingManager : MonoBehaviour {
	public Dropdown speedDropdown;
	public Dropdown shootStyleDropdown;
	public Dropdown livesDropdown;
	public Dropdown musicDropdown;
	public Button spriteBrowse;

	public GameSettings gameSettings;

	AudioSource myAudio;

	void OnEnable() {
        gameSettings = gameObject.AddComponent(typeof(GameSettings)) as GameSettings;;

		speedDropdown.onValueChanged.AddListener (delegate { OnSpeedChange (); });
		shootStyleDropdown.onValueChanged.AddListener (delegate { OnShootStyleChange (); });
		livesDropdown.onValueChanged.AddListener (delegate { OnLivesChange (); });
		musicDropdown.onValueChanged.AddListener(delegate { OnMusicChange(); });

	}

	public void OnMusicChange() {

		myAudio = GetComponent<AudioSource> ();
		AudioClip clip;

		switch (musicDropdown.value) {
		case 1:
			clip = Resources.Load<AudioClip>("DeepInTheCavesBelow");
			GameSettings.music.Add(clip);
			break;
		case 2:
			clip = Resources.Load<AudioClip>("FightForYourLives");
			GameSettings.music.Add(clip);
			break;
		case 3:
			clip = Resources.Load<AudioClip>("GoingUp");
			GameSettings.music.Add(clip);
			break;
		case 4:
			clip = Resources.Load<AudioClip>("YetAnotherJourney");
			GameSettings.music.Add(clip);
			break;

		}
	}

	public void OnSpeedChange() {
		gameSettings.speed = speedDropdown.value;


	}

	public void OnShootStyleChange() {
		gameSettings.shootStyle = shootStyleDropdown.value;
	}

	public void OnLivesChange() {
		gameSettings.lives = livesDropdown.value;
	}

	public void ExitMethod() {
		SceneManager.LoadScene("MainMenu");

	}

	public void saveSettings() {
		switch (gameSettings.speed) {
		case 1:
			PlayerPrefs.SetFloat ("speed", 3.0f);
			break;
		case 2:
			PlayerPrefs.SetFloat ("speed", 5.0f);
			break;
		case 3:
			PlayerPrefs.SetFloat ("speed", 7.0f);
			break;
		}

		switch (gameSettings.lives) {
		case 1:
			PlayerPrefs.SetInt ("lives", 1);
			break;
		case 2:
			PlayerPrefs.SetInt ("lives", 2);
			break;
		case 3:
			PlayerPrefs.SetInt ("lives", 3);
			break;
		}

		PlayerPrefs.Save ();
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
xs