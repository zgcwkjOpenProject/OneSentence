using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace OneSentence
{
    public partial class Config : Form
    {
        private Main main;//存储主窗体

        public Config(Main main)
        {
            InitializeComponent();
            this.main = main;
            GoToolTip();//提示显示增加当前状态
        }

        /// <summary>
        /// 启动或关闭置顶
        /// </summary>
        private void But_TopMost_Click(object sender, EventArgs e)
        {
            main.TopMost = !main.TopMost;
            GoToolTip();//提示显示增加当前状态
        }

        /// <summary>
        /// 调整窗体位置
        /// </summary>
        private void But_Position_Click(object sender, EventArgs e)
        {
            if (main.FormBorderStyle == System.Windows.Forms.FormBorderStyle.Sizable)
            {
                main.Location = new Point(main.Location.X, main.Location.Y + 35);//保持字体位置不变
                main.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;//设置窗体样式
                //main.SetLayered(main.BackColor);//设置透明并且实现击穿效果
            }
            else
            {
                main.Location = new Point(main.Location.X, main.Location.Y - 35);//保持字体位置不变
                main.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;//设置窗体样式
                //main.TransparencyKey = System.Drawing.Color.Transparent;
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
            Color color = Color.FromArgb(
                this.Cd_Color.Color.R + (this.Cd_Color.Color.R >= 250 ? -5 : this.Cd_Color.Color.R < 5 ? 5 : 0),
                this.Cd_Color.Color.G + (this.Cd_Color.Color.G >= 250 ? -5 : this.Cd_Color.Color.G < 5 ? 5 : 0),
                this.Cd_Color.Color.B + (this.Cd_Color.Color.B >= 250 ? -5 : this.Cd_Color.Color.B < 5 ? 5 : 0));
            main.SetLayered(color);//设置透明并且实现击穿效果
        }

        /// <summary>
        /// 调整配置文件
        /// </summary>
        private void But_Config_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("notepad.exe", "Config.ini");
        }

        /// <summary>
        /// 句子自动换行
        /// </summary>
        private void But_Auto_Click(object sender, EventArgs e)
        {
            main.Txt_hitokoto.AutoSize = !main.Txt_hitokoto.AutoSize;
            main.Txt_hitokoto.Width = main.Width - 26;
            GoToolTip();//提示显示增加当前状态
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
            if (!File.Exists("OneSentence.ini"))//判断是否存在该文件
            {
                DialogResult DRB = MessageBox.Show("需要输出示例文件？", "提示", MessageBoxButtons.YesNo);
                if (DRB == DialogResult.Yes) OneSentence = "忘羡一曲远，曲终人不散\r\n苹果是给那些为了爱选择死亡的人的奖励\r\n我从远方赶来，恰巧你们也在";
                File.WriteAllText("OneSentence.ini", OneSentence, Encoding.UTF8);
            }
            System.Diagnostics.Process.Start("notepad.exe", "OneSentence.ini");
        }

        /// <summary>
        /// 提示显示增加当前状态
        /// </summary>
        private void GoToolTip()
        {
            Tt_toolTip.SetToolTip(But_TopMost, "显示的字体是否在所有的窗体之上\n当前状态：" + (main.TopMost ? "打开置顶" : "关闭置顶"));
            Tt_toolTip.SetToolTip(But_Auto, "句子自动换行\n当前状态：" + (main.Txt_hitokoto.AutoSize ? "关闭换行" : "打开换行"));
        }
    }
}