using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLab : MonoBehaviour {
    void OnMouseUpAsButton()
    {
        SceneManager.LoadScene("TheLab");
    }
}
