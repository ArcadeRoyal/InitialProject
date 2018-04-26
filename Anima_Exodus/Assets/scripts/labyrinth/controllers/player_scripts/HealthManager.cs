using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI; 

namespace Labyrinth.Controllers 
{

    public class HealthManager : MonoBehaviour
    {

        public int maxHealth = 3;

        private int currentHealth;
        private OverlayManager overlay; 

        public int CurrentHealth 
        { 
            get 
            {
                return currentHealth; 
            }
        }

		private void Awake()
		{
            if (GameObject.Find("GameOverlay").GetComponent<OverlayManager>() != null)
                overlay = GameObject.Find("GameOverlay").GetComponent<OverlayManager>(); 
		}

		private void Start()
		{
            currentHealth = maxHealth; 
		}

        public void Damage( int damage ) 
        {

            currentHealth -= damage;
            StartCoroutine(overlay.Flash(Color.red, 0.05f)); 
        
        }

        public void Heal( int heal ) 
        {
            currentHealth += heal; 
            StartCoroutine(overlay.Flash(Color.green, 0.05f)); 
        }

	}

}

