﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public int diff;
    public int mode = 0;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }
}
