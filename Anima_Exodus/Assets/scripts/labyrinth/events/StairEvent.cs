using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UI;

namespace Labyrinth.Events
{
    public class StairEvent : MonoBehaviour, ICheckEvent
    {

        public Vector3Int destination;
        public float rotation; 
        public string checktext = "Traverse";

        private OverlayManager overlay;

        public string CheckText
        {
            get
            {
                return checktext;
            }
        }

        private void Awake()
        {
            overlay = GameObject.Find("GameOverlay").GetComponent<OverlayManager>();
        }

        public IEnumerator RunEvent(GameObject o)
        {
            GameManager.instance.Paused = true;

            overlay.FadeIn(Color.black, 0.5f);
            yield return new WaitForSeconds(0.5f);

            o.transform.position = destination;
            o.transform.rotation = Quaternion.Euler(0, rotation, 0); 
            yield return new WaitForSeconds(0.1f);

            overlay.FadeOut(0.5f);
            yield return new WaitForSeconds(0.5f);

            GameManager.instance.Paused = false;
        }

    }
}


