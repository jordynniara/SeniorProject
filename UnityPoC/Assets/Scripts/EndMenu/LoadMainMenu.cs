using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMainMenu : MonoBehaviour {

	void OnMouseUpAsButton()
	{
		SceneManager.LoadScene("MainMenu");
		SetDefaultSettings();
	}

	void SetDefaultSettings(){

		Score.score = 0;
		if (!PlayerPrefs.HasKey("speed"))
		{
			PlayerPrefs.SetFloat("speed", 5.0f);
		}
		if (!PlayerPrefs.HasKey("lives")){
			PlayerPrefs.SetInt("lives", 3);
		}
	}
}
