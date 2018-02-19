using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour {

	public Dropdown speedDropdown;
	public Dropdown shootStyleDropdown;
	public Dropdown livesDropdown;

	public GameSettings gameSettings;

	void OnEnable() {
		gameSettings = new GameSettings ();

		speedDropdown.onValueChanged.AddListener (delegate { OnSpeedChange (); });
		shootStyleDropdown.onValueChanged.AddListener (delegate { OnShootStyleChange (); });
		livesDropdown.onValueChanged.AddListener (delegate { OnLivesChange (); });
			

	}

	public void OnSpeedChange() {
		gameSettings.speed = speedDropdown.value;


	}

	public void OnShootStyleChange() {
		gameSettings.shootStyle = shootStyleDropdown.value;
	}

	public void OnLivesChange() {
		gameSettings.lives = shootStyleDropdown.value;
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
		print ("Set speed to " + PlayerPrefs.GetFloat("speed"));
		PlayerPrefs.Save ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
