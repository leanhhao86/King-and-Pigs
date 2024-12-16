using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkBehavior : StateMachineBehaviour
{
    private const int LEFT = -1;
    private const int RIGHT = 1;

    private KingPig kP;
    private int rand;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        kP = animator.GetComponent<KingPig>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if ((kP.currentDirection == LEFT && kP.transform.position.x >= kP.leftEdge.position.x) ||
            (kP.currentDirection == RIGHT && kP.transform.position.x <= kP.rightEdge.position.x))
        {   
            // Move towards current direction
            kP.MoveInDirection(kP.currentDirection, kP.moveForce);

        } else 
        {
            rand = Random.Range(0,2);
            
            if (rand == 0)
            {
                animator.SetTrigger("idle");                
            }

            // Move the opposite direction
            kP.MoveInDirection(kP.currentDirection * -1, kP.moveForce);
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
