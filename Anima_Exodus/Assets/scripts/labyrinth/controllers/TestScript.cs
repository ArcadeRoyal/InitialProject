using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour {

    public void Start()
    {
        Material[] temp = GetComponent<Renderer>().materials;
        temp[0].color = Color.red;
        temp[1].color = Color.red;
        GetComponent<Renderer>().materials = temp;  
    }

}
