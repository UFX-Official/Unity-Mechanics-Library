﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_2D_Tactical : GameManager {

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused) Pause(true);
            else Pause(false);
        }
    }
}
