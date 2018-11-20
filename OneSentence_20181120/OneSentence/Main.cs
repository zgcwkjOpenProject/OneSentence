using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
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

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            #region 载出配置

            string Config = "";
            Config += "请求地址=" + this.Tag;
            Config += "\r\n" + "是否置顶=" + this.TopMost;
            Config += "\r\n" + "窗体位置=" + this.Location.X + "," + this.Location.Y;
            Config += "\r\n" + "窗体大小=" + this.Width + "," + this.Height;
            Config += "\r\n" + "字符长度=" + Txt_hitokoto.Tag;
            Config += "\r\n" + "自动换行=" + Tt_toolTip.Tag;
            Config += "\r\n" + "定时更换="+ Timer_Refresh.Interval;
            File.WriteAllText("Config.ini", Config, Encoding.UTF8);

            #endregion 载出配置
        }

        /// <summary>
        /// 单击复制文本
        /// </summary>
        private void Txt_hitokoto_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(Txt_hitokoto.Text);
        }

        /// <summary>
        /// 双击立刻获取
        /// </summary>
        private void Txt_hitokoto_DoubleClick(object sender, EventArgs e)
        {
            GetOneSentence();
        }

        /// <summary>
        /// 配置程序
        /// </summary>
        private void Tsm_Config_Click(object sender, EventArgs e)
        {
            Config config = new Config(this);
            config.Show();
        }

        /// <summary>
        /// 退出程序
        /// </summary>
        private void Tsm_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// 计时器定时刷新
        /// </summary>
        private void Timer_Refresh_Tick(object sender, EventArgs e)
        {
            GetOneSentence();
        }

        /// <summary>
        /// 获取一言
        /// </summary>
        public void GetOneSentence()
        {
            string OneSentence = "";
            do
            {
                if (!File.Exists("OneSentence.ini"))
                {
                    OneSentence = HttpGet(Convert.ToString(this.Tag));
                }
                else
                {
                    string[] OneSentenceS = File.ReadAllLines("OneSentence.ini");
                    if (OneSentenceS.Length == 0) File.Delete("OneSentence.ini");
                    else OneSentence = OneSentenceS[new Random().Next(OneSentenceS.Length - 1)];
                }
            } while (OneSentence.Length > Convert.ToInt32(Txt_hitokoto.Tag) || OneSentence.Length == 0);

            if (Txt_hitokoto.AutoSize)
            {
                //==》调整窗体的参数，保持能显示完整和居中效果
                int thisWidth = this.Width;
                this.Width = OneSentence.Length * 37;//37大约为每个字体的宽度
                //this.Location = new Point(this.Location.X + thisWidth / 2 - this.Width / 2, this.Location.Y);
                //==》调整窗体的参数，保持能显示完整和居中效果
            }

            Txt_hitokoto.Text = OneSentence;
        }

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
    }
}