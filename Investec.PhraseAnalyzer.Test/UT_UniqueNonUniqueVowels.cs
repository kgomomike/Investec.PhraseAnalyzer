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
    public class UT_UniqueNonUniqueVowels
    {
        IAnalyzerFactory factory = null;
        IActionExecute actionExecute = null;
 
        [SetUp]
        public void SetUp()
        {
            factory = AnalyzerFactory.Create(OperationAnalyzeAction.MultipleUniqueNoneUnique);
            var action = factory.ActionCreate();
            actionExecute = ActionExecute.Create(action);
        }
        [Test]
        public void UT_MorevowelsthannoneVowels ()
        {
           
            var result = actionExecute.ExecuteAction("I eat");
            Assert.IsTrue(result!="");
            Assert.IsTrue(result == "The text has more vowels than non vowels");
            Assert.NotNull(result);
        }
        [Test]
        public void UT_Morenonvowelsthanvowels()
        {

            var result = actionExecute.ExecuteAction("that dog");
            Assert.IsTrue(result == "The text has more non vowels than vowels");
            Assert.IsTrue(result != "");
            Assert.NotNull(result);
        }
        [Test]
        public void UT_EqualAmountOfVowelsAndNonVowels()
        {

            var result = actionExecute.ExecuteAction("3 a");
            Assert.IsTrue(result == "The text has an equal amount of vowels and non vowels");
            Assert.IsTrue(result != "");
            Assert.NotNull(result);
        }

    }
}
