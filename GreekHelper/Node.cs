using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreekHelper
{
    
    class Node
    {
        public char Value { get; }
        public List<string> Meanings { get; set; }
        public Tags[] Tags { get; set; }
        public Dictionary<char, Node> Children { get; }
        /// <summary>
        /// true if the node represents the end of a word or the end of a stem
        /// </summary>
        public bool IsWord { get; set; }
        public Node(char val, List<string> meanings, Tags[] tags)
        {
            Value = val;
            Meanings = meanings;
            Tags = tags;
            Children = new Dictionary<char, Node>();
        }

        public Node(char val) 
            : this(val, new List<string>(), new Tags[] { }) { }
    }
}
