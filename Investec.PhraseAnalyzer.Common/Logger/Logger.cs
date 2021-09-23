using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Investec.PhraseAnalyzer.Common.Logger
{
    public static class TraceLogger
    {
       public static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
    }
}
