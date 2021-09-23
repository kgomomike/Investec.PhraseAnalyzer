using Investec.PhraseAnalyzer.Domain.PhraseAnalyzer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Investec.PhraseAnalyzer.Domain.PhraseAnalyzer.Implementation
{
    public class VowelsUniqueNoneUnique : IStringAnalyzer
    {
        private VowelsUniqueNoneUnique(){}
        public static VowelsUniqueNoneUnique Create()
        {
            return new VowelsUniqueNoneUnique();
        }
        public string AnalyzeString(string text)
        {
            var result = CountVowels(text);
            string returnValue = string.Empty ;
            if (result.Key > result.Value)
            {
                returnValue = $"The text has more vowels than non vowels";

            }
            else if(result.Key < result.Value)
            {
                returnValue = "The text has more non vowels than vowels";
            }
            
            if (result.Key == result.Value)
            {
                returnValue = $"The text has an equal amount of vowels and non vowels";

            }
            return returnValue;
        }

        private KeyValuePair<int,int> CountVowels(string text)
        {
            string finaltext = text.ToLower();
            StringBuilder vowelsFound = new StringBuilder();
            StringBuilder noneVowels = new StringBuilder();
            foreach (char charactor in finaltext.ToLower())
            {
                if (!vowelsFound.ToString().Contains(charactor) && charactor != ' ')
                {
                    switch (charactor)
                    {
                        case 'a':
                        case 'e':
                        case 'i':
                        case 'o':
                        case 'u':
                            vowelsFound.Append(charactor);
                            break;
                         
                        default:
                            if (!vowelsFound.ToString().Contains(charactor) && charactor != ' ')
                            {
                                noneVowels.Append(charactor);
                            }
                            break;
                    }
                }
              
                

            }
            return new KeyValuePair<int,int>(vowelsFound.Length, noneVowels.Length);
        }

    }
}
