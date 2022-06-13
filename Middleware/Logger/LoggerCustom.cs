using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middleware.Logger
{
    public class LoggerCustom
    {
        private ILogger _logger;
        private string fileLoaction = @"D:\ESTUDIOS\PROGRAMACON\bootcamp c#\actividad extra\proyecto git AE\WebApiConcecionaria2\logger.txt";
        private string errorFileLoaction = @"D:\ESTUDIOS\PROGRAMACON\bootcamp c#\actividad extra\proyecto git AE\WebApiConcecionaria2\error.txt";
        public LoggerCustom(ILogger logger)
        {
            this._logger = logger;
        }
        public LoggerCustom()
        {
        }

        public void Info(string message)
        {
            DateTime dateTime = DateTime.Now;
            message = String.Format(@"{0}: {1}", dateTime, message);

            if (_logger == null)
                Console.WriteLine(message);
            else
                _logger.LogInformation(message);

            using (var wr = File.AppendText(fileLoaction))
            {
                wr.WriteLine(message);
            }
        }
        public void Error(string message)
        {
            DateTime dateTime = DateTime.Now;
            message = String.Format(@"{0}: {1}", dateTime, message);

            if (_logger == null)
            {
                Console.WriteLine("Error " + message);
            }
            else
            {
                _logger.LogError(message);
            }

            using (var wr = File.AppendText(errorFileLoaction))
            {
                wr.WriteLine(message);
            }
        }
        
    }
}