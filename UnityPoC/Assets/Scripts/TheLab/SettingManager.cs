using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
//using UnityEditor;
using UnityEngine.SceneManagement;

public class SettingManager : MonoBehaviour {

	public static bool changeNumLives = true;

	public Dropdown speedDropdown;
	public Dropdown shootStyleDropdown;
	public Dropdown livesDropdown;
	public Dropdown musicDropdown;
	public Dropdown spriteDropdown;

	public GameSettings gameSettings;

	AudioSource myAudio;
	Sprite sprite;

	void OnEnable() {
        gameSettings = gameObject.AddComponent(typeof(GameSettings)) as GameSettings;;
		speedDropdown.onValueChanged.AddListener (delegate { OnSpeedChange (); });
		shootStyleDropdown.onValueChanged.AddListener (delegate { OnShootStyleChange (); });
		livesDropdown.onValueChanged.AddListener (delegate { OnLivesChange (); });
		musicDropdown.onValueChanged.AddListener(delegate { OnMusicChange(); });
		spriteDropdown.onValueChanged.AddListener(delegate { OnSpriteChange(); });

	}

	public void OnSpriteChange() {

		sprite = GetComponent<Sprite> ();
		Sprite[] sheet = null;
		Sprite newSprite = null;

		switch (spriteDropdown.value) {
		case 1:
			sheet = Resources.LoadAll<Sprite> ("Females/Girl1");
			newSprite = sheet [2];
			GameSettings.player.Add (newSprite);
			newSprite = sheet [0];
			GameSettings.bodyIcon.Add (newSprite);
			break;
		case 2:
			sheet = Resources.LoadAll<Sprite>("Females/Girl2");
			newSprite = sheet[2];
			GameSettings.player.Add(newSprite);
			newSprite = sheet [0];
			GameSettings.bodyIcon.Add (newSprite);
			break;
		case 3:
			sheet = Resources.LoadAll<Sprite>("Females/Girl3");
			newSprite = sheet[2];
			GameSettings.player.Add(newSprite);
			newSprite = sheet [0];
			GameSettings.bodyIcon.Add (newSprite);
			break;
		case 4:
		    sheet = Resources.LoadAll<Sprite>("Females/Girl4");
			newSprite = sheet[2];
			GameSettings.player.Add(newSprite);
			newSprite = sheet [0];
			GameSettings.bodyIcon.Add (newSprite);
			break;
		case 5:
			sheet = Resources.LoadAll<Sprite>("Females/Girl5");
			newSprite = sheet[2];
			GameSettings.player.Add(newSprite);
			newSprite = sheet [0];
			GameSettings.bodyIcon.Add (newSprite);
			break;
		case 6:
			sheet = Resources.LoadAll<Sprite>("Females/Girl6");
			newSprite = sheet[2];
			GameSettings.player.Add(newSprite);
			newSprite = sheet [0];
			GameSettings.bodyIcon.Add (newSprite);
			break;
		case 7:
			sheet = Resources.LoadAll<Sprite>("Males/Boy1");
			newSprite = sheet[2];
			GameSettings.player.Add(newSprite);
			newSprite = sheet [0];
			GameSettings.bodyIcon.Add (newSprite);
			break;
		case 8:
			sheet = Resources.LoadAll<Sprite>("Males/Boy2");
			newSprite = sheet[2];
			GameSettings.player.Add(newSprite);
			newSprite = sheet [0];
			GameSettings.bodyIcon.Add (newSprite);
			break;
		case 9:
			sheet = Resources.LoadAll<Sprite>("Males/Boy3");
			newSprite = sheet[2];
			GameSettings.player.Add(newSprite);
			newSprite = sheet [0];
			GameSettings.bodyIcon.Add (newSprite);
			break;
		case 10:
			sheet = Resources.LoadAll<Sprite>("Males/Boy4");
			newSprite = sheet[2];
			GameSettings.player.Add(newSprite);
			newSprite = sheet [0];
			GameSettings.bodyIcon.Add (newSprite);
			break;
		case 11:
			sheet = Resources.LoadAll<Sprite>("Males/Boy5");
			newSprite = sheet[2];
			GameSettings.player.Add(newSprite);
			newSprite = sheet [0];
			GameSettings.bodyIcon.Add (newSprite);
			break;
		case 12:
			sheet = Resources.LoadAll<Sprite>("Males/Boy6");
			newSprite = sheet[2];
			GameSettings.player.Add(newSprite);
			newSprite = sheet [0];
			GameSettings.bodyIcon.Add (newSprite);
			break;
		}
		Debug.Log (newSprite);
	}

	public void OnMusicChange() {

		myAudio = GetComponent<AudioSource> ();
		AudioClip clip = null;

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
		Debug.Log (clip);
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
		case 0:
			PlayerPrefs.SetFloat ("speed", 5.0f);
			break;
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
		case 0:
			PlayerPrefs.SetInt ("lives", 3);
			break;
		case 1:
			PlayerPrefs.SetInt ("lives", 1);
			break;
		case 2:
			PlayerPrefs.SetInt ("lives", 2);
			break;
		case 3:
			PlayerPrefs.SetInt ("lives", 3);
			break;
		case 4:
			changeNumLives = false;
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