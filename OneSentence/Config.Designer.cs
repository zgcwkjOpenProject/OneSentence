namespace OneSentence
{
    partial class Config
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Config));
            this.But_TopMost = new System.Windows.Forms.Button();
            this.But_Position = new System.Windows.Forms.Button();
            this.But_Style = new System.Windows.Forms.Button();
            this.But_Color = new System.Windows.Forms.Button();
            this.But_BColor = new System.Windows.Forms.Button();
            this.But_OneSentence = new System.Windows.Forms.Button();
            this.But_customize = new System.Windows.Forms.Button();
            this.Fd_Style = new System.Windows.Forms.FontDialog();
            this.Cd_Color = new System.Windows.Forms.ColorDialog();
            this.Tt_toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.But_Auto = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // But_TopMost
            // 
            this.But_TopMost.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.But_TopMost.Location = new System.Drawing.Point(12, 12);
            this.But_TopMost.Name = "But_TopMost";
            this.But_TopMost.Size = new System.Drawing.Size(137, 48);
            this.But_TopMost.TabIndex = 0;
            this.But_TopMost.Text = "打开或关闭置顶";
            this.Tt_toolTip.SetToolTip(this.But_TopMost, "显示的字体是否在所有的窗体之上");
            this.But_TopMost.UseVisualStyleBackColor = true;
            this.But_TopMost.Click += new System.EventHandler(this.But_TopMost_Click);
            // 
            // But_Position
            // 
            this.But_Position.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.But_Position.Location = new System.Drawing.Point(155, 12);
            this.But_Position.Name = "But_Position";
            this.But_Position.Size = new System.Drawing.Size(137, 48);
            this.But_Position.TabIndex = 1;
            this.But_Position.Text = "调整窗体位置";
            this.Tt_toolTip.SetToolTip(this.But_Position, "调整显示字体的位置");
            this.But_Position.UseVisualStyleBackColor = true;
            this.But_Position.Click += new System.EventHandler(this.But_Position_Click);
            // 
            // But_Style
            // 
            this.But_Style.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.But_Style.Location = new System.Drawing.Point(12, 66);
            this.But_Style.Name = "But_Style";
            this.But_Style.Size = new System.Drawing.Size(137, 48);
            this.But_Style.TabIndex = 2;
            this.But_Style.Text = "调整文本样式";
            this.Tt_toolTip.SetToolTip(this.But_Style, "调整显示字体的文本样式");
            this.But_Style.UseVisualStyleBackColor = true;
            this.But_Style.Click += new System.EventHandler(this.But_Style_Click);
            // 
            // But_Color
            // 
            this.But_Color.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.But_Color.Location = new System.Drawing.Point(155, 66);
            this.But_Color.Name = "But_Color";
            this.But_Color.Size = new System.Drawing.Size(137, 48);
            this.But_Color.TabIndex = 3;
            this.But_Color.Text = "调整文本颜色";
            this.Tt_toolTip.SetToolTip(this.But_Color, "调整显示字体的文本颜色");
            this.But_Color.UseVisualStyleBackColor = true;
            this.But_Color.Click += new System.EventHandler(this.But_Color_Click);
            // 
            // But_BColor
            // 
            this.But_BColor.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.But_BColor.Location = new System.Drawing.Point(12, 120);
            this.But_BColor.Name = "But_BColor";
            this.But_BColor.Size = new System.Drawing.Size(137, 48);
            this.But_BColor.TabIndex = 4;
            this.But_BColor.Text = "调整背景颜色";
            this.Tt_toolTip.SetToolTip(this.But_BColor, "调整显示字体的阴影颜色");
            this.But_BColor.UseVisualStyleBackColor = true;
            this.But_BColor.Click += new System.EventHandler(this.But_BColor_Click);
            // 
            // But_OneSentence
            // 
            this.But_OneSentence.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.But_OneSentence.ForeColor = System.Drawing.Color.Blue;
            this.But_OneSentence.Location = new System.Drawing.Point(12, 174);
            this.But_OneSentence.Name = "But_OneSentence";
            this.But_OneSentence.Size = new System.Drawing.Size(137, 48);
            this.But_OneSentence.TabIndex = 5;
            this.But_OneSentence.Text = "立刻获取 句子";
            this.Tt_toolTip.SetToolTip(this.But_OneSentence, "立刻获取或更换新的语句");
            this.But_OneSentence.UseVisualStyleBackColor = true;
            this.But_OneSentence.Click += new System.EventHandler(this.But_OneSentence_Click);
            // 
            // But_customize
            // 
            this.But_customize.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.But_customize.ForeColor = System.Drawing.Color.Blue;
            this.But_customize.Location = new System.Drawing.Point(155, 174);
            this.But_customize.Name = "But_customize";
            this.But_customize.Size = new System.Drawing.Size(137, 48);
            this.But_customize.TabIndex = 6;
            this.But_customize.Text = "自定义 句子";
            this.Tt_toolTip.SetToolTip(this.But_customize, "自定义的语句，留空则关闭");
            this.But_customize.UseVisualStyleBackColor = true;
            this.But_customize.Click += new System.EventHandler(this.But_customize_Click);
            // 
            // But_Auto
            // 
            this.But_Auto.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.But_Auto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.But_Auto.Location = new System.Drawing.Point(155, 120);
            this.But_Auto.Name = "But_Auto";
            this.But_Auto.Size = new System.Drawing.Size(137, 48);
            this.But_Auto.TabIndex = 3;
            this.But_Auto.Text = "句子自动换行";
            this.But_Auto.UseVisualStyleBackColor = true;
            this.But_Auto.Click += new System.EventHandler(this.But_Auto_Click);
            // 
            // Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 236);
            this.Controls.Add(this.But_customize);
            this.Controls.Add(this.But_OneSentence);
            this.Controls.Add(this.But_BColor);
            this.Controls.Add(this.But_Auto);
            this.Controls.Add(this.But_Color);
            this.Controls.Add(this.But_Style);
            this.Controls.Add(this.But_Position);
            this.Controls.Add(this.But_TopMost);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(320, 275);
            this.MinimumSize = new System.Drawing.Size(320, 275);
            this.Name = "Config";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "程序配置";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button But_TopMost;
        private System.Windows.Forms.Button But_Position;
        private System.Windows.Forms.Button But_Style;
        private System.Windows.Forms.Button But_Color;
        private System.Windows.Forms.Button But_BColor;
        private System.Windows.Forms.Button But_OneSentence;
        private System.Windows.Forms.Button But_customize;
        private System.Windows.Forms.FontDialog Fd_Style;
        private System.Windows.Forms.ColorDialog Cd_Color;
        private System.Windows.Forms.ToolTip Tt_toolTip;
        private System.Windows.Forms.Button But_Auto;
    }
}