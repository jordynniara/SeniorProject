using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameInteraction : MonoBehaviour {
    public AudioSource audio;
	void OnMouseUpAsButton () {
		SceneManager.LoadScene("TheLab");
        audio.Play();
	}

}
