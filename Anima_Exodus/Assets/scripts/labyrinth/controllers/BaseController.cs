using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Labyrinth.Controllers
{
    public abstract class BaseController : MonoBehaviour
    {

        protected bool isInteracting;

        private Animator animator;
        private TurnTracker turnTracker;

        // *********** METHODS **************
        protected void Awake()
        {
            animator = GetComponent<Animator>();
            turnTracker = GetComponent<TurnTracker>();
        }

        protected void Update()
        {

            if (turnTracker.MyTurn && animator.GetCurrentAnimatorStateInfo(0).IsName("idle") && !GameManager.instance.Paused)
            {
                bool endTurn = false;
                string action = NextMove(out endTurn);
                if (action != "")
                {
                    animator.SetTrigger(action);
                }
                    

                turnTracker.MyTurn = !endTurn; 

            }
            
        }

        public abstract string NextMove(out bool endTurn); 

    }
}

