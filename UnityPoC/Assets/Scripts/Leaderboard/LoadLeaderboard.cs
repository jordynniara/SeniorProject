using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLeaderboard: MonoBehaviour{
    public AudioSource audio;
    SubmitInput submit;
	private void OnMouseUpAsButton()
	{
        SceneManager.LoadScene("Leaderboard");
        audio.Play();
	}
}
