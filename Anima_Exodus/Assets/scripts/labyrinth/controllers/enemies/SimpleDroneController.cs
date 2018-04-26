using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Labyrinth.Controllers 
{ 
    public class SimpleDroneController : BaseController
    {
        private int stepCount = 0;
        private bool turned = false;  
        public override string NextMove(out bool endTurn)
        {
            if (stepCount > 1 && turned)
            {
                stepCount = 0;
                turned = false; 
            }

            if (stepCount < 2)
            {
                stepCount++;
                endTurn = true;
                return "step";
            }
            else if (!turned)
            {
                turned = true; 
                endTurn = false;
                return "turn_180";
            }
            endTurn = true;
            return ""; 
            
        }

    }

} 