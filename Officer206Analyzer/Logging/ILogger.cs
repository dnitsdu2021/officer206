using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Officer206Analyzer.Logging
{
    public interface ILogger
    {
        void Log(string v, object[] args);
    }
}
