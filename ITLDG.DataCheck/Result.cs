using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ITLDG.DataCheck
{
    public class Result
    {
        /// <summary>
        /// 处理名称
        /// </summary>
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// 二次处理
        /// </summary>
        public bool Double = true;
        /// <summary>
        /// 处理过程
        /// </summary>
        /// <param name="DataStr">处理前数据</param>
        /// <returns>处理后数据</returns>
        public virtual string Convert(string DataStr) { return null; }
        public override string ToString()
        {
            return Name.ToString();
        }

        public static List<Result> GetResults()
        {
            List<Result> list = new List<Result>();
            //获取命名空间
            string nameSpace = MethodBase.GetCurrentMethod().DeclaringType.Namespace;
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type[] typelist = GetTypesInNamespace(assembly, nameSpace + ".Results");
            for (int i = typelist.Length - 1; i >= 0; i--)
            {
                Result result = assembly.CreateInstance(nameSpace + ".Results." + typelist[i].Name) as Result;
                list.Add(result);
            }
            return list;
        }
        static Type[] GetTypesInNamespace(Assembly assembly, string nameSpace)
        {
            return assembly.GetTypes().Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal)).ToArray();
        }
    }
}
