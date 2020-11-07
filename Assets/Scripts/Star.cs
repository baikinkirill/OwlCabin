using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public int starCost { private set; get; }
    StarSpawner SP;

    private void Start()
    {
        SP = GameObject.Find("StarSpawner").GetComponent<StarSpawner>();
    }

    public void onCatch()   //Вызывается, когда самолет хватает звездочку. 
    {
        SP.PlaceStars();
        Destroy(gameObject);
    }
}
