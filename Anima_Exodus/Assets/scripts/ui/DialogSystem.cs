using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Labyrinth; 

namespace UI
{
    public class DialogSystem : MonoBehaviour
    {

        public Text dialog;
        public GameObject nameBox;
        public Text nameText;
        public int textSpeed = 1; 

        private Animator animator;
        private bool displaying = false;
        private bool printing = false; 

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public void OpenWindow()
        {
            if (!displaying)
                animator.SetTrigger("open_window");
        }

        public void CloseWindow()
        {
            if (displaying)
                animator.SetTrigger("close_window");
        }

        public void SetWindowOpen()
        {
            displaying = true; 
        }

        public void SetWindowClose()
        {
            displaying = false; 
        }

        public IEnumerator PlayEvent(string dialogID)
        {
            GameManager.instance.Paused = true; 
            DialogEvent e = DialogDictionary.instance.GetEvent(dialogID);
            if (e == null)
            {
                GameManager.instance.Paused = false;
                yield break;
            }
                
            OpenWindow();
            nameBox.SetActive(false);
            dialog.text = ""; 
            while (!displaying)
                yield return null; 

            for (int i = 0; i < e.Dialog.Count; i++ )
            {
                StartCoroutine(PlayNode(e.Dialog[i]));
                while (printing) 
                    yield return null;

                yield return null;

                while (!Input.GetButtonDown("Submit")) 
                    yield return null; 
            } 

            dialog.text = "";
            nameBox.SetActive(false);
            CloseWindow();
            while (displaying)
                yield return null;
            GameManager.instance.Paused = false; 
        }

        private IEnumerator PlayNode(DialogNode n)
        {
            printing = true; 

            dialog.text = ""; 

            if (n.Name != "")
            {
                nameBox.SetActive(true); 
                nameText.text = n.Name; 
            }

            for (int i = 0; i < n.Line.Length; i += textSpeed )
            {
                dialog.text = n.Line.Substring(0, i);
                if (Input.GetButtonDown("Submit")) 
                    break; 
                yield return null; 
            }

            dialog.text = n.Line; 

            printing = false; 

        }

    }
}


