using System;
using System.Diagnostics;
using ASM.EmployeeManagement.Common.Logger;
using System.Collections.Generic;

namespace ASM.EmployeeManagement.Common.Assembly
{
    public class AssemblyUtil
    {
        /// <summary>
        /// DLLのファイルバージョンを取得する
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static FileVersionInfo GetCommonDllVerInfo(string name)
        {
            try
            {
                FileVersionInfo fvInfo = null;
                foreach (System.Reflection.Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
                {
                    if (!assembly.FullName.Contains(name))
                    {
                        continue;
                    }

                    fvInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
                    break;
                }
                return fvInfo;
            }
            catch (System.Exception ex)
            {
                LogHelper.Error(null, string.Format("Unknown error occured. name : {0}", name), ex);
            }

            return null;
        }

        /// <summary>
        /// 存在する全てのクラス名リストを取得する
        /// </summary>
        /// <returns></returns>
        public static List<string> GetAssemblyClasses()
        {
            List<string> listClassName = new List<string>();

            foreach (System.Reflection.Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                Type[] ts = assembly.GetTypes();
                foreach (Type t in ts)
                {
                    if (t.FullName.IndexOf("ASM.Employee", StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        if (t.FullName.IndexOf(".EmployeeWebAPIServiceClient.", StringComparison.OrdinalIgnoreCase) > 0 ||
                            t.FullName.IndexOf("+<>c__DisplayClass", StringComparison.OrdinalIgnoreCase) > 0 ||
                            t.FullName.IndexOf(".Fakes.", 0) > 0
                            )
                        {
                            continue;
                        }

                        listClassName.Add(t.FullName);
                    }
                }
            }

            return listClassName;
        }
    }
}
