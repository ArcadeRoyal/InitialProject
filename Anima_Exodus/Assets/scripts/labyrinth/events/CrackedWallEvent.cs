using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UI; 

namespace Labyrinth.Events
{
    public class CrackedWallEvent : MonoBehaviour, ICheckEvent
    {

        public string checktext = "Inspect";
        public string dialogID = "TestCrackedWallText"; 

        private DialogSystem dialog;
        private OverlayManager overlay;
        private bool locked = true; 

        public string CheckText
        {
            get
            {
                return checktext; 
            }
        }

        private void Awake()
        {
            dialog = GameObject.Find("Dialog_System").GetComponent<DialogSystem>();
            overlay = GameObject.Find("Game_Overlay").GetComponent<OverlayManager>(); 
        }

        public IEnumerator RunEvent(GameObject o )
        {
            GameManager.instance.Paused = true; 
            Vector3Int newpos;
            if (AEUtilities.PosToInt(o.transform.position) != AEUtilities.PosToInt(transform.position + transform.forward))
                if (locked)
                {
                    StartCoroutine(dialog.PlayEvent(dialogID));
                    yield break;
                }
                else
                    newpos = AEUtilities.PosToInt(transform.position + transform.forward);
            else
                newpos = AEUtilities.PosToInt(transform.position - transform.forward);

            overlay.FadeIn(Color.black, 0.5f); 
            yield return new WaitForSeconds(0.5f);

            o.transform.position = newpos;
            yield return new WaitForSeconds(0.1f);

            overlay.FadeOut(0.5f);
            yield return new WaitForSeconds(0.5f);
            locked = false; 
            GameManager.instance.Paused = false;  
        }

    }
}


