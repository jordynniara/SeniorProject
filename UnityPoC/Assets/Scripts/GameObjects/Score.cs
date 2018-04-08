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

        if(multiActive)
        {
            this.transform.position = new Vector3(2f, -3.869762f, 0f);   
            this.GetComponent<TextMesh>().text = "Score x" + Score.multiplier + ": " + score;
        }
        else
        {
            this.GetComponent<TextMesh>().text = "Score: " + score;
            this.transform.position = new Vector3(4f, -3.869762f, 0f);
        }
            
    }

    public void DisplayScore()
    {
        this.GetComponent<TextMesh>().anchor = TextAnchor.MiddleCenter;
        this.transform.position = new Vector3(0f, 4f, 0f);
        this.GetComponent<TextMesh>().characterSize = 2;
        this.GetComponent<TextMesh>().alignment = TextAlignment.Center;
    }

    public static void UpdateScore(int val)
    {
        val *= multiplier;
        score += val;
    }

}
