using log4net;
using System.IO;
using System.Diagnostics;

using ASM.EmployeeManagement.Common.Assembly;

namespace ASM.EmployeeManagement.Common.Logger
{
    /// <summary>
    /// Log helper
    /// </summary>
    public class LogHelper
    {
        #region Data member

        private static ILog s_objLogger = null;

        #endregion

        #region Public Methods

        /// <summary>
        /// Initialze Logger
        /// </summary>
        /// <param name="file"></param>
        public static void Initialize(string file)
        {
            Logger.SetLogConfigFilePath(file);

            s_objLogger = Logger.Configure();

            Info(null, file);
        }

        /// <summary>
        /// Writes development debug log log
        /// </summary>
        /// <param name="objCaller">Caller class object</param>
        /// <param name="sMessage">Log Message</param>
        /// <param name="sMethodName">[Optional] Calling method name</param>
        /// <param name="sFilePath">[Optional] Calling file name</param>
        /// <param name="nLineNumber">[Optional] Calling line number</param>
        public static void Develop(object objCaller, string sMessage,
            [System.Runtime.CompilerServices.CallerMemberName] string sMethodName = "",
            [System.Runtime.CompilerServices.CallerFilePath] string sFilePath = "",
            [System.Runtime.CompilerServices.CallerLineNumber] int nLineNumber = 0)
        {
            if (s_objLogger != null)
            {
                string sLogMsg = CreateMessage(objCaller, sMessage, sMethodName, sFilePath, nLineNumber);
                s_objLogger.Debug(sLogMsg);
            }
        }

        /// <summary>
        /// Writes generic information log
        /// </summary>
        /// <param name="objCaller">Caller class object</param>
        /// <param name="sMessage">Log Message</param>
        /// <param name="sMethodName">[Optional] Calling method name</param>
        /// <param name="sFilePath">[Optional] Calling file name</param>
        /// <param name="nLineNumber">[Optional] Calling line number</param>
        /// <param name="isOutputLineNumber"></param>
        public static void Info(object objCaller, string sMessage,
            [System.Runtime.CompilerServices.CallerMemberName] string sMethodName = "",
            [System.Runtime.CompilerServices.CallerFilePath] string sFilePath = "",
            [System.Runtime.CompilerServices.CallerLineNumber] int nLineNumber = 0,
            bool isOutputLineNumber = true)
        {
            if (s_objLogger != null)
            {
                string sLogMsg = CreateMessage(objCaller, sMessage, sMethodName, sFilePath, nLineNumber, isOutputLineNumber);
                s_objLogger.Info(sLogMsg);
            }
        }

        /// <summary>
        /// Writes generic warning log
        /// </summary>
        /// <param name="objCaller">Caller class object</param>
        /// <param name="sMessage">Log Message</param>
        /// <param name="sMethodName">[Optional] Calling method name</param>
        /// <param name="sFilePath">[Optional] Calling file name</param>
        /// <param name="nLineNumber">[Optional] Calling line number</param>
        public static void Warn(object objCaller, string sMessage,
            [System.Runtime.CompilerServices.CallerMemberName] string sMethodName = "",
            [System.Runtime.CompilerServices.CallerFilePath] string sFilePath = "",
            [System.Runtime.CompilerServices.CallerLineNumber] int nLineNumber = 0)
        {
            if (s_objLogger != null)
            {
                string sLogMsg = CreateMessage(objCaller, sMessage, sMethodName, sFilePath, nLineNumber);
                s_objLogger.Warn(sLogMsg);
            }
        }

        /// <summary>
        /// Writes generic warning log
        /// </summary>
        /// <param name="objCaller"></param>
        /// <param name="objEx"></param>
        /// <param name="sMethodName"></param>
        /// <param name="sFilePath"></param>
        /// <param name="nLineNumber"></param>
        public static void Warn(object objCaller, System.Exception objEx,
            [System.Runtime.CompilerServices.CallerMemberName] string sMethodName = "",
            [System.Runtime.CompilerServices.CallerFilePath] string sFilePath = "",
            [System.Runtime.CompilerServices.CallerLineNumber] int nLineNumber = 0)
        {
            if (s_objLogger != null)
            {
                string sLogMsg = CreateMessage(objCaller, string.Format("{0}:{1}", objEx.GetType().Name, objEx.Message),
                    sMethodName, sFilePath, nLineNumber);
                s_objLogger.Warn(sLogMsg, objEx);
            }
        }

