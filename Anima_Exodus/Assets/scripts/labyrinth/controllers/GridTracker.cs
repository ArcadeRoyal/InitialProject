using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Labyrinth.Controllers
{
    public class GridTracker : MonoBehaviour
    {

        public void SnapToGrid()
        {
            transform.position = AEUtilities.PosToInt(transform.position);
            transform.rotation = AEUtilities.RotToCardinal(transform.rotation);
        }

    }
}
