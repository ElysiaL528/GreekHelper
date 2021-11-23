using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreekHelper
{
    abstract class Word
    {
        public string Value { get; }
        public string[] Meanings { get; set; }
        /// <summary>
        /// true if the node represents the end of a word or the end of a stem
        /// </summary>
        public Word(string val, string[] meanings)
        {
            Value = val;
            Meanings = meanings;
        }
    }
}
