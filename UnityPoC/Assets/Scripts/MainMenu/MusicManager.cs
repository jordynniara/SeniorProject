using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MusicManager : MonoBehaviour
{
    public AudioSource audio;
    static bool AudioBegin = false;
    void Awake()
    {
        if (!AudioBegin)
        {
            audio.Play();
            DontDestroyOnLoad(gameObject);
            AudioBegin = true;
        }
    }
    void Update()
    {
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("TheLab") ||
            SceneManager.GetActiveScene() != SceneManager.GetSceneByName("MainMenu"))
        {
            audio.Stop();
            AudioBegin = false;
        }
    }
}