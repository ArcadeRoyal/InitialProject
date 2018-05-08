using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Labyrinth.Controllers 
{ 
    public class ObjectDestroyer : MonoBehaviour
    {

        public void DestroyObject() 
        {
            Destroy(gameObject); 
        }

    }
}


