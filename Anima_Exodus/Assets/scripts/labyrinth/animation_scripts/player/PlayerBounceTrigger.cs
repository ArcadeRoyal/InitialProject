using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Labyrinth.Animation
{
    public class PlayerBounceTrigger : TripTrigger
    { 
        public Vector3Int target;
        public string[] validMoveList; 

        public override bool CheckTrigger( GameObject o )
        {
            for (int i = 0; i < validMoveList.Length; i++)
                if (AEUtilities.CheckTagAtLocation(AEUtilities.PosToInt(o.transform.position) +
                    AEUtilities.PosToInt((o.transform.rotation * target)), validMoveList[i]))
                    return false;
            return true; 
        }

    }

}


