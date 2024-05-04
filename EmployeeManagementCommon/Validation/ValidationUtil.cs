namespace ASM.EmployeeManagement.Common.Validation
{
    /// <summary>
    /// Validation Utility class
    /// </summary>
    public class ValidationUtil
    {
        /// <summary>
        /// To check Inclusive For Integer
        /// </summary>
        /// <param name="nValue"></param>
        /// <param name="nMinInclusive"></param>
        /// <param name="nMaxInclusive"></param>
        /// <returns>True : 成功
        /// 　　　　　False : 失敗　</returns>
        public static bool IsValidInclusive(int nValue, int nMinInclusive, int nMaxInclusive)
        {
            try
            {
                if (nValue >= nMinInclusive && nValue <= nMaxInclusive)
                {
                    return true;
                }

                return false;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 渡された文字列の長さをチックする
        /// </summary>
        /// <param name="sValue">文字列</param>
        /// <param name="nMinVal">最低値</param>
        /// <param name="nMaxVal">最大値</param>
        /// <returns>True : 成功
        /// 　　　　　False : 失敗　</returns>
        public static bool IsValidLen(string sValue, int nMinVal, int nMaxVal)
        {
            try
            {
                if (string.IsNullOrEmpty(sValue) == true)
                {
                    return false;
                }

                if (sValue.Length >= nMinVal && sValue.Length <= nMaxVal)
                {
                    return true;
                }

                return false;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
    }
}
