using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleScroll : MonoBehaviour
{
    [SerializeField] private GameObject indecator;
    [SerializeField] private Image circleImage;
    private Transform indicatorTramsform;

    private void Awake()
    {
        indicatorTramsform = indecator.transform;
    }

    private void FixedUpdate()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && hit.collider.tag == "ui")
        {
            indecator.SetActive(true);
            Debug.DrawLine(transform.position, hit.point, Color.red);
            indicatorTramsform.position = hit.point + new Vector3(0, 0, 0.2f);
        }
        else
        {
            indecator.SetActive(false);
        }
    }
}
    