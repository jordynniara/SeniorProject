using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameScore : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        GetComponent<TextMesh>().text = "Score: " + Score.score;
	}
}
