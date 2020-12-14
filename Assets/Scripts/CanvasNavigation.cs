using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasNavigation : MonoBehaviour
{
    [SerializeField] int timeToInteract = 2;
    [SerializeField] Text zone;
    [SerializeField] Text mode;
    [SerializeField] Image imageCircle;
    private float timer
    {
        set
        {
            _timer = value;
            updateCircle();
        }

        get
        {
            return _timer;
        }
    }
    private float _timer = 0f;
    bool enter = false;
    int button = 0;

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
                else if (button == 6)
                {
                    ChangeMode();
                }
                if (button == 7)
                {
                    LoadMap(0);
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
            if (zone.text == "Playzone 180°")
            {
                zone.text = "Playzone 360°";
                GameController.instance.diff = -180;
            }
            else
            {
                zone.text = "Playzone 180°";
                GameController.instance.diff = 0;
            }
        }
    }

    public void ChangeMode()
    {
        if ((int)timer == timeToInteract)
        {
            if (mode.text == "Бесконечный режим (нет)")
            {
                mode.text = "Бесконечный режим (да)";
                GameController.instance.mode = 1;
            }
            else
            {
                mode.text = "Бесконечный режим (нет)";
                GameController.instance.mode = 0;
            }
        }
    }

    private void updateCircle()
    {
        imageCircle.fillAmount = timer / 2;
    }
}
