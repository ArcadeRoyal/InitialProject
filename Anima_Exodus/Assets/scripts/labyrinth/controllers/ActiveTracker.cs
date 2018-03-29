using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Labyrinth.Controllers
{
    public class ActiveTracker : MonoBehaviour
    {

        private bool active; 

        public bool Active
        {
            get
            {
                return active;  
            }
        }

        public void StartMove()
        {
            active = true; 
        }

        public void StopMove()
        {
            active = false; 
        }

        public void PauseGame()
        {
            GameManager.instance.Paused = true; 
        }

        public void UnpauseGame()
        {
            GameManager.instance.Paused = false;  
        }
    }
}


