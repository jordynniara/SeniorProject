using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;

public class SubmitInput : MonoBehaviour {

    private string inputText;
    private int length;
    public InputField field;
    public TextMesh advisoryText;
    public GameObject done;

    private void Awake()
    {
        if(field == null)
            field = GameObject.Find("InputField").GetComponent<InputField>();
        if(advisoryText == null)
            advisoryText = GameObject.Find("Advisory Text").GetComponent<TextMesh>();
        if(done == null)
            done = GameObject.Find("Done");

        inputText = field.textComponent.text;
        field.onValidateInput += Field_OnValidateInput;
        SceneManage.setLastLevel(SceneManager.GetActiveScene().name);
    }
	public void GetText(string text)
    {
        inputText = text;
        HighScore.inputInitial = text;
    }

    char Field_OnValidateInput(string text, int charIndex, char addedChar)
    {
        if (
           (!Regex.IsMatch(addedChar.ToString(), "[A-Z]")&&
            !Regex.IsMatch(addedChar.ToString(), "[a-z]")))
        {
            return '\0';
        }
        return addedChar;
    }

    private void AdvisoryOn()
    {
        advisoryText.text = ("(Max 3 characters. Letters only)");
        done.GetComponent<BoxCollider2D>().enabled = false;
        done.GetComponent<TextMesh>().color = Color.gray;
    }

    private void AdvisoryOff()
    {
        advisoryText.text = "Awesome!";
        done.GetComponent<BoxCollider2D>().enabled = true;
        done.GetComponent<TextMesh>().color = Color.red;
    }

    private void Update()
    {
        length = field.textComponent.text.Length;

        if (length == 0 )
            AdvisoryOn();
        else
            AdvisoryOff();
	}

}
