using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModToggler : MonoBehaviour {

    public Toggle toggle;

    private void Start()
    {
        if (!toggle) toggle = GetComponent<Toggle>();
        setMods(toggle.isOn);
    }

    public void setMods(bool mods)
    {
        PlayerPrefs.SetInt("modding", mods ? 1 : 0);
    }
}
