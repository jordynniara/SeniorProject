using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {
    public Level lvlObject;
    public int lvlNum;

    public float lvlStartDelay = 3f;

    public GameObject lvlLabel;

	
	void Start () {
        //don't start spawning yet
        lvlObject.isEnabled = false;
        //get the label
        lvlLabel = GameObject.Find("LevelText");
        lvlNum = 0;

        TransitionLevel();
	}
	
	// Update is called once per frame
	void Update () {
        //if reached max waves per level
        if(Level.waveCount >= Level.totNumWaves)
        {
            //disable spawning
            lvlObject.isEnabled = false;

            //if all enemies cleared
            if(Level.numEnemies ==0)
                //go to next level
                TransitionLevel();
        }
	}


    void TransitionLevel()
    {
        //increase level number
        lvlNum++;
        //display label
        lvlLabel.GetComponent<TextMesh>().text = "LEVEL" + lvlNum;
        lvlLabel.SetActive(true);

        //start next level after some delay
        Invoke("HideLevelLable", lvlStartDelay);

        //reset wave count
        Level.waveCount = 0;
    }

    void HideLevelLable(){
        //remove label
        lvlLabel.SetActive(false);
        //start level
        lvlObject.isEnabled = true;
    }
}
