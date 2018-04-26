using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Labyrinth.Controllers;
using UnityEngine.UI; 

namespace UI 
{ 

    public class HealthTextManager : MonoBehaviour 
    {

        private HealthManager playerHealth;
        private Text healthText; 

        private void Awake() 
        {
            playerHealth = GameObject.Find("Player").GetComponent<HealthManager>();
            healthText = GetComponent<Text>(); 
        }

		private void Update()
		{
            healthText.text = "Current Health: " + playerHealth.CurrentHealth; 
		}

	}

}


