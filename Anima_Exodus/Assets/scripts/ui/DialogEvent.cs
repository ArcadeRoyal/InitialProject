using System; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{

    public class DialogEvent : IEquatable<DialogEvent>
    {

        private string id;
        private List<DialogNode> dialog;

        public string ID
        {
            get
            {
                return id; 
            }
        }

        public List<DialogNode> Dialog
        {
            get
            {
                return dialog;
            }
        }

        public DialogEvent( string id, List<string> lines )
        {
            dialog = new List<DialogNode>(); 
            this.id = id; 
            for (int i = 0; i < lines.Count; i++ )
            {
                string[] linesplit = lines[i].Split('|');
                dialog.Add(new DialogNode(linesplit[0], linesplit[1], linesplit.Length > 2 ? linesplit[2] : "")); 
            }
        }

        public bool Equals(DialogEvent e)
        {
            return e.ID == id; 
        }

    }

}