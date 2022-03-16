using System;
using System.Collections.Generic;
using System.Text;

namespace BachoLibrary.Common.Extensions
{
    public static class ExceptionExtensions
    {
        public static string FullMessage(this Exception exception)
        {
            string resultText = exception.Message;

            if (exception.InnerException != null)
                resultText += " " + exception.InnerException.Message;

            return resultText;
        }

        public static string FullMessageWithStackTrace(this Exception exception, int linesBetween = 2)
        {
            var sb = new StringBuilder();
            sb.AppendLine(exception.FullMessage());
            for (int i = 0; i < linesBetween; i++)
            {
                sb.AppendLine();
            }
            sb.AppendLine(exception.StackTrace);

            return sb.ToString();
        }
    }
}
