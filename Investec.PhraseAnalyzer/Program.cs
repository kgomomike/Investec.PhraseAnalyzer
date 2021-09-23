using Investec.PhraceAnalyzer.Models;
using Investec.PhraseAnalyzer.Common.Logger;
using Investec.PhraseAnalyzer.Domain.PhraseAnalyzer.Factory;
using Investec.PhraseAnalyzer.Domain.PhraseAnalyzer.Implementation;
using Investec.PhraseAnalyzer.Domain.PhraseAnalyzer.Interface;
using Ninject;
using System;
using System.IO;


namespace Investec.PhraseAnalyzer
{
    public class Program
    {
        protected Program() { }
        static void Main(string[] args)
        {

            TraceLogger.Logger.Log(NLog.LogLevel.Info, "*************************************************************************************");
            TraceLogger.Logger.Log(NLog.LogLevel.Info, "Input Request");
            Console.WriteLine("Enter text to be analysed");

            string text = Console.ReadLine();
            TraceLogger.Logger.Log(NLog.LogLevel.Info, text);

            TraceLogger.Logger.Log(NLog.LogLevel.Info, "*************************************************************************************");
            TraceLogger.Logger.Log(NLog.LogLevel.Info, "Analyzer Operations");
            TraceLogger.Logger.Log(NLog.LogLevel.Info, "1. Duplicate Check = 1");
            TraceLogger.Logger.Log(NLog.LogLevel.Info, "2. Count the number of unique vowels = 2");
            TraceLogger.Logger.Log(NLog.LogLevel.Info, "3. Output if there are more unique vowels or unique non vowels = 3");
            TraceLogger.Logger.Log(NLog.LogLevel.Info, "*************************************************************************************");

            TraceLogger.Logger.Log(NLog.LogLevel.Info, "Operation Execution Request");
            Console.WriteLine("Enter which operations to do on the supplied text");

            string operation = Console.ReadLine();

            if (int.TryParse(operation, out int numberValue))
            {
                if (!typeof(OperationAnalyzeAction).IsEnumDefined(numberValue))
                {
                    TraceLogger.Logger.Log(NLog.LogLevel.Error, "The operation supplied is invalid");
                    return;
                }

                IAnalyzerFactory factory = AnalyzerFactory.Create((OperationAnalyzeAction)numberValue);
                var action = factory.ActionCreate();
                IActionExecute actionExecute = ActionExecute.Create(action); 
                var result = actionExecute.ExecuteAction(text);

                TraceLogger.Logger.Log(NLog.LogLevel.Info, "*************************************************************************************");

                TraceLogger.Logger.Log(NLog.LogLevel.Info, result);
                Console.WriteLine(result);
            }





        }
    }
}
