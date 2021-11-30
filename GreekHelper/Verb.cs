using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreekHelper
{
    class Verb : Word
    {
        public int Person { get; }
        public bool IsSingular { get; }
        public Tenses Tense { get; }
        public Voices Voice { get; }
        public Moods Mood { get; }
        public Verb(string val, string[] meanings, int person, bool isSingular, Tenses tense, Voices voice, Moods mood) : base(val, meanings)
        {
            Person = person;
            IsSingular = isSingular;
            Tense = tense;
            Voice = voice;
            Mood = mood;
        }
    }
}
