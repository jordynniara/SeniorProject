using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameInteraction : MonoBehaviour {
    
    
	void OnMouseUpAsButton () {
        SceneManager.LoadScene("testScene");	
	}
}
