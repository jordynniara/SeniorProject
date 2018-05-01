using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveSuccessMessage : MonoBehaviour {
    public GameObject saveMessage;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(SettingManager.saveSuccess)
        {
            saveMessage.GetComponent<Text>().enabled = true;
            //saveMessage.GetComponent<GameObject>().SetActive(true);
        }
        else
        {
            saveMessage.GetComponent<Text>().enabled = false;
            //saveMessage.GetComponent<GameObject>().SetActive(false);
        }
	}
}
