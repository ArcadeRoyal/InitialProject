using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Labyrinth.Controllers
{ 
    public class TurnTracker : MonoBehaviour
    {

        private bool myTurn = false; 

        public bool MyTurn
        {
            get
            {
                return myTurn; 
            }
            set
            {
                myTurn = value;
                Debug.Log("Some File"); 
            }
        }

        public void EndTurn()
        {
            myTurn = false; 
            ITurnTickable[] tickables = GetComponents<ITurnTickable>(); 
            for (int i = 0;  i < tickables.Length; i++ )
            {
                tickables[i].TurnTick(); 
            }
        }

    }
}

