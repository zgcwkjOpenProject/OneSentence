using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace OneSentence
{
    public partial class Main : Form
    {
        #region 窗体事件

        /// <summary>
        /// 窗体入口函数
        /// </summary>
        public Main()
        {
            InitializeComponent();
        }

        #region 窗体加载完成时

        /// <summary>
        /// 窗体加载完成时
        /// </summary>
        private void Main_Load(object sender, EventArgs e)
        {
            #region 载入配置

            Txt_hitokoto.Tag = 20;//默认必须要有数据

            try
            {
                if (File.Exists("Config.ini"))
                {
                    string[] ConfigS = File.ReadAllLines("Config.ini");
                    if (ConfigS[0].Contains("请求地址"))
                    {
                        string Config = ConfigS[0].Replace("请求地址=", "");

                        this.Tag = Config;
                    }
                    if (ConfigS[1].Contains("是否置顶"))
                    {
                        string Config = ConfigS[1].Replace("是否置顶=", "");

                        this.TopMost = Convert.ToBoolean(Config);
                    }
                    if (ConfigS[2].Contains("窗体位置"))
                    {
                        string Config = ConfigS[2].Replace("窗体位置=", "");

                        this.Location = new Point(Convert.ToInt32(Config.Split(',')[0]), Convert.ToInt32(Config.Split(',')[1]));
                    }
                    if (ConfigS[3].Contains("窗体大小"))
                    {
                        string Config = ConfigS[3].Replace("窗体大小=", "");

                        this.Width = Convert.ToInt32(Config.Split(',')[0]);
                        this.Height = Convert.ToInt32(Config.Split(',')[1]);
                    }
                    if (ConfigS[4].Contains("字符长度"))
                    {
                        string Config = ConfigS[4].Replace("字符长度=", "");

                        Txt_hitokoto.Tag = Convert.ToInt32(Config);
                    }
                    if (ConfigS[5].Contains("自动换行"))
                    {
                        string Config = ConfigS[5].Replace("自动换行=", "");

                        Txt_hitokoto.AutoSize = Convert.ToBoolean(Config);
                    }
                    if (ConfigS[6].Contains("定时更换"))
                    {
                        string Config = ConfigS[6].Replace("定时更换=", "");

                        if (Convert.ToInt32(Config) >= 1000)
                        {
                            Timer_Refresh.Interval = Convert.ToInt32(Config);
                            Timer_Refresh.Enabled = true;
                        }
                    }
                    if (ConfigS[7].Contains("字体样式"))
                    {
                        string Config = ConfigS[7].Replace("字体样式=", "");
                        //字体样式
                        Txt_hitokoto.Font = new System.Drawing.Font(Convert.ToString(Config.Split('|')[0]), (float)Convert.ToDecimal(Config.Split('|')[1]), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
                        //字体颜色
                        Txt_hitokoto.ForeColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Config.Split('|')[2].Split(',')[0]), Convert.ToInt32(Config.Split('|')[2].Split(',')[1]), Convert.ToInt32(Config.Split('|')[2].Split(',')[2]));
                        //背景颜色
                        Color color = Color.FromArgb(
                            Txt_hitokoto.ForeColor.R + (Txt_hitokoto.ForeColor.R >= 250 ? -5 : Txt_hitokoto.ForeColor.R < 5 ? 5 : 0),
                            Txt_hitokoto.ForeColor.G + (Txt_hitokoto.ForeColor.G >= 250 ? -5 : Txt_hitokoto.ForeColor.G < 5 ? 5 : 0),
                            Txt_hitokoto.ForeColor.B + (Txt_hitokoto.ForeColor.B >= 250 ? -5 : Txt_hitokoto.ForeColor.B < 5 ? 5 : 0));
                        SetLayered(color);//设置透明并且实现击穿效果
                    }
                }
            }
            catch (Exception ex)
            {
                File.Delete("Config.ini");
                MessageBox.Show(ex.Message, "警告");
            }

            #endregion 载入配置

            GetOneSentence();
        }

        #endregion 窗体加载完成时

        #region 程序退出前操作

        /// <summary>
        /// 程序退出前操作
        /// </summary>
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            #region 载出配置

            string Config = "";
            Config += "请求地址=" + this.Tag;
            Config += "\r\n" + "是否置顶=" + this.TopMost;
            Config += "\r\n" + "窗体位置=" + this.Location.X + "," + this.Location.Y;
            Config += "\r\n" + "窗体大小=" + this.Width + "," + this.Height;
            Config += "\r\n" + "字符长度=" + Txt_hitokoto.Tag;
            Config += "\r\n" + "自动换行=" + Txt_hitokoto.AutoSize;
            Config += "\r\n" + "定时更换=" + Timer_Refresh.Interval;
            Config += "\r\n" + "字体样式=" + Txt_hitokoto.Font.Name + "|" + Txt_hitokoto.Font.Size + "|" + Txt_hitokoto.ForeColor.R + "," + Txt_hitokoto.ForeColor.G + "," + Txt_hitokoto.ForeColor.B;

            File.WriteAllText("Config.ini", Config, Encoding.UTF8);

            #endregion 载出配置
        }

        #endregion 程序退出前操作

        #region 配置程序

        /// <summary>
        /// 配置程序
        /// </summary>
        private void Tsm_Config_Click(object sender, EventArgs e)
        {
            Config config = (Config)Cms_Menu.Tag;
            if (config == null) Cms_Menu.Tag = config = new Config(this);
            else if (config.IsDisposed) Cms_Menu.Tag = config = new Config(this);
            config.Show();
        }

        #endregion 配置程序

        #region 退出程序

        /// <summary>
        /// 退出程序
        /// </summary>
        private void Tsm_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion 退出程序

        #region 计时器定时刷新

        /// <summary>
        /// 计时器定时刷新
        /// </summary>
        private void Timer_Refresh_Tick(object sender, EventArgs e)
        {
            GetOneSentence();
        }

        #endregion 计时器定时刷新

        #endregion 窗体事件

        #region 鼠标事件

        #region 单击复制文本

        /// <summary>
        /// 单击复制文本
        /// </summary>
        private void Txt_hitokoto_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(Txt_hitokoto.Text);
        }

        #endregion 单击复制文本

        #region 双击立刻获取

        /// <summary>
        /// 双击立刻获取
        /// </summary>
        private void Txt_hitokoto_DoubleClick(object sender, EventArgs e)
        {
            GetOneSentence();
        }

        #endregion 双击立刻获取

        #endregion 鼠标事件

        #region 获取一言

        /// <summary>
        /// 获取一言
        /// </summary>
        public void GetOneSentence()
        {
            int oneSentenceCount = 0;
            string oneSentence = "";
            do
            {
                oneSentenceCount++;//重复次数
                if (oneSentenceCount > 10)
                {
                    MessageBox.Show("已超出限定的错误次数");
                    break;
                }
                if (!File.Exists("OneSentence.ini"))
                {
                    oneSentence = HttpGet(Convert.ToString(this.Tag));
                }
                else
                {
                    string[] oneSentenceS = File.ReadAllLines("OneSentence.ini");
                    if (oneSentenceS.Length == 0) File.Delete("OneSentence.ini");
                    else oneSentence = oneSentenceS[new Random().Next(oneSentenceS.Length - 1)];
                }
            } while (oneSentence.Length > Convert.ToInt32(Txt_hitokoto.Tag) || oneSentence.Length == 0);

            if (Txt_hitokoto.AutoSize)
            {
                //==》调整窗体的参数，保持能显示完整和居中效果
                int thisWidth = this.Width;
                this.Width = oneSentence.Length * 37;//37大约为每个字体的宽度
                this.Height = 75;//还原默认高度
                if (this.FormBorderStyle == System.Windows.Forms.FormBorderStyle.Sizable) this.Height += 35;
                //this.Location = new Point(this.Location.X + thisWidth / 2 - this.Width / 2, this.Location.Y);
                //==》调整窗体的参数，保持能显示完整和居中效果
            }

            Txt_hitokoto.Text = oneSentence;
        }

        #endregion 获取一言

        #region 网络请求

        /// <summary>
        /// 请求路径
        /// </summary>
        /// <param name="Url">请求的路径</param>
        /// <returns>返回结果</returns>
        public string HttpGet(string Url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.ContentType = "text/html;charset=UTF-8";
            request.Method = "GET";

            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader myStreamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                string retString = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                return retString;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        #endregion 网络请求

        #region 设置透明并且实现击穿效果

        /// <summary>
        /// 透明方式
        /// </summary>
        private const int LWA_COLORKEY = 1;

        /// <summary>
        /// 设置透明并且实现击穿效果
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="crKey">整数型的颜色值</param>
        /// <param name="bAlpha"></param>
        /// <param name="dwFlags"></param>
        /// <returns></returns>
        [DllImport("user32", EntryPoint = "SetLayeredWindowAttributes")]
        private static extern int SetLayeredWindowAttributes(IntPtr hwnd, int crKey, int bAlpha, int dwFlags);

        /// <summary>
        /// 设置透明并且实现击穿效果
        /// </summary>
        public void SetLayered(Color color)
        {
            color = color.R >= color.B ? Color.FromArgb(color.B, color.G, color.B) : Color.FromArgb(color.R, color.G, color.R);
            string color16 = color.Name.Substring(2, 6);
            int colorInt = Convert.ToInt32(color16, 16);
            this.TransparencyKey = this.BackColor = color;
            SetLayeredWindowAttributes(this.Handle, colorInt, 255, LWA_COLORKEY);
        }

        #endregion 设置透明并且实现击穿效果

        #region 隐藏切换键中的窗体

        public static int WS_EX_TOOLWINDOW = 0x00000080;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= (int)WS_EX_TOOLWINDOW;
                return createParams;
            }
        }

        #endregion 隐藏切换键中的窗体
    }
}