using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModToggler : MonoBehaviour {

    public Toggle toggle;

    private void Start()
    {
        if (!toggle) toggle = GetComponent<Toggle>();
        setMods();
    }

    public void setMods()
    {
        PlayerPrefs.SetInt("modding", toggle.isOn ? 1 : 0);
    }
}
