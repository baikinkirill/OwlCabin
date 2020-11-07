using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneRotation : MonoBehaviour
{
    [SerializeField] private MoveDirection moveDirection;
    [Range(0, 5)]
    [SerializeField] private float speed = 3f;
    [SerializeField] private Transform plane;
    [Range(0f, 50f)] [SerializeField] private float ignoreAngle;
    [SerializeField] private Rigidbody rigidbody;
    private float angle;
    private Direction localDirection = Direction.Watting;
    private bool flightStatus = true;   //Отрицательный пока происходит разворот самолета.

    private void FixedUpdate()
    {
        Vector3 targetDir = moveDirection.direction - gameObject.transform.position;
        targetDir = new Vector3(targetDir.x, 0, targetDir.z);
        Vector3 planeDir = plane.position - gameObject.transform.position;
        planeDir = new Vector3(planeDir.x, 0, planeDir.z);
        angle = Vector3.SignedAngle(targetDir, planeDir, gameObject.transform.up);
        
        if (Mathf.Abs(angle) > ignoreAngle)
        {
            if (angle < 0)
            {
                plane.localScale = new Vector3(plane.localScale.x, plane.localScale.y, Mathf.Abs(plane.localScale.z) * -1);
                localDirection = Direction.Right;
            }
            else
            {
                localDirection = Direction.Left;
                plane.localScale = new Vector3(plane.localScale.x, plane.localScale.y, Mathf.Abs(plane.localScale.z));
            }
        }
        else
        {
            localDirection = Direction.Watting;
        }

        if(localDirection == Direction.Watting || !flightStatus) { return; }

        LookAt(moveDirection.direction);
    }

    private void Update()
    {
        PlaneLookAt();
    }

    public void LookAt(Vector3 pos)
    {
        gameObject.transform.rotation = Quaternion.RotateTowards(gameObject.transform.rotation, Quaternion.LookRotation(pos), speed);
    }

    public void PlaneLookAt()
    {
        plane.rotation = Quaternion.Lerp(moveDirection.gazeTransform.rotation, plane.rotation, Time.deltaTime * 600f);
    }

    enum Direction
    {
        Watting,
        Left,
        Right,
        ChangeDirection
    }

    
}
