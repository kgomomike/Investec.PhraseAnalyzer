using Investec.PhraceAnalyzer.Models;
using Investec.PhraseAnalyzer.Domain.PhraseAnalyzer.Implementation;
using Investec.PhraseAnalyzer.Domain.PhraseAnalyzer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Investec.PhraseAnalyzer.Domain.PhraseAnalyzer.Factory
{
    public class AnalyzerFactory: IAnalyzerFactory
    {
        protected IStringAnalyzer StringAnalyzer;
        protected OperationAnalyzeAction Operations;
        private AnalyzerFactory(OperationAnalyzeAction operations)
        {
            Operations = operations;
        }
        public static AnalyzerFactory Create (OperationAnalyzeAction operations)
        {
            return new AnalyzerFactory(operations);
        }
        public IStringAnalyzer ActionCreate()
        {
            switch(Operations)
            {
                case OperationAnalyzeAction.DuplicateCheck:
                    StringAnalyzer = VowelsDuplicateCheck.Create();
                    break;
                case OperationAnalyzeAction.UniqueVowelsCounter:
                    StringAnalyzer = VowelsCounter.Create();
                    break;
                case OperationAnalyzeAction.MultipleUniqueNoneUnique:
                    StringAnalyzer = VowelsUniqueNoneUnique.Create();
                    break;

                default:
                   return null;

            }
            return StringAnalyzer;
        }

       
    }
}
