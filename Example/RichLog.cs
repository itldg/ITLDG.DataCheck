using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITLDG
{
    public class RichLog
    {
        readonly RichTextBox rich;
        /// <summary>
        /// 是否显示时间
        /// </summary>
        public bool ShowTime = true;
        public RichLog(RichTextBox rich, bool showTime)
        {
            this.rich = rich;
            ShowTime = showTime;
        }
        public void AddLog(string msg, LogType type = LogType.Normal)
        {
            rich.SelectionStart = rich.TextLength;
            rich.SelectionLength = 0;
            rich.SelectionColor = GetColor(type);
            if (ShowTime)
            {
                rich.AppendText(DateTime.Now.ToString("HH:mm:ss") + " ");
            }
            rich.AppendText(msg + "\r\n");
        }
        public void Clear()
        {
            rich.Clear();
        }
        private Color GetColor(LogType type)
        {
            switch (type)
            {
                case LogType.Normal:
                    return Color.Black;
                case LogType.Success:
                    return Color.Green;
                case LogType.Warning:
                    return Color.Orange;
                case LogType.Error:
                    return Color.Red;
                default:
                    return Color.Black;
            }
        }
    }
    public enum LogType
    {
        //常规
        Normal,
        //成功
        Success,
        //警告
        Warning,
        //错误
        Error,
    }
}
