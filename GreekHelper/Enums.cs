using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreekHelper
{
    public enum WordTypes
    {
        Noun,
        Verb,
        Article,
        Prep,
        Adj,
        Adv
    }
    public enum Genders
    {
        M,
        F,
        N
    }
    public enum Cases
    {
        Nom,
        Gen,
        Dat,
        Acc,
        Voc
    }

    public enum Tenses
    {
        Present,
        Imperfect,
        Future
    }

    public enum Voices
    {
        Active,
        Passive
    }

    public enum Moods
    {
        Indicative,
        Imperaitve
    }

    public enum Tags
    {
        Masculine,
        Feminine,
        Neuter,
        Singular,
        Plural,
        FirstPerson,
        SecondPerson,
        ThirdPerson,
        FirstDecl,
        SecondDecl,
        ThirdDecl,
        Preposition,
        Article
    }
}
