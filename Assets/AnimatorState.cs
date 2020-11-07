using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorState : StateMachineBehaviour
{
    [SerializeField] private PlaneRotation planeRotation;
    private void Awake()
    {
        planeRotation = GameObject.Find("planeRotator").GetComponent<PlaneRotation>();
    }

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        planeRotation.updFlightStatus(true);
    }
}
