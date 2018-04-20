using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MouseOver : MonoBehaviour {
    public AudioSource audio;

	void Start(){
		GetComponent<Renderer> ().material.color = Color.white;
	}

	void OnMouseEnter(){
		    GetComponent<Renderer> ().material.color = Color.blue;
        audio.Play();
	}

	void OnMouseExit() {
		GetComponent<Renderer> ().material.color = Color.white;
	}
}
