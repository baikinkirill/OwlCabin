using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleHandler : MonoBehaviour
{
    public static AngleHandler instance;
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
