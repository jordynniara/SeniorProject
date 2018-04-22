﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListControl : MonoBehaviour
{

    public Dropdown dropdownEntries;
    public Canvas bulletEditor;
    public InputField nameField, offsetXField, offsetYField, directionField, speedField;
    public List<BulletEntry> bulletEntries;
    private bool[] validations = new bool[5];

    // Use this for initialization
    void Start()
    {
        bulletEntries = new List<BulletEntry>();
    }

    public void addBullet()
    {
        if (bulletEditor.gameObject.activeInHierarchy) return;
        BulletEntry be = new BulletEntry();
        bulletEntries.Add(be);
        List<string> names = new List<string>();
        names.Add(be.name);
        dropdownEntries.AddOptions(names);
        dropdownEntries.value = dropdownEntries.options.Count - 1;
        dropdownEntries.RefreshShownValue();
        dropdownEntries.enabled = true;

    }

    public void deleteBullet()
    {

        if (bulletEditor.gameObject.activeInHierarchy) return;
        if (dropdownEntries.options.Count > 0 && dropdownEntries.value != -1)
        {
            Debug.Log(dropdownEntries.options.Count);
            Debug.Log(dropdownEntries.value);
            bulletEntries.RemoveAt(dropdownEntries.value);
            dropdownEntries.options.RemoveAt(dropdownEntries.value);
            if (dropdownEntries.value >= dropdownEntries.options.Count)
            {
                dropdownEntries.value = dropdownEntries.options.Count - 1;
            }

            dropdownEntries.RefreshShownValue();
        }
        if (dropdownEntries.options.Count == 0)
        {
            dropdownEntries.enabled = false;
        }

    }

    public void editBullet()
    {

        if (bulletEditor.gameObject.activeInHierarchy || !dropdownEntries.enabled) return;
        if (dropdownEntries.options.Count > 0 && dropdownEntries.value != -1)
        {
            bulletEditor.gameObject.SetActive(true);
            dropdownEntries.enabled = !bulletEditor.gameObject.activeInHierarchy;
            nameField.text = bulletEntries[dropdownEntries.value].name;
            offsetXField.text = bulletEntries[dropdownEntries.value].bullet.offset.x.ToString();
            offsetYField.text = bulletEntries[dropdownEntries.value].bullet.offset.y.ToString();
            directionField.text = bulletEntries[dropdownEntries.value].bullet.direction.ToString();
            speedField.text = bulletEntries[dropdownEntries.value].bullet.speed.ToString();
        }
    }

    private bool isValid()
    {
        foreach (var v in validations)
        {
            if (!v) return false;
        }
        return true;

    }

    public void applyChanges()
    {
        if (!isValid()) return;
        bulletEntries[dropdownEntries.value].name = nameField.text;
        bulletEntries[dropdownEntries.value].bullet.offset = new Vector2(float.Parse(offsetXField.text), float.Parse(offsetYField.text));
        bulletEntries[dropdownEntries.value].bullet.direction = float.Parse(directionField.text);
        bulletEntries[dropdownEntries.value].bullet.speed = float.Parse(speedField.text);
        dropdownEntries.options[dropdownEntries.value].text = bulletEntries[dropdownEntries.value].name;
        dropdownEntries.RefreshShownValue();
    }

    public void okChanges()
    {

        if (!isValid()) return;
        applyChanges();
        bulletEditor.gameObject.SetActive(false);
        dropdownEntries.enabled = !bulletEditor.gameObject.activeInHierarchy;
    }

    public void validateName(InputField src)
    {
        validations[0] = src.text.Trim().Length > 0;
        Color right = Color.white, wrong = Color.red;
        wrong.g = wrong.b = 64.0f / 255.0f;

        src.gameObject.GetComponent<Image>().color = validations[0] ? right : wrong;
    }

    public bool validateFloat(InputField src)
    {
        float res;
        return float.TryParse(src.text, out res);
    }

    public void validateOffX(InputField src)
    {
        validations[1] = validateFloat(src);
        Color right = Color.white, wrong = Color.red;
        wrong.g = wrong.b = 64.0f / 255.0f;
        src.gameObject.GetComponent<Image>().color = validations[1] ? right : wrong;
    }

    public void validateOffY(InputField src)
    {
        validations[2] = validateFloat(src);
        Color right = Color.white, wrong = Color.red;
        wrong.g = wrong.b = 64.0f / 255.0f;
        src.gameObject.GetComponent<Image>().color = validations[2] ? right : wrong;
    }

    public void validateDir(InputField src)
    {
        validations[3] = validateFloat(src);
        Color right = Color.white, wrong = Color.red;
        wrong.g = wrong.b = 64.0f / 255.0f;
        if (validations[3])
        {
            float dir = float.Parse(src.text);
            validations[3] = dir >= 0.0f && dir <= 360.0f;
        }

        src.gameObject.GetComponent<Image>().color = validations[3] ? right : wrong;

    }

    public void validateSpd(InputField src)
    {
        validations[4] = validateFloat(src);
        Color right = Color.white, wrong = Color.red;
        wrong.g = wrong.b = 64.0f / 255.0f;
        
        if (validations[4])
        {
            float spd = float.Parse(src.text);
            validations[4] = spd > 0.0f;
        }

        src.gameObject.GetComponent<Image>().color = validations[4] ? right : wrong;

    }
}