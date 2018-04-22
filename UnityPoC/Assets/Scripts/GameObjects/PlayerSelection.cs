using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelection : MonoBehaviour {

	// Use this for initialization

	void Start () {
		if (PlayerPrefs.GetInt ("modding") == 1) {
			try {
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = GameSettings.player[GameSettings.player.Count-1];
				Vector3 scale = new Vector3( 8f, 8f, 1f );
				transform.localScale = scale;
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
