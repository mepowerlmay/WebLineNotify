using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinLineNotify.Helper
{
    public class Log
    {

        private static Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public static void Fatal(object message)
        {            //    
            logger.Fatal(message);
        }


        public static void Error(object message)
        {
            //    
            logger.Error(message);
        }

        public static void Error(object message, System.Exception exception)
        {

            logger.Error(message);
        }

        public static void Info(object message)
        {

            logger.Info(message);
        }

        public static void Info(object message, System.Exception ex)
        {

            logger.Info(message);
        }

        public static void Warn(object message)
        {

            logger.Warn(message);
        }

        public static void Warn(object message, System.Exception ex)
        {

            logger.Warn(message);
        }

        public static void Debug(object message)
        {

            logger.Debug(message);
        }

        public static void Debug(object message, System.Exception ex)
        {

            logger.Debug(message);
        }

        private static string GetCurrentMethodFullName()
        {
            string result;
            try
            {
                int num = 2;
                System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace();
                int num2 = stackTrace.GetFrames().Length;
                System.Diagnostics.StackFrame frame;
                string text;
                do
                {
                    frame = stackTrace.GetFrame(num++);
                    System.Type declaringType = frame.GetMethod().DeclaringType;
                    text = declaringType.ToString();
                }
                while (text.EndsWith("Exception") && num < num2);
                string name = frame.GetMethod().Name;
                result = text + "." + name;
            }
            catch
            {
                result = null;
            }
            return result;
        }
    }
}
