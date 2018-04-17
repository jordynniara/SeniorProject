using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardMouseOver : MonoBehaviour {

	public AudioSource audio;
	void Start(){
		GetComponent<Renderer> ().material.color = Color.red;
	}

	void OnMouseEnter(){
		GetComponent<Renderer> ().material.color = Color.white;
		audio.Play();
	}

	void OnMouseExit() {
		GetComponent<Renderer> ().material.color = Color.red;
	}
}
