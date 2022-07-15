using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace OneSentence
{
    public partial class Config : Form
    {
        Main main;

        public Config(Main main)
        {
            InitializeComponent();
            this.main = main;
        }

        /// <summary>
        /// 启动或关闭置顶
        /// </summary>
        private void But_TopMost_Click(object sender, EventArgs e)
        {
            main.TopMost = !main.TopMost;
        }

        /// <summary>
        /// 调整窗体位置
        /// </summary>
        private void But_Position_Click(object sender, EventArgs e)
        {
            if (main.FormBorderStyle == System.Windows.Forms.FormBorderStyle.Sizable)
            {
                main.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                main.TransparencyKey = System.Drawing.Color.Gray;
                main.BackColor = System.Drawing.Color.Gray;
            }
            else
            {
                main.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                main.TransparencyKey = System.Drawing.Color.Transparent;
            }
        }

        /// <summary>
        /// 调整文本样式
        /// </summary>
        private void But_Style_Click(object sender, EventArgs e)
        {
            this.Fd_Style.Font = main.Txt_hitokoto.Font;

            this.Fd_Style.ShowDialog();
            main.Txt_hitokoto.Font = this.Fd_Style.Font;
        }

        /// <summary>
        /// 调整文本颜色
        /// </summary>
        private void But_Color_Click(object sender, EventArgs e)
        {
            this.Cd_Color.Color = main.Txt_hitokoto.ForeColor;

            this.Cd_Color.ShowDialog();
            main.Txt_hitokoto.ForeColor = this.Cd_Color.Color;
        }

        /// <summary>
        /// 调整背景颜色
        /// </summary>
        private void But_BColor_Click(object sender, EventArgs e)
        {
            this.Cd_Color.Color = main.BackColor;

            this.Cd_Color.ShowDialog();
            main.BackColor = this.Cd_Color.Color;
            main.TransparencyKey = this.Cd_Color.Color;
        }

        /// <summary>
        /// 立刻获取 一言
        /// </summary>
        private void But_OneSentence_Click(object sender, EventArgs e)
        {
            main.GetOneSentence();
        }

        /// <summary>
        /// 自定义 一言
        /// </summary>
        private void But_customize_Click(object sender, EventArgs e)
        {
            string OneSentence = "";//默认输出为空文本
            DialogResult DRB = MessageBox.Show("需要输出示例文件？", "提示", MessageBoxButtons.YesNo);
            if (DRB == DialogResult.Yes) OneSentence = "忘羡一曲远，曲终人不散\r\n苹果是给那些为了爱选择死亡的人的奖励\r\n我从远方赶来，恰巧你们也在";
            File.WriteAllText("OneSentence.ini", OneSentence, Encoding.UTF8);
            System.Diagnostics.Process.Start("notepad.exe", "OneSentence.ini");
        }
    }
}