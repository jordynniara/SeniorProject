using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public static int score = 0;
    public static int multiplier = 1;
    public static bool multiActive = false;
    

    // Update is called once per frame
    void Update () {
        if (GameEnder.gameOver)
        {
            if (multiActive)
            {
                GetComponent<TextMesh>().text = "Score x" + Score.multiplier + ": " + score;
            }
            else
            {
                GetComponent<TextMesh>().text = "Score: " + score;
            }
            return;
        }
        
        if(multiActive)
        {
        transform.position = new Vector3(2f, -3.869762f, 0f);   
        GetComponent<TextMesh>().text = "Score x" + Score.multiplier + ": " + score;
        }
        else
        {
        GetComponent<TextMesh>().text = "Score: " + score;
        transform.position = new Vector3(4f, -3.869762f, 0f);
        }
        
    }

    public void DisplayScore()
    {
        GetComponent<TextMesh>().anchor = TextAnchor.MiddleCenter;
        transform.position = new Vector3(0f, 1f, 0f);
        GetComponent<TextMesh>().characterSize = 2;
        GetComponent<TextMesh>().alignment = TextAlignment.Center;
    }

    public static void UpdateScore(int val)
    {
        val *= multiplier;
        score += val;
    }

}
