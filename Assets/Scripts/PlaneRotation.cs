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
    [SerializeField] private Animator planeAnimator;
    private float angle;
    private bool flightStatus = true;   //Отрицательный пока происходит разворот самолета.

    private void Awake()
    {

    }

    private void FixedUpdate()
    {
        Vector3 targetDir = moveDirection.direction - gameObject.transform.position;
        targetDir = new Vector3(targetDir.x, 0, targetDir.z);
        Vector3 planeDir = plane.position - gameObject.transform.position;
        planeDir = new Vector3(planeDir.x, 0, planeDir.z);
        angle = Vector3.SignedAngle(targetDir, planeDir, gameObject.transform.up);


        if (Mathf.Abs(angle) > ignoreAngle)
        {
            planeAnimator.SetBool("waiting", false);
            if (angle < 0)
            {
                planeAnimator.SetBool("isRight", true);
                planeAnimator.SetBool("fromLeftToRight", true);
                planeAnimator.SetBool("isLeft", false);
            }
            else
            {
                planeAnimator.SetBool("isLeft", true);
                planeAnimator.SetBool("fromRightToLeft", true);
                planeAnimator.SetBool("isRight", false);
            }
        }
        else
        {
            planeAnimator.SetBool("waiting", true);
            planeAnimator.SetBool("isLeft", false);
            planeAnimator.SetBool("isRight", false);
            flightStatus = false;
        }

        if (!flightStatus) { return; }

        LookAt(moveDirection.direction);
    }

    public void updFlightStatus(bool canFligt)
    {
        flightStatus = canFligt;
    }


    private void Update()
    {
        //PlaneLookAt();
    }

    public void LookAt(Vector3 pos)
    {
        gameObject.transform.rotation = Quaternion.RotateTowards(gameObject.transform.rotation, Quaternion.LookRotation(pos), speed);
    }

    public void PlaneLookAt()
    {
        plane.rotation = Quaternion.Lerp(moveDirection.gazeTransform.rotation, plane.rotation, Time.deltaTime * 600f);
    }
}
