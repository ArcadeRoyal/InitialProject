﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Labyrinth.Controllers
{
    public static class LabyrinthInteractions 
    {

        public static IEnumerator JumpDown(GameObject o, Vector3Int target)
        {
            
            if (AEUtilities.Adjacent(o, target) && CheckAnimatable(o))
            {
                GameManager.instance.Paused = true; 
                TurnToFace(o, target);
                yield return null;
                while (!o.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("idle"))
                    yield return null;
                o.GetComponent<Animator>().SetTrigger("jump_down");
                yield return null; 
                while (!o.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("idle"))
                    yield return null;
                GameManager.instance.Paused = false;

            }

        }

        public static IEnumerator Attack(GameObject subject, GameObject target)  
        {
            if (CheckAnimatable(subject) && CheckAnimatable(target))
            {
                GameManager.instance.Paused = true;
                while (!CheckIdle(subject) || !CheckIdle(target))
                {
                    yield return null;
                }
                TurnToFace(subject, AEUtilities.PosToInt(target.transform.position));
                TurnToFace(target, AEUtilities.PosToInt(subject.transform.position));
                yield return null;
                while (!CheckIdle(subject) || !CheckIdle(target))
                {
                    yield return null;
                }
                subject.GetComponent<Animator>().SetTrigger("attack");
                target.GetComponent<Animator>().SetTrigger("defend");
                yield return null;
                while (!CheckIdle(subject) || !CheckIdle(target))
                {
                    yield return null;
                }
                Debug.Log("Animations should be finished.Idle boolean values for both entitie are: " +
                          subject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("idle") + " " +
                          target.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("idle"));
                GameManager.instance.Paused = false; 

            }
        }

        public static IEnumerator JumpOn(GameObject player, GameObject target)
        {
            if (CheckAnimatable(player) && CheckAnimatable(target))
            {
                GameManager.instance.Paused = true;
                while (!CheckIdle(player) || !CheckIdle(target))
                {
                    yield return null;
                }
                TurnToFace(player, AEUtilities.PosToInt(target.transform.position));
                TurnToFace(target, AEUtilities.PosToInt(player.transform.position));
                yield return null;
                while (!CheckIdle(player) || !CheckIdle(target))
                {
                    yield return null;
                }
                player.GetComponent<Animator>().SetTrigger("jump_attack");
                target.GetComponent<Animator>().SetTrigger("jump_bonk");
                yield return null;
                while (!CheckIdle(player) || target != null)
                {
                    yield return null;
                }
                GameManager.instance.Paused = false;

            }
        }

        public static IEnumerator Tackle(GameObject player, GameObject target)
        {
            if (CheckAnimatable(player) && CheckAnimatable(target))
            {
                GameManager.instance.Paused = true;
                while (!CheckIdle(player) || !CheckIdle(target))
                {
                    yield return null;
                }
                TurnToFace(player, AEUtilities.PosToInt(target.transform.position));
                TurnToFace(target, AEUtilities.PosToInt(player.transform.position));
                yield return null;
                while (!CheckIdle(player) || !CheckIdle(target))
                {
                    yield return null;
                }
                player.GetComponent<Animator>().SetTrigger("lunge");
                target.GetComponent<Animator>().SetTrigger("stun");
                yield return null;
                while (!CheckIdle(player) || target != null)
                {
                    yield return null;
                }
                GameManager.instance.Paused = false;

            }
        }

        public static IEnumerator Swing_Tackle(GameObject player, GameObject target)
        {
            if (CheckAnimatable(player) && CheckAnimatable(target))
            {
                GameManager.instance.Paused = true;
                while (!CheckIdle(player) || !CheckIdle(target))
                {
                    yield return null;
                }
                TurnToFace(player, AEUtilities.PosToInt(target.transform.position));
                TurnToFace(target, AEUtilities.PosToInt(player.transform.position));
                yield return null;
                while (!CheckIdle(player) || !CheckIdle(target))
                {
                    yield return null;
                }
                player.GetComponent<Animator>().SetTrigger("swing");
                target.GetComponent<Animator>().SetTrigger("stun");
                yield return null;
                while (!CheckIdle(player) || target != null)
                {
                    yield return null;
                }
                GameManager.instance.Paused = false;

            }
        }

        private static void TurnToFace(GameObject o, Vector3Int target)
        {
            if (AEUtilities.CheckGridLinear(AEUtilities.PosToInt(o.transform.position), target))
            {
                Vector3Int adjTarget = AEUtilities.GetAdjacentInt(AEUtilities.PosToInt(o.transform.position), target);
                if (adjTarget == AEUtilities.PosToInt(o.transform.position + o.transform.right))
                    o.GetComponent<Animator>().SetTrigger("turn_right");
                else if (adjTarget == AEUtilities.PosToInt(o.transform.position + o.transform.right * -1))
                    o.GetComponent<Animator>().SetTrigger("turn_left");
                else if (adjTarget == AEUtilities.PosToInt(o.transform.position + o.transform.forward * -1))
                    o.GetComponent<Animator>().SetTrigger("turn_180");
            }
            
        }

        private static bool CheckAnimatable(GameObject o)
        {
            return o.GetComponent<Animator>() != null; 
        }

        private static bool CheckIdle(GameObject o)
        {
            return o.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("idle"); 
        }

    }
}

