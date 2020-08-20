using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sync : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //if movement is greater than 0 the archer has moved therefore 
       if(animator.GetFloat("MoveMagnitude")>0.0f)
       {
           Animator animatorBottom = animator.gameObject.transform.parent.GetComponent<PlayerController>().animatorBottom;
           float normalizeTime = animatorBottom.GetCurrentAnimatorStateInfo(0).normalizedTime;
           animator.Play("Run",-1,normalizeTime);

       }
    }
//https://www.youtube.com/watch?v=lh3uam5VUaQ&t=2s he doesnt really explain it amazingly but this is the video where he does this.
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

//
