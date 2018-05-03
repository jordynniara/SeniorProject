using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyChanger : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        if (PlayerPrefs.GetInt("modding") == 1)
        {
            try
            {
                if (GameSettings.bodyIcon.Count > 0)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = GameSettings.bodyIcon[GameSettings.bodyIcon.Count - 1];
                    Vector3 scale = new Vector3(5f, 5f, 1f);
                    transform.localScale = scale;

                }
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}