using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTags : MonoBehaviour {

    public List<string> tags; 

    public List<string> Tags
    {
        get
        {
            return tags; 
        }
    }

    public bool CheckTag(string s)
    {
        return tags.Contains(s);
    }

    public void AddTag(string s)
    {
        if (!tags.Contains(s))
            tags.Add(s); 

    }

    public void RemoveTag(string s)
    {
        tags.Remove(s); 
    }
	
}
