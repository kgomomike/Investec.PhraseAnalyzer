using Investec.PhraseAnalyzer.Domain.PhraseAnalyzer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Investec.PhraseAnalyzer.Domain.PhraseAnalyzer.Implementation
{
    class VowelsCounter : IStringAnalyzer
    {
        private VowelsCounter()
        {

        }
        public static VowelsCounter Create()
        {
            return new VowelsCounter();
        }
        public string AnalyzeString(string text)
        {
            var result = CountVowels(text);
            string returnValue;
            if (result > 0)
            {
                returnValue = $"The number of vowels is {result}";

            }
            else
            {
                returnValue = "No vowels were found.";
            }
            return returnValue;
        }

        private int CountVowels(string text)
        {
            string finaltext = text.ToLower();
            StringBuilder vowelsFound = new StringBuilder();
         
            foreach (char c in finaltext .ToLower())
            {
                if (!vowelsFound.ToString().Contains(c))
                {
                    switch (c)
                    {
                        case 'a':
                        case 'e':
                        case 'i':
                        case 'o':
                        case 'u':
                            vowelsFound.Append(c);
                            break;
                        default: continue;
                    }
                }

            }
            return vowelsFound.ToString().Length;
        }
    }
}
