using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
//using UnityEditor;
using UnityEngine.SceneManagement;

public class SettingManager : MonoBehaviour {
    public AudioSource audio;
	public Dropdown speedDropdown;
	public Dropdown shootStyleDropdown;
	public Dropdown livesDropdown;
	public Button spriteBrowse;

	public GameSettings gameSettings;

	void OnEnable() {
        gameSettings = gameObject.AddComponent(typeof(GameSettings)) as GameSettings;;

		speedDropdown.onValueChanged.AddListener (delegate { OnSpeedChange (); });
		shootStyleDropdown.onValueChanged.AddListener (delegate { OnShootStyleChange (); });
		livesDropdown.onValueChanged.AddListener (delegate { OnLivesChange (); });
		//spriteBrowse.onClick.AddListener (delegate { BrowseMethod (); });

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
        audio.Play();
	}

	public void BrowseMethod() {
//		string path = EditorUtility.OpenFilePanel("Overwrite with png", "", "png");
//		if (path.Length != 0)
//		{
//			gameSettings.sprite = path;
//			//			var fileContent = File.ReadAllBytes(path);
//			//			texture.LoadImage(fileContent);
//		}
	}

	public void saveSettings() {
		switch (gameSettings.speed) {
		case 0:
			PlayerPrefs.SetFloat ("speed", 3.0f);
			break;
		case 1:
			PlayerPrefs.SetFloat ("speed", 5.0f);
			break;
		case 2:
			PlayerPrefs.SetFloat ("speed", 7.0f);
			break;
		}

		switch (gameSettings.lives) {
		case 0:
			PlayerPrefs.SetInt ("lives", 1);
			break;
		case 1:
			PlayerPrefs.SetInt ("lives", 2);
			break;
		case 2:
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
