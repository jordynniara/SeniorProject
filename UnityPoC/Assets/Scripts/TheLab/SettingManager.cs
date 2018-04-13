using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
//using UnityEditor;
using UnityEngine.SceneManagement;

public class SettingManager : MonoBehaviour {
    public Dropdown speedDropdown;
    public Dropdown livesDropdown;
    public Button spriteBrowse;
    public InputField playerBSpeed;
    public InputField playerBOffX;
    public InputField playerBOffY;
    public InputField playerBDir;

    public GameSettings gameSettings;

    void OnEnable() {
        gameSettings = gameObject.AddComponent(typeof(GameSettings)) as GameSettings; ;

        speedDropdown.onValueChanged.AddListener(delegate { OnSpeedChange(); });
        livesDropdown.onValueChanged.AddListener(delegate { OnLivesChange(); });
        //spriteBrowse.onClick.AddListener (delegate { BrowseMethod (); });

    }

    public void OnSpeedChange() {
        gameSettings.speed = speedDropdown.value;


    }

    public void OnLivesChange() {
        gameSettings.lives = livesDropdown.value;
    }

    public void ExitMethod() {
        SceneManager.LoadScene("MainMenu");

    }

    public void BrowseMethod() {
        //		string path = EditorUtility.OpenFilePanel("Overwrite with png", "", "png");
        //		if (path.Length != 0)
        //		{
        //			gameSettings.sprite = path;
        //			//			var fileContent = File.ReadAllBytes(path);
        //			//			texture.LoadImage(fileContent);
        //		}
    }

    public void saveSettings() {
        switch (gameSettings.speed) {
            case 0:
                PlayerPrefs.SetFloat("speed", 3.0f);
                break;
            case 1:
                PlayerPrefs.SetFloat("speed", 5.0f);
                break;
            case 2:
                PlayerPrefs.SetFloat("speed", 7.0f);
                break;
        }

        switch (gameSettings.lives) {
            case 0:
                PlayerPrefs.SetInt("lives", 1);
                break;
            case 1:
                PlayerPrefs.SetInt("lives", 2);
                break;
            case 2:
                PlayerPrefs.SetInt("lives", 3);
                break;
        }

        PlayerPrefs.Save();
    }


    public void addPlayerBullet()
    {
        Vector2 offset = Vector2.zero;
        float direction;
        float speed;
        if (!float.TryParse(playerBOffX.text, out offset.x))
        {
            return;
        }
        if (!float.TryParse(playerBOffY.text, out offset.y))
        {
            return;
        }
        if (!float.TryParse(playerBDir.text, out direction))
        {
            return;
        }
        if (!float.TryParse(playerBSpeed.text, out speed))
        {
            return;
        }
        GameSettings.playerShootStyle.bulletDefs.Add(new Shoot.BulletDef(offset, direction, speed, null));
        updatePlayerBulletList();

    }

    public void applyPlayerBullet()
    {

        Vector2 offset = Vector2.zero;
        float direction;
        float speed;
        if (!float.TryParse(playerBOffX.text, out offset.x))
        {
            return;
        }
        if (!float.TryParse(playerBOffY.text, out offset.y))
        {
            return;
        }
        if (!float.TryParse(playerBDir.text, out direction))
        {
            return;
        }
        if (!float.TryParse(playerBSpeed.text, out speed))
        {
            return;
        }

        
    }

    public void updatePlayerBulletList()
    {

    }

}
