using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OneSentence
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Fd_Style.Font = label1.Font;

            string FontName = label1.Font.Name;
            float FontSize = label1.Font.Size;
            label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));




            this.Fd_Style.ShowDialog();
            label1.Font = this.Fd_Style.Font;
        }
    }
}
