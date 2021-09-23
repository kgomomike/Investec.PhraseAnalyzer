using Investec.PhraseAnalyzer.Domain.PhraseAnalyzer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Investec.PhraseAnalyzer.Domain.PhraseAnalyzer.Implementation
{
    public class VowelsDuplicateCheck : IStringAnalyzer
    {


        private VowelsDuplicateCheck() { }
        public static VowelsDuplicateCheck Create()
        {
            return new VowelsDuplicateCheck();
        }
        public string AnalyzeString(string text)
        {
            var result = DuplicateCheck(text);
            string returnValue;
            if (result.Length > 0)
            {
                returnValue = $"Found the following duplicates: {result}";

            }
            else
            {
                returnValue = "No duplicate values were found";
            }
            return returnValue;

        }

        private string DuplicateCheck(string text)
        {
             text = text.ToLower();
            if (string.IsNullOrEmpty(text)) return string.Empty;
            string dulicateLetters = "";

            char[] textArray = text.ToCharArray();
            var duplicates = textArray.GroupBy(p => p)
                                      .Where(g => g.Count() > 1)
                                      .Where(g=> g.Key !=' ')
                                      .Select(g => g.Key).ToList();

             dulicateLetters = string.Join("", duplicates.ToArray());
            return dulicateLetters;
        }


    }
}
