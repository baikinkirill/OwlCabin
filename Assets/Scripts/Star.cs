using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public int starCost = 1;
    StarSpawner SP;
    AudioSource AS;
    [SerializeField] AudioClip AC;
    [SerializeField] GameObject model;

    private void Start()
    {
        SP = GameObject.Find("StarSpawner").GetComponent<StarSpawner>();
        AS = gameObject.GetComponent<AudioSource>();
    }

    public void onCatch()   //Вызывается, когда самолет хватает звездочку. 
    {
        AS.PlayOneShot(AC, 0.5f);
        SP.PlaceStars();
        StartCoroutine("destroy");
    }
    IEnumerator destroy()
    {
        Destroy(model);
        yield return new WaitForSeconds(AC.length);
        Destroy(gameObject);
    }
}
