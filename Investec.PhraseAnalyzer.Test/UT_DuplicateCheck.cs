using Investec.PhraceAnalyzer.Models;
using Investec.PhraseAnalyzer.Domain.PhraseAnalyzer.Factory;
using Investec.PhraseAnalyzer.Domain.PhraseAnalyzer.Implementation;
using Investec.PhraseAnalyzer.Domain.PhraseAnalyzer.Interface;
using NUnit.Framework;

namespace Investec.PhraseAnalyzer.Test
{

    [TestFixture]
    public class UT_DuplicateCheck
    {
        IAnalyzerFactory factory = null;
        IActionExecute actionExecute = null;

        [SetUp]
        public void SetUp()
        {
            factory = AnalyzerFactory.Create(OperationAnalyzeAction.DuplicateCheck);
            var action = factory.ActionCreate();
            actionExecute = ActionExecute.Create(action);
        }
        [Test]
        public void DuplicatesCharactorFound()
        {

            var result = actionExecute.ExecuteAction("I like eating apples");
            Assert.IsTrue(result != "");
            Assert.IsTrue(result == "Found the following duplicates: ileap");
            Assert.NotNull(result);
        }
        [Test]
        public void DuplicatesCharactorNotFound()
        {

            var result = actionExecute.ExecuteAction("abcd4");
            Assert.IsTrue(result == "No duplicate values were found");
            Assert.IsTrue(result != "");
            Assert.NotNull(result);
        }
    }
}