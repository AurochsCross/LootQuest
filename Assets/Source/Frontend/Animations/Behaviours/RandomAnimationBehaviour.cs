using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Frontend.Animations.Behaviours {
    public class RandomAnimationBehaviour : StateMachineBehaviour {
        public string TriggeredParameter;
        public int StateCount = 0;
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            animator.SetInteger(TriggeredParameter, Random.Range(0, StateCount));
        }
    }
}