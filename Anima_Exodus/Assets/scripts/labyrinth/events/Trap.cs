using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Labyrinth.Events
{
    public abstract class Trap : MonoBehaviour
    {

        private bool triggered = false;

        private void Update()
        {
            if (!triggered)
            {
                GameObject o;
                if (AEUtilities.CheckTagAtLocation(AEUtilities.PosToInt(transform.position), "moving_entity", out o))
                {
                    triggered = true;
                    StartCoroutine(SpringTrap(o));
                }
                    
            } 
            else
            {
                if (!AEUtilities.CheckTagAtLocation(AEUtilities.PosToInt(transform.position), "moving_entity"))
                    triggered = false; 
            }
        }

        protected abstract IEnumerator SpringTrap(GameObject o); 

    }

}

public class ITrap : MonoBehaviour {

	
	
	// Update is called once per frame
	void Update () {
		
	}
}
