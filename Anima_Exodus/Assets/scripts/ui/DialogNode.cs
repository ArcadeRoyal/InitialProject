using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class DialogNode 
    {
        private string name;
        private string line;
        private string[] instructions;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Line
        {
            get
            {
                return line;
            }

            set
            {
                line = value;
            }
        }

        public string[] Instructions
        {
            get
            {
                return instructions;
            }

            set
            {
                instructions = value;
            }
        }

        public DialogNode( string name, string line, string instructions )
        {
            this.name = name;
            this.line = line;
            this.instructions = instructions.Split('|'); 
        }

    }

}