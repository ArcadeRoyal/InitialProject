using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Labyrinth.Events
{
    public interface ICheckEvent
    {
        string CheckText
        {
            get; 
        }

        IEnumerator RunEvent(GameObject o); 
    }
}
