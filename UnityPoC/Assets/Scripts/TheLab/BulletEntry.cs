using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEntry {
    
    public Shoot.BulletDef bullet;
    public string name;

    public BulletEntry()
    {
        bullet = new Shoot.BulletDef(Vector2.zero, 90.0f, 6.0f, null);
        name = "New";
    }

}
