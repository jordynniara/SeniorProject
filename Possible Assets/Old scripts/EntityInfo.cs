using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Entity {
    

        public string id;

        public float speed;

        public string spriteName;

        public bool isPlayer;

        override
        public string ToString()
        {
            return id + " " + speed + " " + spriteName + " " + isPlayer;
        }

	
}