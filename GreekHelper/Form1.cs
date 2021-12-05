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
        List<Word> translatedWords = new List<Word>();
        public Form1()
        {
            InitializeComponent();
        }

        List<Word> ParseDictionary(string[] fileLines)
        {
            List<Word> words = new List<Word>();
            for(int i = 0; i < fileLines.Length; i++)
            {
                string[] units  = fileLines[i].Split('-');
                if (units.Length == 0) continue;
                string[] wordComponents = units[0].Split('(');
                string word = wordComponents[0].Replace(" ", "");
                string trimmed = wordComponents[1].Replace(" ", "");
                string wordTypeString = trimmed.Substring(0, trimmed.Length - 1);
                WordTypes wordType = TextToWordType[wordTypeString];

                string[] meanings = units[1].Split(',');

                Word newWord = new Noun("", new string[] { }, 0, Genders.F, false); //random default val
                switch(wordType)
                {
                    case WordTypes.Noun:
                        {
                            // - declension/gender/number/case
                            string[] details = units[2].Replace(" ", "").Split('/');
                            int decl = int.Parse(details[0]);
                            Genders gender = (Genders)Enum.Parse(typeof(Genders), details[1]);
                            bool isSingular = details.Length >= 3 ? details[2] == "S" : true;
                            Cases nounCase = details.Length >= 4 ? (Cases)Enum.Parse(typeof(Cases), details[3]) : Cases.Nom;

                            newWord = new Noun(word, meanings, decl, gender, isSingular, nounCase);

                            break;
                        }
                    case WordTypes.Verb:
                        {
                            // - person/number/tense/voice/mood
                            // - 1/S/Present/Active/Indicative
                            string[] details = units[2].Replace(" ", "").Split('/');
                            int person = int.Parse(details[0]);
                            bool isSingular = details[1] == "S";
                            Tenses tense = (Tenses)Enum.Parse(typeof(Tenses), details[2]);
                            Voices voice= (Voices)Enum.Parse(typeof(Voices), details[3]);
                            Moods mood = (Moods)Enum.Parse(typeof(Moods), details[4]);

                            newWord = new Verb(word, meanings, person, isSingular, tense, voice, mood);
                            break;
                        }
                    case WordTypes.Adv:
                        newWord = new Adverb(word, meanings);
                        break;
                }
                words.Add(newWord);
            }
            return words;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //string text = "αποστολος (N)- apostle - 1/M/S/Nom";
            //File.WriteAllText("greekdict.txt", text);
            string[] lines = File.ReadAllLines("greekdict.txt");
            List<Word> words = ParseDictionary(lines);

            Trie trie = new Trie();

            foreach (var word in words)
            {
                
            }

        }
    }
}
