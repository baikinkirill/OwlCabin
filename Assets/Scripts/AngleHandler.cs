using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleHandler : MonoBehaviour
{
    public static AngleHandler instance;
    public int diff;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }
}
