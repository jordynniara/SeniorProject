using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadEndMenu: MonoBehaviour
{
    public AudioSource audio;
    private void OnMouseUpAsButton()
    {

        if (SceneManage.getLastScene().Equals("MainMenu"))
            SceneManager.LoadScene(SceneManage.getLastScene());
        else
        {
            //save list of highscores
            HighScore.WriteToFile();
            SceneManager.LoadScene("EndScene");
        }
            
        audio.Play();
    }
}
