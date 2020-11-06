using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public int starCost { private set; get; }
    public void onCatch()   //Вызывается, когда самолет хватает звездочку. 
    {
        Destroy(gameObject);
    }
}
