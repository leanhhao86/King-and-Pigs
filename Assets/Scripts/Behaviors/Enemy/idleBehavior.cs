using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idleBehavior : StateMachineBehaviour
{

    [Header ("Idle Behaviour")]
    [SerializeField] private float idleDuration;
    
    private float idleTimer;
    private int rand;
    private bool updated;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       idleTimer = 0f;
       updated = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        idleTimer += Time.deltaTime;

        if (idleTimer > idleDuration && !updated)
        {
            updated = true;
            rand = Random.Range(0, 3);
            // Debug.Log("random: " + rand.ToString());
            // Walk
            if (rand == 0)
            {
                animator.SetTrigger("walk");
            }
            else if (rand == 1)
            {
                animator.SetTrigger("shoot");
            }
            else if (rand == 2)
            {
                animator.SetTrigger("dash");
            }
        }
       
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
