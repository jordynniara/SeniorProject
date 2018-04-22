using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundChanger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt ("modding") == 1) {
			try {
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = GameSettings.background[GameSettings.background.Count-1];
			}
			catch (Exception e) {
				Debug.Log(e.Message);
			}
		}
	}

	// Update is called once per frame
	void Update () {

	}

}
