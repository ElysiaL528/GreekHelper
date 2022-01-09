using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GreekHelper
{
    class Trie
    {
        public Node Root { get; }
        public Trie()
        {
            Root = new Node('$');
        }

        //public void Insert(string word, List<string> meanings, Tags[] tags)
        //{
        //    Word newWord = new Word(word, meanings.ToArray());
            
        //}

        public void Insert(Word word)
        {
            var temp = Root;
            string wordText = word.Value;
            foreach (var letter in wordText)
            {
                if (!temp.Children.ContainsKey(letter))
                {
                    temp.Children.Add(letter, new Node(letter));
                }
                temp = temp.Children[letter];
            }

            temp.Word = word;
        }

        //public void Insert(string word, string meaning, Tags[] tags)
        //    => Insert(word, new List<string>() { meaning }, tags);

        public Node Search(string word)
        {
            var temp = Root;
            foreach(var letter in word)
            {
                if (!temp.Children.ContainsKey(letter)) return null;
                temp = temp.Children[letter];
            }
            return temp;
        }
    }
}
