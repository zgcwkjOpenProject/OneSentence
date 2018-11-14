using System;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace OneSentence
{
    /// <summary>
    /// 网络请求工具
    /// </summary>
    public static class Http
    {
        #region 网络请求

        private static CookieContainer cookie = new CookieContainer();

        #region Get请求

        /// <summary>
        /// 请求路径
        /// </summary>
        /// <param name="Url">请求的路径</param>
        /// <returns>返回结果</returns>
        public static string HttpGet(string Url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.ContentType = "text/html;charset=UTF-8";
            request.CookieContainer = cookie;
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

        #endregion Get请求

        #region Post请求

        /// <summary>
        /// 提交数据
        /// </summary>
        /// <param name="Url">提交的路径</param>
        /// <param name="Data">提交的数据</param>
        /// <returns>返回结果</returns>
        public static string HttpPost(string Url, string Data)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
                request.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
                request.ContentLength = Encoding.UTF8.GetByteCount(Data);
                request.CookieContainer = cookie;
                request.Referer = Url;
                request.Method = "POST";

                Stream myRequestStream = request.GetRequestStream();
                byte[] postBytes = Encoding.UTF8.GetBytes(Data);
                myRequestStream.Write(postBytes, 0, postBytes.Length);

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                response.Cookies = cookie.GetCookies(response.ResponseUri);

                StreamReader myStreamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                string retString = myStreamReader.ReadToEnd();
                myStreamReader.Close();

                return retString;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        #endregion Post请求

        #endregion 网络请求

        #region 设置证书

        /// <summary>
        /// 设置证书策略
        /// Sets the cert policy
        /// </summary>
        public static void SetCertificatePolicy()
        {
            ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;
        }

        /// <summary>
        /// 远程证书验证
        /// </summary>
        private static bool RemoteCertificateValidate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors error)
        {
            // 信任任何证书
            System.Console.WriteLine("Warning, trust any certificate");
            return true;
        }

        #endregion 设置证书
    }
}