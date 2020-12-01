﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaneChanger : MonoBehaviour
{
    [SerializeField] TextMesh stars;
    [SerializeField] private GameObject[] planes;
    [SerializeField] private int[] onStarChane; //При таких кол-вах собранных звезд будет меняться самолет.
    private int selectedPlane = 0;

    private int _points;
    private int points 
    { 
        set 
        {
            _points = value;
            changePlane();
        }
        get
        {
            return _points;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(points);
        if(other.tag != "Star") { return; }
        Star star = other.GetComponent<Star>();
        points += star.starCost;
        star.onCatch();
        stars.text = points.ToString();
        if (GameController.instance.mode == 1)
        {
            if (points >= 250)
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    private void changePlane()
    {
        for (int i = 0; i < onStarChane.Length; ++i)
        {
            if(onStarChane[i] == points && ++selectedPlane < planes.Length)
            {
                for(int y = 0; y < planes.Length; ++y)
                {
                    bool active = (selectedPlane == y) ? true : false;
                    planes[y].SetActive(active);
                }
            }
        }
    }
}
