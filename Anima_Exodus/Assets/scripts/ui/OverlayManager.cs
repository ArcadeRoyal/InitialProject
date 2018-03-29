using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

namespace UI
{
    public class OverlayManager : MonoBehaviour
    {
        private RawImage overlay; 
        // Use this for initialization
        void Start()
        {
            overlay = GetComponent<RawImage>();
            overlay.color = new Color(1f, 1f, 1f, 1f); 
            overlay.canvasRenderer.SetAlpha(0f); 
        }

        public void FadeIn(Color c, float time)
        {
            overlay.color = c;
            overlay.CrossFadeAlpha(1f, time, false); 
        }

        public void FadeOut(float time)
        {
            overlay.CrossFadeAlpha(0f, time, false); 
        }

        public IEnumerator Flash(Color c, float t)
        {
            overlay.color = c;
            yield return new WaitForSeconds(t);
            overlay.color = Color.clear; 
        }
    }
}