        /// <summary>
        /// Writes generic error log
        /// </summary>
        /// <param name="objCaller">Caller class object</param>
        /// <param name="sMessage">Log Message</param>
        /// <param name="sMethodName">[Optional] Calling method name</param>
        /// <param name="sFilePath">[Optional] Calling file name</param>
        /// <param name="nLineNumber">[Optional] Calling line number</param>
        public static void Error(object objCaller, string sMessage,
            [System.Runtime.CompilerServices.CallerMemberName] string sMethodName = "",
            [System.Runtime.CompilerServices.CallerFilePath] string sFilePath = "",
            [System.Runtime.CompilerServices.CallerLineNumber] int nLineNumber = 0)
        {
            if (s_objLogger != null)
            {
                string sLogMsg = CreateMessage(objCaller, sMessage, sMethodName, sFilePath, nLineNumber);
                s_objLogger.Error(sLogMsg);
            }
        }

        /// <summary>
        /// Writes generic error log
        /// </summary>
        /// <param name="objCaller">Caller class object</param>
        /// <param name="sMessage">Log Message</param>
        /// <param name="objEx">Object of Exception</param>
        /// <param name="sMethodName">[Optional] Calling method name</param>
        /// <param name="sFilePath">[Optional] Calling file name</param>
        /// <param name="nLineNumber">[Optional] Calling line number</param>
        public static void Error(object objCaller, System.Exception objEx,
            [System.Runtime.CompilerServices.CallerMemberName] string sMethodName = "",
            [System.Runtime.CompilerServices.CallerFilePath] string sFilePath = "",
            [System.Runtime.CompilerServices.CallerLineNumber] int nLineNumber = 0)
        {
            if (s_objLogger != null)
            {
                string sLogMsg = CreateMessage(objCaller, objEx.Message, sMethodName, sFilePath, nLineNumber);
                s_objLogger.Error(sLogMsg, objEx);
            }
        }

        /// <summary>
        /// Writes generic error log
        /// </summary>
        /// <param name="objCaller">Caller class object</param>
        /// <param name="sMessage">Log Message</param>
        /// <param name="objEx">Object of Exception</param>
        /// <param name="sMethodName">[Optional] Calling method name</param>
        /// <param name="sFilePath">[Optional] Calling file name</param>
        /// <param name="nLineNumber">[Optional] Calling line number</param>
        public static void Error(object objCaller, string sMessage, System.Exception objEx,
            [System.Runtime.CompilerServices.CallerMemberName] string sMethodName = "",
            [System.Runtime.CompilerServices.CallerFilePath] string sFilePath = "",
            [System.Runtime.CompilerServices.CallerLineNumber] int nLineNumber = 0)
        {
            if (s_objLogger != null)
            {
                string sLogMsg = CreateMessage(objCaller, sMessage, sMethodName, sFilePath, nLineNumber);
                s_objLogger.Error(sLogMsg, objEx);
            }
        }

        #endregion

        #region Private Methods
        /// <summary>
        /// メッセージ作成
        /// </summary>
        /// <param name="objCaller"></param>
        /// <param name="sMessage"></param>
        /// <param name="sMethodName"></param>
        /// <param name="sFilePath"></param>
        /// <param name="nLineNumber"></param>
        /// <returns></returns>
        private static string CreateMessage(object objCaller, string sMessage,
            string sMethodName, string sFilePath, int nLineNumber, bool isOutLineNumber = true)
        {
            const string FORMAT_CLASSMETHOD = @"{0}::{1}({2, 4})";
            const string FORMAT_CLASSMETHOD2 = @"{0}::{1}";
            string formatClassMethod = isOutLineNumber ? FORMAT_CLASSMETHOD : FORMAT_CLASSMETHOD2;
            string sLogMsg = string.Empty;

            if (objCaller == null)
            {
                // If objCaller if null then add calling file name
                string sFileName = Path.GetFileName(sFilePath);
                sLogMsg = string.Format(formatClassMethod, sFileName, sMethodName, nLineNumber);
            }
            else
            {
                // Add class name
                sLogMsg = string.Format(formatClassMethod, objCaller.GetType().Name, sMethodName, nLineNumber);
            }

            sLogMsg = string.Format("{0}\t{1}", sLogMsg, sMessage);

            return sLogMsg;
        }

        #endregion

        #region Protected methods

        /// <summary>
        /// PrintDllVersion
        /// </summary>
        /// <param name="dllName"></param>
        protected static void PrintDllVersion(string dllName)
        {
            FileVersionInfo version = AssemblyUtil.GetCommonDllVerInfo(dllName);
            PrintVersion(dllName, version);
        }

        /// <summary>
        /// PrintVersion
        /// </summary>
        /// <param name="name"></param>
        /// <param name="version"></param>
        protected static void PrintVersion(string name, FileVersionInfo version)
        {
            if (version == null)
            {
                Info(null, string.Format("{0} = null", name));
                Error(null, name);
            }
            else
            {
                Info(null, string.Format("{0} = {1}", name, version.FileVersion));
            }
        }
        #endregion
    }
}
