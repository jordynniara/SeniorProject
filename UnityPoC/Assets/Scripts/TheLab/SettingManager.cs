using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
//using UnityEditor;
using UnityEngine.SceneManagement;

public class SettingManager : MonoBehaviour
{

    public static bool changeNumLives = true;
    public static bool saveSuccess = false;

    public List<Dropdown> speedDropdowns;
    public List<Dropdown> shootStyleDropdown;
    public List<Dropdown> livesDropdown;
    public Dropdown musicDropdown;
    public Dropdown spriteDropdown;
    public Dropdown backgroundDropdown;
    public InputField playerBSpeed;
    public InputField playerBOffX;
    public InputField playerBOffY;
    public InputField playerBDir;
    public Button spriteBrowse;

    public List<GameObject> characterPanels;


    public GameSettings gameSettings;
    public List<ListControl> listControls;

    void OnEnable()
    {
        gameSettings = gameObject.AddComponent(typeof(GameSettings)) as GameSettings;
        musicDropdown.onValueChanged.AddListener(delegate { OnMusicChange(); });
        spriteDropdown.onValueChanged.AddListener(delegate { OnSpriteChange(); });
        backgroundDropdown.onValueChanged.AddListener(delegate { OnBackgroundChange(); });

    }

    public void OnBackgroundChange()
    {

        Sprite newBackground;

        switch (backgroundDropdown.value)
        {
            case 1:
                newBackground = Resources.Load<Sprite>("chalkboard");
                GameSettings.background.Add(newBackground);
                break;
            case 2:
                newBackground = Resources.Load<Sprite>("blackboard");
                GameSettings.background.Add(newBackground);
                break;
            case 3:
                newBackground = Resources.Load<Sprite>("clouds");
                GameSettings.background.Add(newBackground);
                break;
            case 4:
                newBackground = Resources.Load<Sprite>("stars");
                GameSettings.background.Add(newBackground);
                break;
        }
        saveSuccess = false;
    }

    public void OnSpriteChange()
    {

        Sprite[] sheet = null;
        Sprite newSprite = null;

        switch (spriteDropdown.value)
        {
            case 1:
                sheet = Resources.LoadAll<Sprite>("Females/Girl1");
                newSprite = sheet[2];
                GameSettings.player.Add(newSprite);
                newSprite = sheet[0];
                GameSettings.bodyIcon.Add(newSprite);
                break;
            case 2:
                sheet = Resources.LoadAll<Sprite>("Females/Girl2");
                newSprite = sheet[2];
                GameSettings.player.Add(newSprite);
                newSprite = sheet[0];
                GameSettings.bodyIcon.Add(newSprite);
                break;
            case 3:
                sheet = Resources.LoadAll<Sprite>("Females/Girl3");
                newSprite = sheet[2];
                GameSettings.player.Add(newSprite);
                newSprite = sheet[0];
                GameSettings.bodyIcon.Add(newSprite);
                break;
            case 4:
                sheet = Resources.LoadAll<Sprite>("Females/Girl4");
                newSprite = sheet[2];
                GameSettings.player.Add(newSprite);
                newSprite = sheet[0];
                GameSettings.bodyIcon.Add(newSprite);
                break;
            case 5:
                sheet = Resources.LoadAll<Sprite>("Females/Girl5");
                newSprite = sheet[2];
                GameSettings.player.Add(newSprite);
                newSprite = sheet[0];
                GameSettings.bodyIcon.Add(newSprite);
                break;
            case 6:
                sheet = Resources.LoadAll<Sprite>("Females/Girl6");
                newSprite = sheet[2];
                GameSettings.player.Add(newSprite);
                newSprite = sheet[0];
                GameSettings.bodyIcon.Add(newSprite);
                break;
            case 7:
                sheet = Resources.LoadAll<Sprite>("Males/Boy1");
                newSprite = sheet[2];
                GameSettings.player.Add(newSprite);
                newSprite = sheet[0];
                GameSettings.bodyIcon.Add(newSprite);
                break;
            case 8:
                sheet = Resources.LoadAll<Sprite>("Males/Boy2");
                newSprite = sheet[2];
                GameSettings.player.Add(newSprite);
                newSprite = sheet[0];
                GameSettings.bodyIcon.Add(newSprite);
                break;
            case 9:
                sheet = Resources.LoadAll<Sprite>("Males/Boy3");
                newSprite = sheet[2];
                GameSettings.player.Add(newSprite);
                newSprite = sheet[0];
                GameSettings.bodyIcon.Add(newSprite);
                break;
            case 10:
                sheet = Resources.LoadAll<Sprite>("Males/Boy4");
                newSprite = sheet[2];
                GameSettings.player.Add(newSprite);
                newSprite = sheet[0];
                GameSettings.bodyIcon.Add(newSprite);
                break;
            case 11:
                sheet = Resources.LoadAll<Sprite>("Males/Boy5");
                newSprite = sheet[2];
                GameSettings.player.Add(newSprite);
                newSprite = sheet[0];
                GameSettings.bodyIcon.Add(newSprite);
                break;
            case 12:
                sheet = Resources.LoadAll<Sprite>("Males/Boy6");
                newSprite = sheet[2];
                GameSettings.player.Add(newSprite);
                newSprite = sheet[0];
                GameSettings.bodyIcon.Add(newSprite);
                break;
        }
        Debug.Log(newSprite);
        saveSuccess = false;
    }

