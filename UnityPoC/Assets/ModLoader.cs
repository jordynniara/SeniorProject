using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ModLoader : MonoBehaviour {

    [Serializable]
    public class EntityInfo
    {

        public List<Entity> contents;
    }

    public static EntityInfo data;

	// Use this for initialization
	void Start () {
        StreamReader r = new StreamReader("abcd.txt");
        string contents = r.ReadToEnd();
        data = JsonUtility.FromJson<EntityInfo>(contents);
        for (int i = 0; i < data.contents.Count; i++)
        {
            Debug.Log(data.contents[i]);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}