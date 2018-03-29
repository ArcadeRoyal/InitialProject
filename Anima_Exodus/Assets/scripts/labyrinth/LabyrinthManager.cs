using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Labyrinth.Controllers; 

namespace Labyrinth
{
    public class LabyrinthManager : MonoBehaviour
    {
        public GameObject[] enemies;
        public GameObject[] allies;

        private GameObject player;
        private int turn = 0; 

        private void Awake()
        {
            player = GameObject.Find("Player");
            player.GetComponent<TurnTracker>().MyTurn = true; 
        }

        private void Update()
        {
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
                    if (CheckTurnOver(enemies))
                    {
                        player.GetComponent<TurnTracker>().MyTurn = true;
                        turn = 0; 
                    }
                    break; 
            }
        }

        public bool CheckTurnOver(GameObject[] o ) 
        {
            bool temp = true;
            for (int i = 0; i < o.Length; i++)
                if (o[i].GetComponent<TurnTracker>() != null)
                    temp = temp && !o[i].GetComponent<TurnTracker>().MyTurn;
            return temp; 
        }

        public void TakeTurn(GameObject[] o)
        {
            for (int i = 0; i < o.Length; i++)
                if (o[i].GetComponent<TurnTracker>() != null)
                    o[i].GetComponent<TurnTracker>().MyTurn = true;
        } 

    }
}
