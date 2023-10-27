using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcWalk : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public float npcSpeed = 2.0f;
    public float attackRange = 0.5f;
    public float attackSpeed;
    Transform playerLocate;
    Rigidbody2D npcRb;
    NpcVampire vampire;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerLocate = GameObject.FindGameObjectWithTag("Player").transform;
        npcRb = animator.GetComponent<Rigidbody2D>();
        vampire = animator.GetComponent<NpcVampire>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //get look at funtion
        vampire.lookAt();

        //sets up the target to be player.
        Vector2 Target = new Vector2(playerLocate.position.x, npcRb.position.y);
        //moves npcRb to player                                //time passed in seconds             
        Vector2 newPos = Vector2.MoveTowards(npcRb.position, Target, npcSpeed * Time.fixedDeltaTime);
        npcRb.MovePosition(newPos);

        if(Vector2.Distance(playerLocate.position, npcRb.position) <= attackRange)
        {
            animator.SetTrigger("Attack");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }

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
