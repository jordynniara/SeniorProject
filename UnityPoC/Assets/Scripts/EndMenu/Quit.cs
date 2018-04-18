using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{

    public AudioSource audio;
    void OnMouseUpAsButton()
    {
        //save list of highscores
        HighScore.WriteToFile();

        Debug.Log("Game is exiting");
        audio.Play();
        Application.Quit();
    }
}
