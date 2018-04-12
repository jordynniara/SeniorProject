using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SurvivalGuideAction : MonoBehaviour
{

    // Use this for initialization
    public AudioSource hoverAudio;
    public AudioSource clickAudio;
    private Color origColor;
    void Start()
    {
        origColor = GetComponent<TextMesh>().color;
    }

    void OnMouseEnter()
    {
        GetComponent<TextMesh>().color = Color.white;
        hoverAudio.Play();
    }

    void OnMouseExit()
    {
        GetComponent<TextMesh>().color = origColor;
    }

    private void OnMouseUpAsButton()
    {
        clickAudio.Play();
        SceneManager.LoadScene("MainMenu");
    }
}
