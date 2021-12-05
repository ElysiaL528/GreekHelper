using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreekHelper
{
    class Preposition : Word
    {
        /// <summary>
        /// the case of the preposition's object
        /// </summary>
        public Cases FollowingCase { get; }
        public Preposition(string val, string[] meanings, Cases followingCase) : base(val, meanings)
        {
            FollowingCase = followingCase;
        }
    }
}
