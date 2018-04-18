using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEntry {
    
    public Shoot.BulletDef bullet;
    public string name;

    public BulletEntry()
    {
        bullet = new Shoot.BulletDef();
        name = "New";
    }

}
