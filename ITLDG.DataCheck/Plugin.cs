using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ITLDG.DataCheck
{
    public class Plugin
    {
        /// <summary>
        /// 插件名称
        /// </summary>
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// 校验数据
        /// </summary>
        /// <param name="DataByte">要校验的内容字节格式</param>
        /// <returns>校验结果</returns>
        public virtual byte[] CheckData(byte[] DataByte) { return null; }
        public override string ToString()
        {
            return Name.ToString();
        }

        public static List<Plugin> GePlugins()
        {
            List<Plugin> list = new List<Plugin>();
            string nameSpace = MethodBase.GetCurrentMethod().DeclaringType.Namespace;
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type[] typelist = GetTypesInNamespace(assembly, nameSpace + ".Plugins");
            for (int i = typelist.Length - 1; i >= 0; i--)
            {
                Plugin plugin = assembly.CreateInstance(nameSpace + ".Plugins." + typelist[i].Name) as Plugin;
                list.Add(plugin);
            }
            GetFilePlugins(ref list);
            return list;
        }
        static void GetFilePlugins(ref List<Plugin> list)
        {
            string pluginDir = $"{AppDomain.CurrentDomain.BaseDirectory}check_plugins";
            if (!Directory.Exists(pluginDir))
            {
                Directory.CreateDirectory(pluginDir);
                return;
            }
            string[] files = Directory.GetFiles(pluginDir, "*.dll");
            foreach (string file in files)
            {
                try
                {
                    Assembly assembly = Assembly.LoadFile(file);
                    Type[] types = assembly.GetTypes();
                    foreach (Type type in types)
                    {
                        if (type.BaseType.FullName== "ITLDG.DataCheck.Plugin")
                        {
                            Plugin plugin = (Plugin)Activator.CreateInstance(type);
                            list.Add(plugin);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("加载插件失败：" + ex.Message);
                }
            }
        }
        static Type[] GetTypesInNamespace(Assembly assembly, string nameSpace)
        {
            return assembly.GetTypes().Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal)).ToArray();
        }
    }

    public class CheckResult
    {

        public CheckResult(string resultName, string resultValue, string resultType)
        {
            ResultName = resultName;
            ResultValue = resultValue;
            ResultType = resultType;
        }
        private string _ResultName;

        public string ResultName
        {
            get { return _ResultName; }
            set { _ResultName = value; }
        }

        private string _ResultValue;


        public string ResultValue
        {
            get { return _ResultValue; }
            set { _ResultValue = value; }
        }

        private string _ResultType;
        /// <summary>
        /// 结果类型 hex,dec
        /// </summary>

        public string ResultType
        {
            get { return _ResultType; }
            set { _ResultType = value; }
        }


        private string _ResultRemarks;
        /// <summary>
        /// 备注
        /// </summary>
        public string ResultRemarks
        {
            get { return _ResultRemarks; }
            set { _ResultRemarks = value; }
        }

    }

    public class CheckInfo
    {
        public CheckInfo()
        {
        }

        public CheckInfo(string data, string result)
        {

            DataByte = data.GetBytes_HEX();
            ResultByte = result.GetBytes_HEX();
            Data = DataByte.GetString_HEX("");
            Result = ResultByte.GetString_HEX("");

        }

        private string _Data;
        /// <summary>
        /// 校验的数据
        /// </summary>
        public string Data
        {
            get { return _Data; }
            set { _Data = value; }
        }

        private byte[] _DataByte;
        /// <summary>
        /// 校验的数据字节集
        /// </summary>
        public byte[] DataByte
        {
            get { return _DataByte; }
            set { _DataByte = value; }
        }

        private string _Result;
        /// <summary>
        /// 结果
        /// </summary>
        public string Result
        {
            get { return _Result; }
            set { _Result = value; }
        }

        private byte[] _ResultByte;
        /// <summary>
        /// 结果的数据字节集
        /// </summary>
        public byte[] ResultByte
        {
            get { return _ResultByte; }
            set { _ResultByte = value; }
        }
    }
}
