using System;
using System.Drawing;
using System.Windows.Forms;

namespace OneSentence
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            string hitokoto = "";
            do
            {
                hitokoto = OneSentence.Http.HttpGet("https://v1.hitokoto.cn/?encode=text");
            } while (hitokoto.Length > 15);

            int thisWidth = this.Width;
            this.Width = hitokoto.Length * 37;
            this.Location = new Point(this.Location.X + thisWidth / 2 - this.Width / 2, this.Location.Y);

            Txt_hitokoto.Text = hitokoto;
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                MessageBox.Show("F2启动或关闭置顶\r\nF3调整窗体位置\r\nF4调整文本样式\r\nF5调整文本颜色\r\nF6调整背景颜色", "帮助");
            }
            if (e.KeyCode == Keys.F2)
            {
                this.TopMost = !this.TopMost;
            }
            if (e.KeyCode == Keys.F3)
            {
                if (this.FormBorderStyle == System.Windows.Forms.FormBorderStyle.Sizable)
                {
                    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    this.TransparencyKey = System.Drawing.Color.Gray;
                    this.BackColor = System.Drawing.Color.Gray;
                }
                else
                {
                    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                    this.TransparencyKey = System.Drawing.Color.Transparent;
                }
            }
            if (e.KeyCode == Keys.F4)
            {
                this.Fd_Style.Font = Txt_hitokoto.Font;

                this.Fd_Style.ShowDialog();
                Txt_hitokoto.Font = this.Fd_Style.Font;
            }
            if (e.KeyCode == Keys.F5)
            {
                this.Cd_color.Color = Txt_hitokoto.ForeColor;

                this.Cd_color.ShowDialog();
                Txt_hitokoto.ForeColor = this.Cd_color.Color;
            }
            if (e.KeyCode == Keys.F6)
            {
                this.Cd_color.Color = this.BackColor;

                this.Cd_color.ShowDialog();
                this.BackColor = this.Cd_color.Color;
                this.TransparencyKey = this.Cd_color.Color;
            }
        }
    }
}