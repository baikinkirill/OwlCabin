using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleScroll : MonoBehaviour
{
    [SerializeField] private GameObject indecator;
    private void FixedUpdate()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && hit.collider.tag == "ui")
        {
            indecator.SetActive(true);
        }
        else
        {
            indecator.SetActive(false);
        }
    }
}
    