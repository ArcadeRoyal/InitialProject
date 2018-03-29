using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    private bool paused = false;
    
    public bool Paused
    {
        get
        {
            return paused; 
        }
        set
        {
            paused = value; 
        }
    }

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject); 
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }
    }
}
