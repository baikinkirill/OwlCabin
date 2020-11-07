using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDirection : MonoBehaviour
{
    public Vector3 direction { private set; get; }
    public Transform gazeTransform { private set; get; }
    private Transform transform;
    private Ray ray;
    private RaycastHit hit = new RaycastHit();
    private GameObject gaze;
    private void Awake()
    {
        transform = gameObject.transform;
        gaze = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        gaze.GetComponent<MeshRenderer>().enabled = false;
        gaze.GetComponent<SphereCollider>().enabled = false;
        gazeTransform = gaze.transform;
    }

    private void Update()
    {
        ray = new Ray(transform.position, transform.forward);

        if(Physics.Raycast(ray, out hit) && hit.collider.tag == "Cylinder")
        {
            Debug.DrawLine(ray.origin, hit.point);
            direction = hit.point;
            gaze.transform.position = hit.point;
        }
    }
}
