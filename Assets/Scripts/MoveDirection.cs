using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDirection : MonoBehaviour
{
    public Vector3 direction { private set; get; }
    private Transform transform;
    private Ray ray;
    private RaycastHit hit = new RaycastHit();
    private void Awake()
    {
        transform = gameObject.transform;
    }

    private void Update()
    {
        ray = new Ray(transform.position, transform.forward);

        if(Physics.Raycast(ray, out hit) && hit.collider.tag == "Cylinder")
        {
            Debug.DrawLine(ray.origin, hit.point);
            direction = hit.point;
        }
    }
}
