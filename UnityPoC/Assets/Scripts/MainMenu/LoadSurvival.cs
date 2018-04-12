using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSurvival : MonoBehaviour
{
    void OnMouseUpAsButton()
    {
        SceneManager.LoadScene("How2Play");
    }
}
