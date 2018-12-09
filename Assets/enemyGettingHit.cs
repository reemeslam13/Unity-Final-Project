﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyGettingHit: StateMachineBehaviour {

    public string triggerToReset;
    public int enterOrExit;

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        animator.gameObject.GetComponentInParent<VampireController>().isAttacking = false;
        Debug.Log("Not Attacking Anymore");
        animator.gameObject.GetComponentInParent<VampireController>().isBeingHit = true;
        Debug.Log("Ouch im hit");
        if(enterOrExit == 0){
            animator.ResetTrigger(triggerToReset);
        }
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	//override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        animator.gameObject.GetComponentInParent<VampireController>().isBeingHit = false;
        animator.gameObject.transform.parent.GetComponent<VampireController>().canAttack = true;
        if (enterOrExit == 1)
        {
            animator.ResetTrigger(triggerToReset);
        }
	}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
