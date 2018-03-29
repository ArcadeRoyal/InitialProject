using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Labyrinth.Events
{
    public class PitTrap : Trap
    {

        protected override IEnumerator SpringTrap(GameObject o)
        {
            if (o.GetComponent<GameTags>().CheckTag("airborne"))
                yield break;
            else
                o.GetComponent<Animator>().SetTrigger("fall"); 
        }

    }
}


