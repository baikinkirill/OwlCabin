using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaneChanger : MonoBehaviour
{
    [SerializeField] Animator Animator;
    [SerializeField] TextMesh stars;
    [SerializeField] GameObject EndGamePanel;
    [SerializeField] GameObject[] planes;
    [SerializeField] int[] onStarChane; //При таких кол-вах собранных звезд будет меняться самолет.
    int selectedPlane = 0;

    int _points;
    int points 
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
        if(other.tag != "Star") { return; }
        Star star = other.GetComponent<Star>();
        points += star.starCost;
        star.onCatch();
        stars.text = points.ToString();
        if (GameController.instance.mode == 0)
        {
            if (points >= onStarChane[onStarChane.Length - 1] + 50)
            {
                StartCoroutine("EndGame");
            }
        }
    }

    void changePlane()
    {
        for (int i = 0; i < onStarChane.Length; ++i)
        {
            if(onStarChane[i] == points && ++selectedPlane < planes.Length)
            {
                for(int y = 0; y < planes.Length; ++y)
                {
                    bool active = (selectedPlane == y) ? true : false;
                    planes[y].SetActive(active);
                    //if (selectedPlane == planes.Length - 1)
                    //{
                    //    Animator.enabled = false;
                    //}
                }
            }
        }
    }

    IEnumerator EndGame()
    {
        EndGamePanel.SetActive(true);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(0);
    }

    public bool isUfo() //UFO - last plane
    {
        return (onStarChane[onStarChane.Length - 2] <= points) ? true : false;
    }
}
