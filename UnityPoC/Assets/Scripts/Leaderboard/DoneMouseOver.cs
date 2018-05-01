using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoneMouseOver : MonoBehaviour {
    public AudioSource audio;
    Color color;
    void Start()
    {
        color = GetComponent<TextMesh>().color;
    }

    void OnMouseEnter()
    {
        GetComponent<TextMesh>().color = Color.white;
        audio.Play();
    }

    void OnMouseExit()
    {
        GetComponent<TextMesh>().color = color;
    }
}
