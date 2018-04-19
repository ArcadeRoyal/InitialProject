using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding; 

namespace Labyrinth.Controllers 
{ 

    public class WaypointEnemyController : BaseController
    {

        public Vector3Int[] coordinates;
        public string[] validMoveTags; 

        private int coordCounter;
        private BasePathfinder pathFinder;
        private GameObject player; 

        protected override void Awake()
        {
            coordCounter = 0;
            pathFinder = GetComponent<BasePathfinder>();
            player = GameObject.Find("Player"); 
            base.Awake(); 
        }

        public override string NextMove(out bool endTurn)
        {

            if (AEUtilities.PosToInt(transform.position) == coordinates[coordCounter])
                coordCounter = (coordCounter + 1) % coordinates.Length;
            Vector3Int nextPos = pathFinder.GetMoveTowards(AEUtilities.PosToInt(transform.position), coordinates[coordCounter], validMoveTags);

            if (AEUtilities.PosToInt(transform.position + transform.forward) == nextPos)
            {
                if (player.GetComponent<PlayerController>() != null && player.GetComponent<PlayerController>().Destination == nextPos)
                {
                    StartCoroutine(LabyrinthInteractions.Attack(gameObject, player));
                    endTurn = true;
                    return "";
                }
                else
                {
                    endTurn = true;
                    return "step";
                }
            }
            else
            {
                if (nextPos == AEUtilities.PosToInt(transform.position - transform.forward) || nextPos == AEUtilities.PosToInt(transform.position + transform.right))
                {
                    endTurn = false;
                    return "turn_right";
                }
                else if (nextPos == AEUtilities.PosToInt(transform.position - transform.right))
                {
                    endTurn = false;
                    return "turn_left";
                }
                else
                {
                    endTurn = true;
                    return "";
                }
            }
        }

    }

}

