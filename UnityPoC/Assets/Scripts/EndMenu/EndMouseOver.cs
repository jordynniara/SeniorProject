using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EndMouseOver : MonoBehaviour {
	public AudioSource audio;
	void Start(){
		GetComponent<Renderer> ().material.color = Color.white;
	}

	void OnMouseEnter(){
		GetComponent<Renderer> ().material.color = Color.red;
		audio.Play();
	}

	void OnMouseExit() {
		GetComponent<Renderer> ().material.color = Color.white;
	}
}
