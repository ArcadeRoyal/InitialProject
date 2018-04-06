using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace testing 
{ 
    public class TimeStampPrinter : MonoBehaviour
    {

        private int frame = 0; 

        public void PrintTime(string s)
        {
            Debug.Log(gameObject.name + " " + s + " " + Time.time);
        }

	}
}
 

