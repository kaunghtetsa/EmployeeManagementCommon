using System.IO;
using log4net;
using log4net.Appender;

namespace ASM.EmployeeManagement.Common.Logger
{
    /// <summary>
    /// Generic logger
    /// </summary>
    internal class Logger
    {
        #region Data Members

        /// <summary>
        /// Object of ILog
        /// </summary>
        private static ILog s_Logger = null; 

        /// <summary>
        /// Log Config file path
        /// </summary>
        private static string _logConfigFile;

        #endregion

        #region Constants

        /// <summary>
        /// logger name
        /// </summary>
        internal const string LoggerName = "Logger";

        #endregion

        #region Public Methods

        /// <summary>
        /// Set Log Config file path
        /// </summary>
        /// <param name="filePath"></param>
        public static void SetLogConfigFilePath(string filePath)
        {
            _logConfigFile = filePath;
        }

        /// <summary>
        /// Configures the logger
        /// </summary>
        public static ILog Configure()
        {
            s_Logger = Initialize(LoggerName);
            return s_Logger;
        }

        /// <summary>
        /// Initializes the logger
        /// </summary>
        internal static ILog Initialize(string sLoggerName)
        {
            ILog objlogger = null;
            try
            {
                log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(_logConfigFile));
                objlogger = LogManager.GetLogger(sLoggerName);

                // Iterating through each appender
                object[] objAppenders = LogManager.GetRepository().GetAppenders();
                foreach (object item in objAppenders)
                {
                    FileAppender objFile = item as FileAppender;
                    if (objFile != null)
                    {
                        objFile.ActivateOptions();
                    }
                }

                // Checking logger
                if (objlogger.Logger.Name != sLoggerName)
                {
                    objlogger = null;
                }
            }
            catch (System.Exception)
            {
                System.Diagnostics.Debug.Assert(false);
            }
            return objlogger;
        }

        #endregion
    }
}
