using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using Investec.PhraseAnalyzer.Common.Utilities;
using Investec.PhraseAnalyzer.Domain.PhraseAnalyzer.Factory;
using Investec.PhraseAnalyzer.Domain.PhraseAnalyzer.Implementation;
using Investec.PhraseAnalyzer.Domain.PhraseAnalyzer.Interface;
using Ninject;

namespace Investec.PhraseAnalyzer
{
    [ExcludeFromCodeCoverage]
    public class NinjectMapping : BaseNinjectMapping
    {
        public override void Load()
        {
            Bind<IActionExecute>().To<ActionExecute>();
            Bind<IAnalyzerFactory>().To<AnalyzerFactory>();
        
            base.Load();
        }
    }
}
