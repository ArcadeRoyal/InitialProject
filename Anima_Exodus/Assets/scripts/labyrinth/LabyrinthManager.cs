using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Labyrinth.Controllers; 

namespace Labyrinth
{
    public class LabyrinthManager : MonoBehaviour
    {
        public List<GameObject> enemies;
        public List<GameObject> allies;

        private GameObject player;
        private int turn = 0; 

        private void Awake()
        {
            player = GameObject.Find("Player");
            player.GetComponent<TurnTracker>().MyTurn = true; 
        }

        private void Update()
        {

            CheckObjectsExist(); 

            switch (turn)
            {
                case 0:
                    if ( player.GetComponent<TurnTracker>().MyTurn == false)
                    {
                        TakeTurn(allies);
                        turn++; 
                    }
                    break;
                case 1: 
                    if (CheckTurnOver(allies))
                    {
                        TakeTurn(enemies);
                        turn++; 
                    }
                    break; 
                case 2: 
                    if (CheckTurnOver(enemies) && CheckAllIdle())
                    {
                        player.GetComponent<TurnTracker>().MyTurn = true;
                        turn = 0; 
                    }
                    break; 
            }
        }

        public bool CheckTurnOver(List<GameObject> o ) 
        {
            bool temp = true;
            for (int i = 0; i < o.Count; i++)
                if (o[i].GetComponent<TurnTracker>() != null)
                    temp = temp && !o[i].GetComponent<TurnTracker>().MyTurn;
            return temp; 
        }

        public void TakeTurn(List<GameObject> o)
        {
            for (int i = 0; i < o.Count; i++)
                if (o[i].GetComponent<TurnTracker>() != null)
                    o[i].GetComponent<TurnTracker>().MyTurn = true;
        } 

        public bool CheckAllIdle()
        {
            bool value = player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("idle"); 
            for (int i = 0; i < enemies.Count; i++ ) 
                value = value && enemies[i].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("idle");
            for (int i = 0; i < allies.Count; i++)
                value = value && allies[i].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("idle");
            return value; 
        }

        public void CheckObjectsExist()
        {
            for (int i = 0; i < enemies.Count;)
                if (enemies[i] == null)
                    enemies.RemoveAt(i);
                else
                    i++; 
            for (int i = 0; i < allies.Count; i++)
                if (allies[i] == null)
                    allies.RemoveAt(i);
                else
                    i++;
        }

    }
}
