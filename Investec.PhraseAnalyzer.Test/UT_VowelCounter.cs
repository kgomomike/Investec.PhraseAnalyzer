using Investec.PhraceAnalyzer.Models;
using Investec.PhraseAnalyzer.Domain.PhraseAnalyzer.Factory;
using Investec.PhraseAnalyzer.Domain.PhraseAnalyzer.Implementation;
using Investec.PhraseAnalyzer.Domain.PhraseAnalyzer.Interface;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Investec.PhraseAnalyzer.Test
{
    [TestFixture]
    public class UT_VowelCounter
    {
        IAnalyzerFactory factory = null;
        IActionExecute actionExecute = null;

        [SetUp]
        public void SetUp()
        {
            factory = AnalyzerFactory.Create(OperationAnalyzeAction.UniqueVowelsCounter);
            var action = factory.ActionCreate();
            actionExecute = ActionExecute.Create(action);
        }
        [Test]
        public void UT_Countnumberofvowels()
        {

            var result = actionExecute.ExecuteAction("I like eating apples");
            Assert.IsTrue(result != "");
            Assert.IsTrue(result == "The number of vowels is 3");
            Assert.NotNull(result);
        }
        [Test]
        public void UT_vowelsNotFound()
        {

            var result = actionExecute.ExecuteAction("jkl kkjh");
            Assert.IsTrue(result == "No vowels were found.");
            Assert.IsTrue(result != "");
            Assert.NotNull(result);
        }

    }
}
