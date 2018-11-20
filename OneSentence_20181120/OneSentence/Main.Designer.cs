namespace OneSentence
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.Txt_hitokoto = new System.Windows.Forms.Label();
            this.Tt_toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.NF_ico = new System.Windows.Forms.NotifyIcon(this.components);
            this.Cms_Menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Tsm_Config = new System.Windows.Forms.ToolStripMenuItem();
            this.Tsm_Close = new System.Windows.Forms.ToolStripMenuItem();
            this.Timer_Refresh = new System.Windows.Forms.Timer(this.components);
            this.Cms_Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Txt_hitokoto
            // 
            this.Txt_hitokoto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Txt_hitokoto.AutoSize = true;
            this.Txt_hitokoto.Font = new System.Drawing.Font("微软雅黑 Light", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Txt_hitokoto.Location = new System.Drawing.Point(13, 17);
            this.Txt_hitokoto.Name = "Txt_hitokoto";
            this.Txt_hitokoto.Size = new System.Drawing.Size(146, 41);
            this.Txt_hitokoto.TabIndex = 0;
            this.Txt_hitokoto.Text = "测试文本";
            this.Tt_toolTip.SetToolTip(this.Txt_hitokoto, "单击复制这段文字\r\n双击更换一段文字");
            this.Txt_hitokoto.Click += new System.EventHandler(this.Txt_hitokoto_Click);
            this.Txt_hitokoto.DoubleClick += new System.EventHandler(this.Txt_hitokoto_DoubleClick);
            // 
            // Tt_toolTip
            // 
            this.Tt_toolTip.Tag = "True";
            // 
            // NF_ico
            // 
            this.NF_ico.ContextMenuStrip = this.Cms_Menu;
            this.NF_ico.Icon = ((System.Drawing.Icon)(resources.GetObject("NF_ico.Icon")));
            this.NF_ico.Text = "一言";
            this.NF_ico.Visible = true;
            // 
            // Cms_Menu
            // 
            this.Cms_Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Tsm_Config,
            this.Tsm_Close});
            this.Cms_Menu.Name = "Cms_Menu";
            this.Cms_Menu.Size = new System.Drawing.Size(125, 48);
            // 
            // Tsm_Config
            // 
            this.Tsm_Config.Name = "Tsm_Config";
            this.Tsm_Config.Size = new System.Drawing.Size(124, 22);
            this.Tsm_Config.Text = "配置程序";
            this.Tsm_Config.Click += new System.EventHandler(this.Tsm_Config_Click);
            // 
            // Tsm_Close
            // 
            this.Tsm_Close.Name = "Tsm_Close";
            this.Tsm_Close.Size = new System.Drawing.Size(124, 22);
            this.Tsm_Close.Text = "退出程序";
            this.Tsm_Close.Click += new System.EventHandler(this.Tsm_Close_Click);
            // 
            // Timer_Refresh
            // 
            this.Timer_Refresh.Interval = 500;
            this.Timer_Refresh.Tick += new System.EventHandler(this.Timer_Refresh_Tick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(171, 75);
            this.Controls.Add(this.Txt_hitokoto);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "https://v1.hitokoto.cn/?encode=text";
            this.Text = "一言";
            this.TransparencyKey = System.Drawing.Color.Gray;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.Cms_Menu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label Txt_hitokoto;
        private System.Windows.Forms.ToolTip Tt_toolTip;
        private System.Windows.Forms.NotifyIcon NF_ico;
        private System.Windows.Forms.ContextMenuStrip Cms_Menu;
        private System.Windows.Forms.ToolStripMenuItem Tsm_Config;
        private System.Windows.Forms.ToolStripMenuItem Tsm_Close;
        private System.Windows.Forms.Timer Timer_Refresh;
    }
}

