using Investec.PhraseAnalyzer.Domain.PhraseAnalyzer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Investec.PhraseAnalyzer.Domain.PhraseAnalyzer.Implementation
{
    public class ActionExecute : IActionExecute
    {

        protected IStringAnalyzer StringAnalyzer = null;
        private ActionExecute(IStringAnalyzer stringAnalyzer)
        {
            StringAnalyzer = stringAnalyzer;
        }
        public static ActionExecute Create(IStringAnalyzer stringAnalyzer)
        {
            if (stringAnalyzer != null)
            {
                return new ActionExecute(stringAnalyzer);
            }
            return null;
        }
        public string ExecuteAction(string text)
        {
            return StringAnalyzer.AnalyzeString(text);
        }
    }
}
