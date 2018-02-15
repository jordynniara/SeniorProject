using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameInteraction : MonoBehaviour {


	void OnMouseUpAsButton () {
		SceneManager.LoadScene("TheLab");	
	}
}
