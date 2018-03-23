using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputEnabler : MonoBehaviour {
    public InputField inf;
    public void enableInputField()
    {
        inf.gameObject.SetActive(true);
    }
    public void disableInputField()
    {
        inf.gameObject.SetActive(false);
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.Period))
        {
            enableInputField();
        }
	}
}
