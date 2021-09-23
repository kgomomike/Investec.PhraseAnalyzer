using Investec.PhraceAnalyzer.Models;
using Investec.PhraseAnalyzer.Domain.PhraseAnalyzer.Factory;
using Investec.PhraseAnalyzer.Domain.PhraseAnalyzer.Implementation;
using Investec.PhraseAnalyzer.Domain.PhraseAnalyzer.Interface;
using NUnit.Framework;

namespace Investec.PhraseAnalyzer.Test
{

    [TestFixture]
    public class UT_InvalidOperation
    {
        IAnalyzerFactory factory = null;
        IActionExecute actionExecute = null;

        [SetUp]
        public void SetUp()
        {
            factory = AnalyzerFactory.Create(((OperationAnalyzeAction)5));
           
        }
        [Test]
        public void UT_InvalidOperationCheck()
        {

            var action = factory.ActionCreate();
            Assert.IsNull(action);
            actionExecute = ActionExecute.Create(action);

            Assert.IsNull(actionExecute);

        }
    }

}
