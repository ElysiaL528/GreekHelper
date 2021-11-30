using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreekHelper
{
    class Noun : Word
    {
        public int Decl { get; }
        public Genders Gender { get; }
        public Cases Case { get; }
        public bool IsSingular { get; }
        public Noun(string val, string[] meanings, int decl, Genders gender, bool isSingular, Cases ncase = Cases.Nom) : base(val, meanings)
        {
            Decl = decl;
            Gender = gender;
            IsSingular = isSingular;
            Case = ncase;
        }
    }
}
