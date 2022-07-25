using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Web;

namespace Officer206Analyzer.Logging
{
    //public class TextLogger : ILogger
    //{
    //    public void Log(string v, object[] args)
    //    {
    //        Debug.WriteLine(v, args);
    //        var fileName = string.Format("Log-{0}.txt", DateTime.Now.Date.ToString("dd-MM-yyyy"));
    //        var folderPath = Path.Combine(HttpRuntime.AppDomainAppPath, "Logs");
    //        var filePath = Path.Combine(folderPath, fileName);
    //        if (!Directory.Exists(folderPath))
    //            Directory.CreateDirectory(folderPath);
            
    //        using (var file = new StreamWriter(filePath, append: true))
    //        {
    //            var stringBuilder = new StringBuilder();
    //            stringBuilder.Append(DateTime.Now);
    //            stringBuilder.Append(" ");
    //            stringBuilder.AppendFormat(v, args);
    //            file.WriteLine(stringBuilder.ToString());
    //        }
    //    }
    //}


    public class DbLogger : ILogger
    {
        private readonly AccessLog _logger;

        public DbLogger(AccessLog logger)
        {
            _logger = logger;
        }

        public void Log(string v, object[] args)
        {
            _logger.LogUserActivity(v, args);
        }
    }

}
