﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Movement {
    void move(float speed);

    void keepInBounds();
}
