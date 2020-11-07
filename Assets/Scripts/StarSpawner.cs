using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    [SerializeField] int StartStarsCount = 5;
    Vector3 startPos;
    [SerializeField] float range = 1f;
    [SerializeField] GameObject sphere;
    int difficulty = 0;

    void Start()
    {
        difficulty = AngleHandler.instance.diff;
        startPos = gameObject.transform.position;
        for (int i = 0; i < StartStarsCount; i++)
        {
            PlaceStars();
        }
    }

    public void PlaceStars()
    {
        Ray ray = new Ray(startPos + new Vector3(0, Random.Range(-startPos.y + range, startPos.y + range), 0), new Vector3(Random.Range(-180, 180), 0, Random.Range(difficulty, 180)));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 10f))
        {
            if (hit.collider.tag == "Cylinder")
            {
                SpawnStars(hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
            }
        }
    }

    void SpawnStars(Vector3 pos, Quaternion rot)
    {
        GameObject.Instantiate(sphere, pos, rot);
    }

    public void ChangeDifficulty()
    {
        if (difficulty == 0)
        {
            difficulty = -180;
        }
        else
        {
            difficulty = 0;
        }
    }
}
