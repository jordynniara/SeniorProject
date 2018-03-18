using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour {

	void OnMouseUpAsButton()
	{
		SceneManager.LoadScene("MainMenu");
		SetDefaultSettings();
	}

	void SetDefaultSettings(){

		if (!PlayerPrefs.HasKey("speed"))
		{
			PlayerPrefs.SetFloat("speed", 5.0f);
		}
		if (!PlayerPrefs.HasKey("lives")){
			PlayerPrefs.SetInt("lives", 3);
		}
	}
}
