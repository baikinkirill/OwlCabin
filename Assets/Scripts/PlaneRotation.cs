using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneRotation : MonoBehaviour
{
    [SerializeField] private MoveDirection moveDirection;
    [Range(0, 5)]
    [SerializeField] private float speed = 3f;

    private void FixedUpdate()
    {
        LookAt(moveDirection.direction);
    }

    public void LookAt(Vector3 pos)
    {
        gameObject.transform.rotation = Quaternion.RotateTowards(gameObject.transform.rotation, Quaternion.LookRotation(pos), speed);
    }
}
