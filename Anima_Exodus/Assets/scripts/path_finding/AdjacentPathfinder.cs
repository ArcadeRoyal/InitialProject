using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding
{
    public class AdjacentPathfinder : BasePathfinder
    {

        protected override Vector3Int[] GetValidMovePool(Vector3Int pos, string[] validTags)
        {

            List<Vector3Int> moveList = new List<Vector3Int>();

            Vector3Int up = new Vector3Int(pos.x, pos.y, pos.z + 1);
            if (AEUtilities.CheckTagsAtLocation(up, validTags))
                moveList.Add(up);
            Vector3Int down = new Vector3Int(pos.x, pos.y, pos.z - 1);
            if (AEUtilities.CheckTagsAtLocation(down, validTags))
                moveList.Add(down);
            Vector3Int right = new Vector3Int(pos.x + 1, pos.y, pos.z);
            if (AEUtilities.CheckTagsAtLocation(right, validTags))
                moveList.Add(right);
            Vector3Int left = new Vector3Int(pos.x - 1, pos.y, pos.z);
            if (AEUtilities.CheckTagsAtLocation(left, validTags))
                moveList.Add(left);
            return moveList.ToArray(); 
        }

        protected override int GetHeuristic(Vector3Int pos, Vector3Int target)
        {
            return Mathf.Abs(target.x - pos.x) + Mathf.Abs(target.z - pos.z);     
        }

    }
}


