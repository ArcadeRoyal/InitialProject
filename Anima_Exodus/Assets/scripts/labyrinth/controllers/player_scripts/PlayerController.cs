using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Labyrinth.Events; 

namespace Labyrinth.Controllers
{

    //Class to control the explorer entity
    public class PlayerController : BaseController
    {

        private Vector3Int destination; 

        public Vector3Int Destination
        {
            get
            {
                return destination; 
            }
        }

        public override string NextMove(out bool endTurn)
        {

            destination = AEUtilities.PosToInt(transform.position);

            int vert = (int)Input.GetAxisRaw("Vertical");
            int horiz = (int)Input.GetAxisRaw("Horizontal");

            if (Input.GetButtonDown("Submit"))
            {

                GameObject o;
                if (AEUtilities.CheckTagAtLocation(AEUtilities.PosToInt(transform.position + transform.forward), "check_event", out o))
                {
                    StartCoroutine(o.GetComponent<ICheckEvent>().RunEvent(gameObject));
                    endTurn = false;
                    return "";
                }
                else if (AEUtilities.CheckTagAtLocation(AEUtilities.PosToInt(transform.position + transform.forward), "hook"))
                {
                    endTurn = true;
                    destination = AEUtilities.PosToInt(transform.position + (transform.forward * 2)); 
                    if (AEUtilities.CheckTagAtLocation(AEUtilities.PosToInt(transform.position + transform.forward*2), "enemy", out o))
                    {
                        StartCoroutine(LabyrinthInteractions.Swing_Tackle(gameObject, o));
                        return ""; 
                    } 
                    else
                    {
                        return "swing"; 
                    }
                }
                else
                {
                    endTurn = true;
                    destination = AEUtilities.PosToInt(transform.position + transform.forward * 2);
                    if (AEUtilities.CheckTagAtLocation(AEUtilities.PosToInt(transform.position + transform.forward * 2), "enemy", out o))
                    {
                        StartCoroutine(LabyrinthInteractions.Tackle(gameObject, o));
                        return "";
                    }
                    else
                    {
                        return "lunge";
                    }
                }
            }
            else if (horiz == 1)
            {
                endTurn = false;
                return "turn_right";
            }
            else if (horiz == -1)
            {
                endTurn = false;
                return "turn_left";
            }
            else if (vert != 0)
            {
                Vector3Int move = AEUtilities.PosToInt(transform.position + transform.forward * vert);
                GameObject o;
                if (AEUtilities.CheckTagAtLocation(move, "pit"))
                {
                    if (AEUtilities.CheckTagAtLocation(AEUtilities.PosToInt(transform.position + transform.forward + (transform.up * -3)), "enemy", out o))
                        StartCoroutine(LabyrinthInteractions.JumpOn(gameObject, o));
                    else
                        StartCoroutine(LabyrinthInteractions.JumpDown(gameObject, move));
                    endTurn = true;
                    destination = AEUtilities.PosToInt(transform.position + transform.forward + (transform.up * -3));
                    return "";
                } else if (AEUtilities.CheckTagAtLocation(move, "enemy", out o)) 
                { 
                    StartCoroutine(LabyrinthInteractions.Attack(gameObject, o));
                    endTurn = false;
                    return "";
                }
                else if (AEUtilities.CheckTagAtLocation(move, "floor"))
                {
                    if (vert == 1)
                    {
                        endTurn = true;
                        destination = AEUtilities.PosToInt(transform.position + transform.forward); 
                        return "step_forward";
                    }
                    else if (vert == -1)
                    {
                        endTurn = true;
                        destination = AEUtilities.PosToInt(transform.position - transform.forward); 
                        return "step_back";
                    }

                }

            }

            endTurn = false;
            return ""; 

        }

    }

}


