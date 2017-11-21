using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MouseOver : MonoBehaviour {
	void Start(){
		GetComponent<Renderer> ().material.color = Color.white;
	}

	void OnMouseEnter(){
		GetComponent<Renderer> ().material.color = Color.red;
	}

	void OnMouseExit() {
		GetComponent<Renderer> ().material.color = Color.white;
	}
}
