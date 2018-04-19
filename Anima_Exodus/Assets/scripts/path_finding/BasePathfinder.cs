using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding 
{ 

    public abstract class BasePathfinder : MonoBehaviour
    {

        public  Vector3Int GetMoveTowards( Vector3Int pos, Vector3Int target, string[] validTags ) 
        {

            Vector3Int[] temp = GetPathTowards(pos, target, validTags);
            if (temp.Length > 1)
                return temp[1];
            else
                return pos; 

        }

        public Vector3Int[] GetPathTowards ( Vector3Int pos, Vector3Int target, string[] validTags ) 
        {

            Vector3Int[] dummyList = new Vector3Int[0]; 
            if (pos == target || pos.y != target.y) 
                return dummyList; 

            List<PathNode> openList = new List<PathNode>();
            List<PathNode> closedList = new List<PathNode>();

            PathNode active = new PathNode(null, 0, GetHeuristic(pos, target), pos);
            openList.Add(active); 

            while (openList.Count > 0) 
            {
                active = GetBestNode(openList); 

                if (active.Pos == target)
                    return active.GetPath().ToArray();
                
                closedList.Add(active); 
                openList.Remove(active);

                Vector3Int[] movePool = GetValidMovePool(active.Pos, validTags);
                for (int i = 0; i < movePool.Length; i++ ) 
                {
                    PathNode node = new PathNode(active, active.Cost + 1, GetHeuristic(movePool[i], target), movePool[i]); 
                    if (closedList.Contains(node))
                    {
                        if (closedList[closedList.IndexOf(node)].F > node.F)
                            closedList[closedList.IndexOf(node)].Parent = active; 
                    }  
                    else
                    {
                        openList.Add(node); 
                    }
                }
            }

            return dummyList; 
        }

        protected abstract Vector3Int[] GetValidMovePool(Vector3Int pos, string[] validTags); 

        private PathNode GetBestNode( List<PathNode> list ) 
        {
            PathNode lowest = list[0];
            for (int i = 1; i < list.Count; i++)
                if (lowest.F > list[i].F)
                    lowest = list[i];
            return lowest; 
        }

        protected abstract int GetHeuristic(Vector3Int pos, Vector3Int target);

    }

}


