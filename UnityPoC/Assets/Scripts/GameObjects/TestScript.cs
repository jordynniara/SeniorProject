using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class TestScript : MonoBehaviour
{
    InputField idField;

    // Use this for initialization
    void Start()
    {
        idField = GetComponent<InputField>();
    }

    public void MakeEntity()
    {
        ModLoader.EntityInfo data = ModLoader.data;
        foreach (Entity entity in data.entities)
        {
            if (entity.id == idField.text)
            {
                GameObject newEntity = new GameObject();
                Texture2D tex = new Texture2D(32, 32);
                Debug.Log(tex.LoadImage(File.ReadAllBytes(entity.spriteName + ".png")));
                newEntity.AddComponent<SpriteRenderer>();
                SpriteRenderer ren = newEntity.GetComponent<SpriteRenderer>();
                ren.sprite = Sprite.Create(tex, new Rect(0, 0, 32, 32), new Vector2(0.5f, 0.5f), 16.0f);
                if (entity.isPlayer)
                {
                    GameObject oldPlayer = GameObject.FindGameObjectWithTag("Player");
                    if (oldPlayer != null)
                    {
                        Destroy(oldPlayer);
                    }
                    newEntity.AddComponent<KeyboardMovement>().speed = entity.speed;
                    newEntity.tag = "Player";
                }
                else
                {
                    newEntity.AddComponent<RandomMovement>().speed = entity.speed;
                }

            }
        }
    }


}
