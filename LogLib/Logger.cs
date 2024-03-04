using System;

namespace LogLib
{
    public static class Logger
    {
        

      
        private static readonly string logFilePath = $"Logs\\{GetDate()}\\ApplicationLog.txt";
        public static void LogException(Exception ex)
        {
            CreateLogDirectories();
            try
            {
                //format the exception message and write it to the log file
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(logFilePath, true))
                {
                    //write the exception to file
                    sw.WriteLine(FormatExceptionMessage(ex));
                    sw.WriteLine("-----------------------------------------------------------");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error in Logger.LogException: " + e.Message);
            }
        }
        //create the filepath directories if they do not exist
        public static void CreateLogDirectories()
        {
            //recommended order of date for file naming: year-month-day
            try
            {
                string logDirectory = $"Logs\\{GetDate()}";
                if (!System.IO.Directory.Exists(logDirectory))
                {
                    System.IO.Directory.CreateDirectory(logDirectory);
                }
            }
            catch (Exception e)
            {
                //explain that the common cause of this error is that the application does not have permission to create the directory
                //github copilot autocompleted this error above -james 2021-08-10 (it auto'd the date too)
                throw new Exception("Error in Logger.CreateLogDirectories: " + e.Message);
            }
        }

        //format the exception message for readability
        private static string FormatExceptionMessage(Exception ex)
        {
            string message = string.Empty;
            message += "Exception Type: " + ex.GetType().Name + Environment.NewLine;
            message += "Message: " + ex.Message + Environment.NewLine;
            message += "Source: " + ex.Source + Environment.NewLine;
            message += "Stack Trace: " + ex.StackTrace + Environment.NewLine;
            message += "Target Site: " + ex.TargetSite + Environment.NewLine;
            return message;
        }

        private static string GetDate() => DateTime.Now.ToString("yyyy-MM-dd");
    }
}
