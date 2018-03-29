using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Labyrinth.Controllers 
{ 
    
    public class TransformUtility : MonoBehaviour {

        private bool adjusting;
        private Animator animator;
        private ActiveTracker activeTracker; 

        public bool Adjusting 
        { 
            get 
            { 
                return adjusting;
             
            }
        }

        private void Awake() 
        {
            animator = GetComponent<Animator>();
            activeTracker = GetComponent<ActiveTracker>(); 
        }

        public IEnumerator TurnToFace(Vector3Int target) 
        {
            if (!AEUtilities.CheckGridLinear(AEUtilities.PosToInt(transform.position), target))
                yield break;

            Vector3Int trueTarget = AEUtilities.GetAdjacentInt(AEUtilities.PosToInt(transform.position), target);

            int numRightTurns = 0;
            if (AEUtilities.PosToInt(transform.right * -1) == trueTarget)
            {
                adjusting = true;
                animator.SetTrigger("turn_left");
                yield return null;
                while (!animator.GetCurrentAnimatorStateInfo(0).IsName("idle"))
                    yield return null;
                adjusting = false;
            }
            else if (AEUtilities.PosToInt(transform.right) == trueTarget)
                numRightTurns = 1;
            else if (AEUtilities.PosToInt(transform.forward * -1) == trueTarget) 
                numRightTurns = 2;
            else
                yield break;

            adjusting = true;
            for (int i = 0; i < numRightTurns; i++ ) 
            {
                animator.SetTrigger("turn_right");
                yield return null;
                while (!animator.GetCurrentAnimatorStateInfo(0).IsName("idle"))
                {
                    yield return null;
                }
            }
            adjusting = false; 
        } 

    }

}


