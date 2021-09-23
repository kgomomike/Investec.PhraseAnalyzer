using System;
using System.Collections.Generic;
using System.Text;

namespace Investec.PhraseAnalyzer.Domain.PhraseAnalyzer.Interface
{
    public interface IAnalyzerFactory
    {
        IStringAnalyzer ActionCreate();

    }
}
