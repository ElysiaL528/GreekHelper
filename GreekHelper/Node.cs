using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreekHelper
{
    
    class Node
    {
        public char Value { get; set; }
        public Word Word { get; set; }
        //public Tags[] Tags { get; set; }
        public Dictionary<char, Node> Children { get; }
        /// <summary>
        /// true if the node represents the end of a word or the end of a stem
        /// </summary>
        public bool IsWord => Word == null;
        public Node(char val, Word word)
        {
            Value = val;
            Word = word;
            Children = new Dictionary<char, Node>();
        }

        public Node(char val) 
            : this(val, null) { }
    }
}
