using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MouseOver : MonoBehaviour {
    public AudioSource audio;
    Color origColor;
	void Start(){
        origColor = GetComponent<Renderer>().material.color;
		//GetComponent<Renderer> ().material.color = Color.white;
	}

	void OnMouseEnter(){
        if(origColor == Color.white)
		    GetComponent<Renderer> ().material.color = Color.blue;
        else if(origColor == Color.blue || origColor == Color.red)
            GetComponent<Renderer>().material.color = Color.white;
        audio.Play();
	}

	void OnMouseExit() {
		GetComponent<Renderer> ().material.color = origColor;
	}
}
