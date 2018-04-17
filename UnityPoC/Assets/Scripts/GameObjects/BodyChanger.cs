﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyChanger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt ("modding") == 1) {
			this.gameObject.GetComponent<SpriteRenderer> ().sprite = GameSettings.bodyIcon[GameSettings.bodyIcon.Count-1];
			Vector3 scale = new Vector3( 5f, 5f, 1f );
			transform.localScale = scale;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}