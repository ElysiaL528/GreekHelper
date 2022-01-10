using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreekHelper
{
    class Ending
    {
        public char Stem { get; }
        public char Val { get; }

        public Ending(char stem, char val)
        {
            Stem = stem;
            Val = val;
        }
    }
}
