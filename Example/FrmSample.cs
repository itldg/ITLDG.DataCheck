using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using ITLDG;
using Microsoft.VisualBasic;

namespace Example
{
    public partial class FrmSample : Form
    {
        public string Data = "";
        public string Result = "";
        public FrmSample(string Data = "", string Result = "")
        {
            InitializeComponent();
            txtData.Text = Data;
            txtResult.Text = Result;
        }
        Regex regIsHex = new Regex("^[0-9a-fA-F]+$");
        private void btnSave_Click(object sender, EventArgs e)
        {
            string temp1 = txtData.Text.Replace(" ", "");
            string temp2 = txtResult.Text.Replace(" ", "");
            if (string.IsNullOrEmpty(temp1) || string.IsNullOrEmpty(temp2))
            {
                MessageBox.Show("校验数据和校验结果均不能为空", "参数错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (temp1.Length % 2 != 0)
            {
                temp1 = "0" + temp1;
            }
            if (temp2.Length % 2 != 0)
            {
                temp2 = "0" + temp2;
            }
            if (!regIsHex.IsMatch(temp1))
            {
                MessageBox.Show("校验数据必须是HEX字符串", "参数错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!regIsHex.IsMatch(temp2))
            {
                MessageBox.Show("校验结果必须是HEX字符串", "参数错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Data = temp1;
            Result = temp2;
            DialogResult = DialogResult.OK;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Bin文件|*.bin";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                byte[] data = System.IO.File.ReadAllBytes(ofd.FileName);
                txtData.Text = data.GetString_HEX();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //弹窗输入数字,转换为hex字符串
            string s = Interaction.InputBox("数字转HEX", "请输入要转换的数字", "", -1, -1);
            if (int.TryParse(s, out int i))
            {
                this.txtResult.Text = i.ToString("X02").GetBytes_HEX().GetString_HEX();
            }
        }
    }
}
