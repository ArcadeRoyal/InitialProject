using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Labyrinth.Animations
{
    public class EyeColorChange : MonoBehaviour
    {

        public int mat_layer;
        public Color baseColor;
        public Color attackColor; 

        private Renderer meshRenderer;
        private Color currentColor; 

        // Use this for initialization
        void Awake()
        {

            meshRenderer = GetComponentInChildren<Renderer>(); 

        }

        private void Start()
        {
            currentColor = baseColor; 
        }

        private void Update()
        {

            float emission = (Mathf.PingPong(Time.time / 4, .5f));
            meshRenderer.materials[mat_layer].color = currentColor;
            Color lightColor = currentColor * Mathf.LinearToGammaSpace(emission);
            meshRenderer.materials[mat_layer].SetColor("_EmissionColor", lightColor); 


        }

        public void StartAttack( float lerpTime )
        {
            StartCoroutine(Attack(lerpTime)); 
        }

        public IEnumerator Attack( float lerpTime )
        {
            float elapsedTime = 0; 
            while (elapsedTime < lerpTime)
            {
                elapsedTime += Time.deltaTime;
                currentColor = Color.Lerp(baseColor, attackColor, elapsedTime / lerpTime);
                yield return null; 
            }
            currentColor = attackColor; 
        }

        public void EndAttack(float lerpTime)
        {
            StartCoroutine(StopAttack(lerpTime));
        }

        public IEnumerator StopAttack(float lerpTime)
        {
            float elapsedTime = 0;
            while (elapsedTime < lerpTime)
            {
                elapsedTime += Time.deltaTime;
                currentColor = Color.Lerp(attackColor, baseColor, elapsedTime / lerpTime);
                yield return null;
            }
            currentColor = baseColor;
        }

    }
}


