using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModToggler : MonoBehaviour {

    public Toggle toggle;

    private void Start()
    {
		if (!toggle) {
			toggle = GetComponent<Toggle> ();
		}
        setMods();
    }

    public void setMods()
    {
		if (toggle.isOn) {
			PlayerPrefs.SetInt("modding", 1);
		} 
		else {
			PlayerPrefs.SetInt("modding", 0);
		}
    }
}
