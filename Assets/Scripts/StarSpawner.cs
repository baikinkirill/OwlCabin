using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    Vector3 startPos;
    [SerializeField] float range = 1f;
    [SerializeField] GameObject sphere;
    void Start()
    {
        startPos = gameObject.transform.position;
    }

    void PlaceStars()
    {
        Ray ray = new Ray(startPos + new Vector3(0, Random.Range(-startPos.y + range, startPos.y + range)), new Vector3(Random.Range(-180, 180), 0, Random.Range(-180, 180)));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            Debug.Log(hit.collider.tag);
            if (hit.collider.tag == "Cylinder")
            {
                Debug.DrawRay(ray.origin, hit.point, Color.red);
                SpawnStars(hit.point, hit.transform.rotation);
            }
        }
    }

    void SpawnStars(Vector3 pos, Quaternion rot)
    {
        GameObject.Instantiate(sphere, pos, rot);
    }
}
