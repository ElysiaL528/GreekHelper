using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GreekHelper
{
    public partial class Form1 : Form
    {
        Dictionary<string, Tags> TextToTags = new Dictionary<string, Tags>()
        {
            {"M", Tags.Masculine },
            {"F", Tags.Feminine },
            {"N", Tags.Neuter },
            {"S", Tags.Singular},
            {"P", Tags.Plural },
            {"1p", Tags.FirstPerson },
            {"2p", Tags.SecondPerson },
            {"3p", Tags.ThirdPerson },
            {"1d", Tags.FirstDecl },
            {"2d", Tags.SecondDecl },
            {"3d", Tags.ThirdDecl }
        };

        Dictionary<string, WordTypes> TextToWordType = new Dictionary<string, WordTypes>()
        {
            {"N", WordTypes.Noun },
            {"V", WordTypes.Verb },
            {"P", WordTypes.Prep },
            {"Ar", WordTypes.Article },
            {"Adj", WordTypes.Adj },
            {"Adv", WordTypes.Adv }
        };
        public Form1()
        {
            InitializeComponent();
        }

        List<Word> ParseDictionary(string[] fileLines)
        {
            List<Word> words = new List<Word>();
            for(int i = 0; i < fileLines.Length; i++)
            {
                string[] units  = fileLines[i].Replace(" ", "").Split('-');
                if (units.Length == 0) continue;
                string[] wordComponents = units[0].Split('(');
                string word = wordComponents[0];
                string wordTypeString = wordComponents[1].Substring(0, wordComponents[1].Length - 1);
                WordTypes wordType = TextToWordType[wordTypeString];

                string[] meanings = units[1].Split(',');
                Tags[] tags = new Tags[units.Length - 2];
                for(int j = 2; j < units.Length; j++)
                {
                    tags[j-2] = TextToTags[units[j]];
                }
                Word newWord = new Word(word, wordType, meanings, tags);
                words.Add(newWord);
            }
            return words;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines("greekdict.txt");
            var words = ParseDictionary(lines);
        }
    }
}
