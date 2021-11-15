using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreekHelper
{
    class Word
    {
        public string Value { get; }
        public string[] Meanings { get; set; }
        public Tags[] Tags { get; }
        public WordTypes WordType { get; }
        /// <summary>
        /// true if the node represents the end of a word or the end of a stem
        /// </summary>
        public Word(string val, WordTypes wordType, string[] meanings, Tags[] tags)
        {
            Value = val;
            WordType = wordType;
            Meanings = meanings;
            Tags = tags;
        }

        public Word(string val, WordTypes wordType, string[] meanings)
            : this(val, wordType, meanings, new Tags[] { }) { }
    }
}
