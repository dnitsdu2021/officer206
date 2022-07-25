using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Officer206Analyzer.Logging
{
    public class LogOperation : IDisposable
    {
        private readonly ILogger _logger;
        private readonly string _message;
        private readonly object[] _args;
        private readonly Stopwatch _stopwatch;

        public LogOperation(string message, object[] args, ILogger logger)
        {
            _message = message;
            _args = args;

            _logger = logger;
            _stopwatch = Stopwatch.StartNew();
        }
        public void Dispose()
        {
           _stopwatch.Stop();
           _logger.Log(string.Format("{0} and completed in {1} ms", _message, _stopwatch.ElapsedMilliseconds), _args);
        }
    }
}