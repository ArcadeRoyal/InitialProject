using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Labyrinth.Animation
{
    public abstract class TripTrigger : StateMachineBehaviour
    {
        public string trigger;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (CheckTrigger(animator.gameObject))
                animator.SetTrigger(trigger); 
        }

        public abstract bool CheckTrigger(GameObject o ); 

    }
}



