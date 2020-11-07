using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasNavigation : MonoBehaviour
{
    [SerializeField] int timeToInteract = 2;
    StarSpawner SS;
    [SerializeField] Text zone;
    float timer = 0f;
    bool enter = false;
    int button = 0;

    void Start()
    {
        SS = GameObject.Find("StarSpawner").GetComponent<StarSpawner>();
    }

    private void Update()
    {
        if (enter)
        {
            timer += Time.deltaTime;
            if ((int)timer == timeToInteract)
            {
                if (button < 5)
                {
                    LoadMap(button);
                }
                else if(button == 5)
                {
                    ChangeDifficulty();
                }
                TimerStop();
            }
        }
    }

    public void TimerStart(int butt)
    {
        enter = true;
        button = butt;
    }

    public void TimerStop()
    {
        enter = false;
        timer = 0f;
        button = 0;
    }

    public void LoadMap(int mapNum)
    {
        if ((int)timer == timeToInteract)
        {
            SceneManager.LoadScene(mapNum);
        }
    }

    public void ChangeDifficulty()
    {
        if ((int)timer == timeToInteract)
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
}
