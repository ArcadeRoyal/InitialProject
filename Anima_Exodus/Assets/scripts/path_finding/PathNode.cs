using System; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding 
{ 

    public class PathNode : IEquatable<PathNode>
    {

        private Vector3Int pos;
        private float cost, heuristic;
        private PathNode parent;

        public PathNode(PathNode parent, float cost, float heuristic, Vector3Int pos)
        {
            this.parent = parent;
            this.cost = cost;
            this.heuristic = heuristic;
            this.pos = pos;
        }

        public float F
        {
            get
            { 
                return heuristic + cost;
            }
        }

        public float Cost 
        {
            get 
            {
                return cost; 
            }
            set
            {
                cost = value; 
            }
        }

        public Vector3Int Pos 
        { 
            get 
            {
                return pos; 
            }
        }

        public PathNode Parent
        {
            get
            {
                return parent;
            }
            set
            {
                parent = value;
            }
        }

        public bool Equals(PathNode n)
        {
            return n.Pos == pos; 
        }

        public List<Vector3Int> GetPath() 
        {
            List<Vector3Int> path;
            if (parent == null)
                path = new List<Vector3Int>();
            else
                path = parent.GetPath();

            path.Add(pos);
            return path; 

        }

    }

}



