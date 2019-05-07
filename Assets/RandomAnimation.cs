using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAnimation : StateMachineBehaviour
{
    public string TriggeredParameter;
    public int StateCount = 0;

    // OnStateEnter is called before OnStateEnter is called on any state inside this state machine
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        animator.SetInteger(TriggeredParameter, Random.Range(0, StateCount));
    }
}
