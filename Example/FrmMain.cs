using CRC;
using ITLDG;
using ITLDG.DataCheck;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example
{
    public partial class FrmMain : Form
    {
        RichLog log;
        List<CheckInfo> listCheck = new List<CheckInfo>();
        public FrmMain()
        {
            InitializeComponent();
        }
        private void FrmMain_Shown(object sender, EventArgs e)
        {
            log = new RichLog(rtbLog, true);
            try
            {
                log.AddLog("开始加载插件");
                InitPlugins();
                log.AddLog("成功加载校验规则：" + listPlugin.Count + "个", LogType.Success);
                InitResults();
                log.AddLog("成功加载结果规则：" + listResult.Count + "个", LogType.Success);
            }
            catch (Exception ex)
            {
                log.AddLog("加载插件异常：" + ex.Message, LogType.Error);
            }



        }
        List<Plugin> listPlugin = new List<Plugin>();
        List<Result> listResult = new List<Result>();
        void InitPlugins()
        {

            listPlugin = Plugin.GePlugins();
            listPlugin = listPlugin.OrderBy(x => x.Name).ToList();
            //foreach (var item in listPlugin)
            //{
            //    Debug.WriteLine(item.Name);
            //}

            cmbCheckType.Items.Clear();
            cmbCheckType.Items.AddRange(listPlugin.ToArray());
            if (cmbCheckType.Items.Count > 0)
            {
                cmbCheckType.SelectedIndex = 0;
            }
        }

        void InitResults()
        {
            listResult=Result.GetResults();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmSample frm = new FrmSample();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                listCheck.Add(new CheckInfo(frm.Data, frm.Result));
                ReloadList();
            }
        }
        void ReloadList()
        {
            lvList.BeginUpdate();

            lvList.Items.Clear();
            foreach (var item in listCheck)
            {
                lvList.Items.Add(new ListViewItem(new String[] { item.Result, item.Data }));
            }
            lvList.EndUpdate();
        }
        private void BtnCheck_Click(object sender, EventArgs e)
        {
            log.Clear();
            byte[] dataByte = txtData.Text.GetBytes_HEX();
            Plugin p = cmbCheckType.SelectedItem as Plugin;
            ShowCheckResult(p, dataByte);
        }
        private void BtnCheckAll_Click(object sender, EventArgs e)
        {
            log.Clear();
            byte[] dataByte = txtData.Text.GetBytes_HEX();
            ShowCheckResultAll(listPlugin, dataByte);
        }
        void ShowCheckResult(Plugin p, byte[] bytes)
        {
            try
            {
                List<CheckResult> list = new List<CheckResult>();
                Common.ByteResultToCheckResult(ref list, p.CheckData(bytes));
                if (list.Count == 0)
                {
                    log.AddLog($"{p.Name} 校验未获取到结果", LogType.Warning);
                    return;
                }
                log.AddLog($"校验名称 {p.Name}", LogType.Success);
                foreach (var item in list)
                {
                    log.AddLog(item.ResultName + "：" + item.ResultValue + "     " + item.ResultRemarks, LogType.Success);
                }
            }
            catch (Exception ex)
            {
                log.AddLog($"校验失败 {p.Name}," + ex.Message, LogType.Error);
            }
        }
        void ShowCheckResultAll(List<Plugin> listPlugin, byte[] bytes)
        {
            foreach (var p in listPlugin)
            {
                ShowCheckResult(p, bytes);
                log.AddLog("".PadLeft(60, '='));
            }

        }

        bool CheckSelect()
        {
            if (lvList.SelectedItems != null && lvList.SelectedItems.Count == 1)
            {
                return true;
            }
            return false;
        }
        private void lvList_DoubleClick(object sender, EventArgs e)
        {
            Edit();
        }
        void Edit()
        {
            if (CheckSelect())
            {
                CheckInfo ci = listCheck[lvList.SelectedItems[0].Index];
                FrmSample frmEdit = new FrmSample(ci.Data, ci.Result);
                if (frmEdit.ShowDialog() == DialogResult.OK)
                {
                    listCheck[lvList.SelectedItems[0].Index] = new CheckInfo(frmEdit.Data, frmEdit.Result);
                    ReloadList();
                }
            }
        }
        void Delete()
        {
            if (lvList.SelectedItems != null)
            {
                for (int i = lvList.SelectedItems.Count - 1; i >= 0; i--)
                {
                    listCheck.RemoveAt(lvList.SelectedItems[i].Index);
                }
                ReloadList();
            }
        }
        private void lvList_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                Delete();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            listCheck.Clear();
            ReloadList();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "文本文件|*.txt"
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string[] lines = System.IO.File.ReadAllLines(ofd.FileName);
                foreach (var item in lines)
                {
                    string[] arr = item.Split(',');
                    if (arr.Length != 2)
                    {
                        continue;
                    }
                    listCheck.Add(new CheckInfo(arr[0], arr[1]));
                }
                ReloadList();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "文本文件|*.txt"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var item in listCheck)
                {
                    sb.AppendLine(item.Data + "," + item.Result);
                }
                System.IO.File.WriteAllText(sfd.FileName, sb.ToString());
            }
        }
        int success = 0;
        int answerCount = 0;
        CancellationTokenSource tokenSource;
        private async void btnCheckTest_Click(object sender, EventArgs e)
        {
            if (btnCheckTest.Text == "停止推算")
            {
                btnCheckTest.Text = "推算校验";
                //任务取消
                tokenSource.Cancel();
                return;
            }
            
            if (listCheck.Count == 0)
            {
                MessageBox.Show("请先添加一些例子以便进行验证", "例子为空", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            lblAnswer.ForeColor = Color.Black;
            success = 0;
            answerCount = 0;
            lblPg.Visible = true;
            btnCheckTest.Text = "停止推算";

            log.Clear();
            //统计程序执行耗时
            DateTime dtStart = DateTime.Now;
            log.AddLog("   ".PadLeft(10, '=') + "开始分析," + listCheck.Count + "个样本" + "   ".PadRight(10, '='));

            //启动一个任务,允许中断
            tokenSource = new CancellationTokenSource();
            CancellationToken cancellationToken = tokenSource.Token;
            await Task.Run(Begin, cancellationToken);

            btnCheckTest.Text = "开始推算";
            if (tokenSource.IsCancellationRequested)
            {
                log.AddLog("   ".PadLeft(10, '=') + "任务终止,耗时:" + (DateTime.Now - dtStart).TotalSeconds.ToString("0.00") + "秒" + "   ".PadRight(10, '='));
            }
            else
            {
                log.AddLog("   ".PadLeft(10, '=') + "分析完成,耗时:" + (DateTime.Now - dtStart).TotalSeconds.ToString("0.00") + "秒" + "   ".PadRight(10, '='));
            }
        }
        void SetAnswer()
        {
            RunUI(() =>
            {
                lblAnswer.Text = "已测试" + answerCount + "个结果," + success + "个符合";
            });
        }
        void Begin() {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < listPlugin.Count; i++)
            {
                if (tokenSource.IsCancellationRequested) break;
                RunUI(() =>
                {
                    lblPg.Text = i + "/" + listPlugin.Count;
                });
                try
                {
                    List<CheckResult> listCheckResult = new List<CheckResult>();
                    Common.ByteResultToCheckResult(ref listCheckResult, listPlugin[i].CheckData(listCheck[0].DataByte));
                    for (int i2 = 0; i2 < listCheckResult.Count; i2++)
                    {
                        if (tokenSource.IsCancellationRequested) break;
                        var item = listCheckResult[i2];
                        foreach (var itemResult in listResult)
                        {
                            if (tokenSource.IsCancellationRequested) break;
                            string newResult;
                            try
                            {
                                newResult = itemResult.Convert(item.ResultValue);
                                if (string.IsNullOrEmpty(newResult))
                                {
                                    continue;
                                }
                                ResultCheck(sb, newResult, listCheck, itemResult, item, i, i2, ref success);
                            }
                            catch (Exception ex)
                            {
                                continue;
                            }

                            foreach (var itemResult2 in listResult)
                            {
                                try
                                {
                                    if (itemResult2.Name == itemResult.Name)
                                    {
                                        continue;
                                    }
                                    string newResult2 = itemResult2.Convert(newResult);
                                    if (string.IsNullOrEmpty(newResult2))
                                    {
                                        continue;
                                    }
                                    ResultCheck(sb, newResult2, listCheck, itemResult2, item, i, i2, ref success, itemResult);
                                }
                                catch (Exception ex)
                                {
                                }
                            }


                        }
                    }
                }
                catch (Exception ex)
                {

                }

            }

            RunUI(() =>
            {
                lblAnswer.Text = $"尝试了 {listPlugin.Count} 种编码方案,{answerCount} 种结果," + (success > 0 ? (success + "个结果符合") : "未找到有效结果");
                if (success > 0)
                {
                    log.AddLog(sb.ToString(), LogType.Success);
                    lblAnswer.ForeColor = Color.Green;
                }
                else
                {
                    lblAnswer.ForeColor = Color.Red;
                }
                lblPg.Visible = false;
                Application.DoEvents();
            });
        }
        void RunUI(Action action)
        {
            this.Invoke((MethodInvoker)delegate ()
            {
                action();
                Application.DoEvents();
            });
        }
        /// <summary>
        /// 结果检查
        /// </summary>
        /// <param name="sb">结果保存文本</param>
        /// <param name="newResult">经过转换的结果</param>
        /// <param name="listCheckTemp">例子数据</param>
        /// <param name="itemResult">转换的方法</param>
        /// <param name="item">被检查的结果</param>
        /// <param name="i">插件索引</param>
        /// <param name="i2">结果索引</param>
        /// <param name="success">成功数量</param>
        /// <param name="itemResultBefor">之前的结果转换方式</param>
        void ResultCheck(StringBuilder sb, string newResult, List<CheckInfo> listCheckTemp, Result itemResult, CheckResult item, int i, int i2, ref int success, Result itemResultBefor = null)
        {
            try
            {
                answerCount++;
                SetAnswer();
                if (newResult.Contains(listCheckTemp[0].Result))
                {
                    if (Check(listCheckTemp, listPlugin[i], itemResult, i2, itemResultBefor))
                    {
                        success++;
                        sb.AppendLine("校验方式：" + listPlugin[i].Name);
                        sb.AppendLine("校验结果：" + item.ResultValue + "   (" + item.ResultName + ")" + item.ResultRemarks);
                        sb.AppendLine("验证方式：" + (itemResultBefor == null ? "" : itemResultBefor.Name + ",") + itemResult.Name);
                        sb.AppendLine("".PadLeft(60, '='));
                    }
                }
            }
            catch (Exception)
            {

            }


            //Hex值做异或运算再次尝试
            if (item.ResultType == "hex")
            {
                HashSet<string> hs = new HashSet<string>();
                foreach (object o in Enum.GetValues(typeof(BitOperation)))
                {
                    if (tokenSource.IsCancellationRequested) break;
                    foreach (var item2 in listCheckTemp)
                    {
                        if (tokenSource.IsCancellationRequested) break;
                        try
                        {
                            List<CheckResult> listCr = new List<CheckResult>();
                            Common.ByteResultToCheckResult(ref listCr, listPlugin[i].CheckData(item2.DataByte));
                            string hexTemp = itemResult.Convert(listCr[i2].ResultValue);
                            if (string.IsNullOrEmpty(hexTemp))
                            {
                                continue;
                            }
                            if (itemResultBefor != null)
                            {
                                hexTemp = itemResultBefor.Convert(hexTemp);
                            }

                            string hex = HexConvert(item2.Result, hexTemp, (BitOperation)o);
                            //string hex2 = HexConvert(listCheckTemp[0].Result, newResult, (BitOperation)o);
                            if (hex.Replace("0", "") == "")
                            {
                                continue;
                            }
                            if (hs.Contains(hex))
                            {
                                continue;
                            }
                            hs.Add(hex);
                            answerCount++;
                            SetAnswer();
                            if (Check(listCheckTemp, listPlugin[i], itemResult, i2, itemResultBefor, hex, (BitOperation)o))
                            {
                                success++;
                                sb.AppendLine("校验方式：" + listPlugin[i].Name);
                                sb.AppendLine("校验结果：" + item.ResultValue + "   (" + item.ResultName + ")" + item.ResultRemarks);
                                sb.AppendLine($"验证方式：{itemResult.Name}({newResult}),{(itemResultBefor == null ? "" : itemResultBefor.Name + ",")}结果与{hex}进行{o.ToString()}({HexConvert(newResult, hex, (BitOperation)o)})");
                                sb.AppendLine("".PadLeft(60, '='));
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.Message);
                            Debug.WriteLine(ex.StackTrace);
                        }
                    }
                }

                try
                {
                    List<int> listNum = CommonBit.DisplacementCheck(listCheckTemp[0].Result, newResult);
                    if (listNum.Count > 0)
                    {
                        foreach (var num in listNum)
                        {
                            if (tokenSource.IsCancellationRequested) break;
                            answerCount++;
                            SetAnswer();
                            if (CheckDisplacement(listCheckTemp, listPlugin[i], itemResult, i2, num))
                            {
                                success++;

                                sb.AppendLine("校验方式：" + listPlugin[i].Name);
                                sb.AppendLine("校验结果：" + item.ResultValue + "   (" + item.ResultName + ")" + item.ResultRemarks);
                                sb.AppendLine($"验证方式：{itemResult.Name}({newResult}),{(itemResultBefor == null ? "" : itemResultBefor.Name + ",")}结果 {(num > 0 ? "左" : "右")}位移 {Math.Abs(num)} 位({CommonBit.Displacement(newResult, num)})");
                                sb.AppendLine("".PadLeft(60, '='));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {

                    throw;
                }

            }
        }
        bool Check(List<CheckInfo> listChekTemp, Plugin p, Result r, int resultIndex, Result r2 = null, string hex = "", BitOperation bitOperation = BitOperation.XOR)
        {
            foreach (var item in listChekTemp)
            {
                if (tokenSource.IsCancellationRequested) break;
                List<CheckResult> listResult = new List<CheckResult>();
                Common.ByteResultToCheckResult(ref listResult, p.CheckData(item.DataByte));
                if (listResult.Count <= resultIndex)
                {
                    return false;
                }
                CheckResult cr = listResult[resultIndex];
                string newResult = r.Convert(cr.ResultValue);
                if (r2 != null)
                {
                    newResult = r2.Convert(newResult);
                }
                if (string.IsNullOrEmpty(hex))
                {
                    if (!newResult.Contains(item.Result))
                    {
                        return false;
                    }
                }
                else
                {
                    string hexConvert = HexConvert(newResult, hex, bitOperation);
                    if (!hexConvert.Contains(item.Result))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 位移验证
        /// </summary>
        bool CheckDisplacement(List<CheckInfo> listChekTemp, Plugin p, Result r, int resultIndex, int num)
        {
            foreach (var item in listChekTemp)
            {
                if (tokenSource.IsCancellationRequested) break;
                List<CheckResult> listResult = new List<CheckResult>();
                Common.ByteResultToCheckResult(ref listResult, p.CheckData(item.DataByte));
                if (listResult.Count <= resultIndex)
                {
                    return false;
                }
                CheckResult cr = listResult[resultIndex];
                string newResult = r.Convert(cr.ResultValue);

                string newHex = CommonBit.Displacement(newResult, num);
                if (newHex != item.Result)
                {
                    return false;
                }
            }
            return true;
        }
        string HexConvert(string NewResult, string Result, BitOperation bitOperation)
        {
            switch (bitOperation)
            {
                case BitOperation.AND:
                    return CommonBit.HexAND(NewResult, Result);
                case BitOperation.OR:
                    return CommonBit.HexOR(NewResult, Result);
                case BitOperation.XOR:
                    return CommonBit.HexXOR(NewResult, Result);
                default:
                    return "";
            }
        }

        private void 编辑样本ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void 删除样本ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete();
        }
    }
}
