using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace testing 
{ 
    public class AnimationTest : MonoBehaviour 
    {
        private Animator animator;
        private int idlehash;
        private int activehash; 
		public void Start()
		{
            Debug.Log("Initialization at " + Time.time);
            idlehash = Animator.StringToHash("idle");
            activehash = Animator.StringToHash("active");
            Debug.Log("Idle hash is " + idlehash);
            Debug.Log("Active hash is " + activehash);
            Debug.Log("Idle name hash is " + Animator.StringToHash("Base.idle")); 
            animator = GetComponent<Animator>();

            StartCoroutine(RunTest()); 
		}
         
        public IEnumerator RunTest() 
        {
            Debug.Log("Starting test at " + Time.time);
            animator.SetTrigger("step");
            Debug.Log("Have triggered the step at " + Time.time );
            PrintBoolInformation();
            yield return null; 
            Debug.Log("One frame later " + Time.time);
            PrintBoolInformation();
            Debug.Log("Starting wait loop at " + Time.time);
            while (!animator.GetCurrentAnimatorStateInfo(0).IsName("idle")) 
            {
                Debug.Log("Waiting");
                PrintBoolInformation();
                yield return null; 
            }
            Debug.Log("Step Should be finished at " + Time.time);
            PrintBoolInformation();
            animator.SetTrigger("turn_left"); 
            Debug.Log("Setting turn trigger at " + Time.time); 
            PrintBoolInformation();
            yield return null;
            Debug.Log("One frame later " + Time.time);
            PrintBoolInformation();
            Debug.Log("Starting wait loop at " + Time.time);
            while (!animator.GetCurrentAnimatorStateInfo(0).IsName("idle"))
            {
                Debug.Log("Waiting");
                PrintBoolInformation();
                yield return null;
            }
            Debug.Log("Turn Should be finished at " + Time.time);
            PrintBoolInformation();
            animator.SetTrigger("step");
            Debug.Log("Have triggered the step at " + Time.time);
            PrintBoolInformation();
            yield return null;
            Debug.Log("One frame later " + Time.time);
            PrintBoolInformation();
            Debug.Log("Starting wait loop at " + Time.time);
            while (!animator.GetCurrentAnimatorStateInfo(0).IsName("idle"))
            {
                Debug.Log("Waiting");
                PrintBoolInformation();
                yield return null;
            }
            Debug.Log("Step Should be finished at " + Time.time);
            PrintBoolInformation();
            animator.SetTrigger("turn_180");
            Debug.Log("Have triggered the turn at " + Time.time);
            PrintBoolInformation();
            yield return null;
            Debug.Log("One frame later " + Time.time);
            PrintBoolInformation();
            Debug.Log("Starting wait loop at " + Time.time);
            while (!animator.GetCurrentAnimatorStateInfo(0).IsName("idle"))
            {
                Debug.Log("Waiting");
                PrintBoolInformation();
                yield return null;
            }
            Debug.Log("turn Should be finished at " + Time.time);
            PrintBoolInformation();
            animator.SetTrigger("defend");
            Debug.Log("Have triggered the defend at " + Time.time);
            PrintBoolInformation();
            yield return null;
            Debug.Log("One frame later " + Time.time);
            PrintBoolInformation();
            Debug.Log("Starting wait loop at " + Time.time);
            while (!animator.GetCurrentAnimatorStateInfo(0).IsName("idle"))
            {
                Debug.Log("Waiting");
                PrintBoolInformation();
                yield return null;
            }
            Debug.Log("defend Should be finished at " + Time.time);
            PrintBoolInformation();
        }

        public void PrintBoolInformation() 
        {
            Debug.Log("IsName check on 'idle' evaluates " + animator.GetCurrentAnimatorStateInfo(0).IsName("idle"));
            Debug.Log("The current hash is: " + animator.GetCurrentAnimatorStateInfo(0).fullPathHash);
            Debug.Log("The current tag hash is: " + animator.GetCurrentAnimatorStateInfo(0).tagHash); 
        }
	}
}