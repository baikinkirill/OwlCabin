using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasNavigation : MonoBehaviour
{
    StarSpawner SS;
    [SerializeField] Text zone;

    void Start()
    {
        SS = GameObject.Find("StarSpawner").GetComponent<StarSpawner>();
    }

    public void LoadFirstMap()
    {
        SceneManager.LoadScene("");
    }

    public void LoadSecondMap()
    {
        SceneManager.LoadScene("");
    }

    public void LoadThirdMap()
    {
        SceneManager.LoadScene("");
    }

    public void ChangeDifficulty()
    {
        SS.ChangeDifficulty();
        if (zone.text == "Playzone 180°")
        {
            zone.text = "Playzone 360°";
        }
        else
        {
            zone.text = "Playzone 180°";
        }
    }
}
