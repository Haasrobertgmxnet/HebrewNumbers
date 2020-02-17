using System;
using System.Collections.Generic;
using System.Text;

namespace HebrewNumbers
{
    class VocabularyItem
    {
        string hebrew;
        string german;
        string spanish;
        string french;
        string pronounciation;
        bool alreadyAsked;
        bool correctAtFirstTime;

        public string Hebrew { get => hebrew; set => hebrew = value; }
        public string German { get => german; set => german = value; }
        public string Pronounciation { get => pronounciation; set => pronounciation = value; }
        public bool AlreadyAsked { get => alreadyAsked; set => alreadyAsked = value; }
        public string Spanish { get => spanish; set => spanish = value; }
        public string French { get => french; set => french = value; }
        public bool CorrectAtFirstTime { get => correctAtFirstTime; set => correctAtFirstTime = value; }
    }
}