    public void OnMusicChange()
    {

        AudioClip clip = null;

        switch (musicDropdown.value)
        {
            case 1:
                clip = Resources.Load<AudioClip>("DeepInTheCavesBelow");
                GameSettings.music.Add(clip);
                break;
            case 2:
                clip = Resources.Load<AudioClip>("FightForYourLives");
                GameSettings.music.Add(clip);
                break;
            case 3:
                clip = Resources.Load<AudioClip>("GoingUp");
                GameSettings.music.Add(clip);
                break;
            case 4:
                clip = Resources.Load<AudioClip>("YetAnotherJourney");
                GameSettings.music.Add(clip);
                break;

        }
        Debug.Log(clip);
        saveSuccess = false;
    }

    public void OnSpeedChange(int which)
    {
        GameSettings.speedSelections[which] = speedDropdowns[which].value;

        saveSuccess = false;
    }

    public void OnShootStyleChange(int which)
    {
        List<BulletEntry> bullets = new List<BulletEntry>();
        List<string> options = new List<string>();
        switch (shootStyleDropdown[which].value)
        {
            case 1:
                {
                    BulletEntry be = new BulletEntry();
                    be.name = "Bullet 0";
                    be.bullet = new Shoot.BulletDef(new Vector2(), which == 0 ? 90 : 270, 6, null);
                    options.Add("Bullet 0");
                    bullets.Add(be);

                }
                break;
            case 2:
                {

                    BulletEntry be = new BulletEntry();
                    be.name = "Bullet 0";
                    be.bullet = new Shoot.BulletDef(new Vector2(0.3f, 0), which == 0 ? 90 : 270, 6, null);
                    options.Add("Bullet 0");
                    bullets.Add(be);

                    be = new BulletEntry();
                    be.name = "Bullet 1";
                    be.bullet = new Shoot.BulletDef(new Vector2(-0.3f, 0), which == 0 ? 90 : 270, 6, null);
                    options.Add("Bullet 1");
                    bullets.Add(be);

                }
                break;
            case 3:
                {
                    BulletEntry be = new BulletEntry();
                    be.name = "Bullet 0";
                    be.bullet = new Shoot.BulletDef(new Vector2(), which == 0 ? 70 : 250, 6, null);
                    options.Add("Bullet 0");
                    bullets.Add(be);
                    be = new BulletEntry();
                    be.name = "Bullet 1";
                    be.bullet = new Shoot.BulletDef(new Vector2(), which == 0 ? 90 : 270, 6.5f, null);
                    options.Add("Bullet 1");
                    bullets.Add(be);
                    be = new BulletEntry();
                    be.name = "Bullet 2";
                    be.bullet = new Shoot.BulletDef(new Vector2(), which == 0 ? 110 : 290, 6, null);
                    options.Add("Bullet 2");
                    bullets.Add(be);

                }
                break;
        }
        for (int i = 0; i < bullets.Count; i++)
        {
            listControls[which].bulletEntries = bullets;

            listControls[which].dropdownEntries.ClearOptions();
            listControls[which].dropdownEntries.AddOptions(options);
            listControls[which].dropdownEntries.RefreshShownValue();
            listControls[which].dropdownEntries.interactable = true;

        }

        saveSuccess = false;
    }

    public void OnLivesChange(int which)
    {
        GameSettings.lives[which] = livesDropdown[which].value;
        saveSuccess = false;
    }

    public void ExitMethod()
    {
        SceneManager.LoadScene("MainMenu");

    }

    public void saveSettings()
    {

        
        for (int j = 0; j < listControls.Count; j++)
        {
            switch (livesDropdown[j].value)
            {
                case 0:
                    GameSettings.lives[j] = j == 0 ? 3 : 2;
                    break;
                case 1:
                    GameSettings.lives[j] = 1;
                    break;
                case 2:
                    GameSettings.lives[j] = 2;
                    break;
                case 3:
                    GameSettings.lives[j] = 3;
                    break;
                case 4:
                    if (j == 0)
                        changeNumLives = false;
                    break;
            }
            switch (speedDropdowns[j].value)
            {
                case 0:
                    GameSettings.speedValues[j] = 5.0f;
                    break;
                case 1:
                    GameSettings.speedValues[j] = 3.0f;
                    break;
                case 2:
                    GameSettings.speedValues[j] = 5.0f;
                    break;
                case 3:
                    GameSettings.speedValues[j] = 7.0f;
                    break;
            }
            GameSettings.shotTypes[j] = null;
            if (listControls[j].bulletEntries.Count > 0)
            {
                GameSettings.shotTypes[j] = new List<Shoot.BulletDef>();
                foreach (var entry in listControls[j].bulletEntries)
                {
                    GameSettings.shotTypes[j].Add(entry.bullet);
                }

            }
        }
        PlayerPrefs.Save();
        saveSuccess = true;
    }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void BrowseMethod()
    {
        //		string path = EditorUtility.OpenFilePanel("Overwrite with png", "", "png");
        //		if (path.Length != 0)
        //		{
        //			gameSettings.sprite = path;
        //			//			var fileContent = File.ReadAllBytes(path);
        //			//			texture.LoadImage(fileContent);
        //		}
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
        saveSuccess = false;
    }

    public void selectCharacter(Dropdown characterDD)
    {
        int which = characterDD.value;
        for (int i = 0; i < characterPanels.Count; i++)
        {
            characterPanels[i].SetActive(false);
        }
        
        characterPanels[which].SetActive(true);
    }
    
}