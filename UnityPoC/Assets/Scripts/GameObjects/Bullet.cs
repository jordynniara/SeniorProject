using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Interface to redefine fire method as needed
public interface Bullet {
    //Direction is either a 1 (up) or -1 (down)
    void fire(int direction);
}
