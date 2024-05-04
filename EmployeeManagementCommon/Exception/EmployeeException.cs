using System;
using System.IO;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ASM.EmployeeManagement.Common.Exception
{
    /// <summary>
    /// Exception handler for WWSRF
    /// </summary>
    [Serializable]
    public class EmployeeException : System.Exception
    {
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="nLineNumber"></param>
        public EmployeeException([System.Runtime.CompilerServices.CallerLineNumber] int nLineNumber = 0)
        {
            StackFrame sf = new StackFrame(1, true);
            SetClassName(sf.GetMethod().ReflectedType.FullName);
            SetLineNumber(nLineNumber);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="objEx"></param>
        public EmployeeException(EmployeeException objEx) : base("", objEx)
        {
            ClassName = objEx.ClassName;
            LineNumber = objEx.LineNumber;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="objEx"></param>
        /// <param name="nLineNumber"></param>
        public EmployeeException(System.Exception objEx, [System.Runtime.CompilerServices.CallerLineNumber] int nLineNumber = 0) : base(objEx.Message, objEx)
        {
            StackFrame sf = new StackFrame(1, true);
            SetClassName(sf.GetMethod().ReflectedType.FullName);
            SetLineNumber(nLineNumber);
        }
        #endregion

        #region Properties

        /// <summary>
        /// LineNumber Property
        /// </summary>
        public int LineNumber { get; set; } = -1;

        /// <summary>
        /// Classname Property
        /// </summary>
        public string ClassName { get; set; } = null;

        #endregion

        #region protected methods

        /// <summary>
        /// SetLineNumber
        /// </summary>
        /// <param name="lineNumber"></param>
        protected void SetLineNumber(int lineNumber)
        {
            LineNumber = lineNumber;
        }

        /// <summary>
        /// SetClassName
        /// </summary>
        /// <param name="className"></param>
        protected void SetClassName(string className)
        {
            try
            {
                ClassName = Path.GetFileName(className);
            }
            catch (System.Exception)
            {
                ClassName = className;
            }
        }

        #endregion

        #region override method

        /// <summary>
        /// GetObjectData
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }

        #endregion
    }
}
