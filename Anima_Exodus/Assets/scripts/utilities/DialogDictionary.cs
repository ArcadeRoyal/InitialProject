using System.Collections;
using System.Text.RegularExpressions; 
using System.Collections.Generic;
using UnityEngine;
using UI; 

public class DialogDictionary : MonoBehaviour{

    public static DialogDictionary instance; 
    public TextAsset eventfile; 

    private Dictionary<string, DialogEvent> events;

    public void Awake()
    {
        if (instance == null)
            instance = this;
        DontDestroyOnLoad(gameObject);
        InitDictionary(); 
    }

    public DialogEvent GetEvent( string id )
    {
        DialogEvent e;
        if (events.TryGetValue(id, out e))
            return e;
        else
            return null; 
    }

    public void InitDictionary()
    {
        events = new Dictionary<string, DialogEvent>();
        string[] lines = Regex.Split(eventfile.text, "\r\n|\n|\r");
        int i = 0;
        while (i < lines.Length && lines[i].Split('|')[0] == "ID") 
        {
           
            string id = lines[i].Split('|')[1];
            i++;
            List<string> stringList = new List<string>(); 
            while (i < lines.Length && lines[i] != "")
            {
                stringList.Add(lines[i]);
                i++; 
            }
            if (!events.ContainsKey(id))
                events.Add(id, new DialogEvent(id, stringList)); 
            i++; 
           
        }

    }

}
