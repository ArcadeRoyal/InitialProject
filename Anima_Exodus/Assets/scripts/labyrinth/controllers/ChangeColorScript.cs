using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

        GetComponent<Renderer>().materials[1].color = Color.red ;
        Debug.Log("Some Other Message"); 

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
