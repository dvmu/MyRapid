/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
namespace MyRapid.Code
{
    public static class WebHelper
    {
        public static bool ValidateIp(string address)
        {
            IPAddress ip;
            return (IPAddress.TryParse(address, out ip));
        }
        public static bool ValidateIpv4(string address)
        {
            Regex rx = new Regex(@"((?:(?:25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d)))\.){3}(?:25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d))))");
            return rx.IsMatch(address);
        }
        public static string HideIp(string address, int left = 2)
        {
            try
            {
                if (left < 0) return "*.*.*.*";
                if (left > 3) return address;
                if (ValidateIpv4(address))
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    string[] ips = address.Split('.');
                    for (int i = 0; i < left; i++)
                    {
                        stringBuilder.Append(ips[i]);
                        stringBuilder.Append(".");
                    }
                    for (int i = 0; i < 4 - left; i++)
                    {
                        stringBuilder.Append("*");
                        if (i < 3 - left)
                            stringBuilder.Append(".");
                    }
                    return stringBuilder.ToString();
                }
                return "*.*.*.*";
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// 通过Ping命令测试网络
        /// </summary>
        /// <param name="HostNameOrAddress">目标地址或域名</param>
        /// <returns></returns>
        public static PingReply NetTest(string HostNameOrAddress)
        {
            try
            {
                Ping pingSender = new Ping();
                //Ping 选项设置  
                PingOptions options = new PingOptions();
                options.DontFragment = true;
                //测试数据  
                string data = "test your network";
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                //设置超时时间  
                int timeout = 120;
                //调用同步 send 方法发送数据,将返回结果保存至PingReply实例  
                PingReply reply = pingSender.Send(HostNameOrAddress, timeout, buffer, options);
                return reply;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 获取公网IP
        /// </summary>
        /// <returns></returns>
        public static IpInfo GetWanIp(Encoding encoding = null)
        {
            string ip = "";
            try
            {
                WebClient MyWebClient = new WebClient();
                MyWebClient.Encoding = Encoding.UTF8;
                if (encoding != null)
                    MyWebClient.Encoding = encoding;
                MyWebClient.Credentials = CredentialCache.DefaultCredentials;//获取或设置用于向Internet资源的请求进行身份验证的网络凭据
                ip = MyWebClient.DownloadString("http://ip.chinaz.com/getip.aspx"); //从指定网站下载数据
                if (string.IsNullOrEmpty(ip)) return null;
                return ip.ToObject<IpInfo>();
            }
            catch
            {
                throw;
            }
        }
        public class IpInfo
        {
            public string ip { get; set; }
            public string address { get; set; }
        }
        /// <summary>
        /// 获取全部内网Ip
        /// </summary>
        /// <returns></returns>
        public static List<string> GetAllLanIp()
        {
            try
            {
                List<string> rtn = new List<string>();
                string hostName = Dns.GetHostName();
                IPAddress[] ipadrlist = Dns.GetHostAddresses(hostName);
                foreach (IPAddress ipa in ipadrlist)
                {
                    if (ipa.AddressFamily.Equals(AddressFamily.InterNetwork))
                        rtn.Add(ipa.ToString());
                }
                return rtn;
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// 获取第一个内网Ip
        /// </summary>
        /// <returns></returns>
        public static string GetLanIp()
        {
            try
            {
                string hostName = Dns.GetHostName();
                IPAddress[] ipadrlist = Dns.GetHostAddresses(hostName);
                foreach (IPAddress ipa in ipadrlist)
                {
                    if (ipa.AddressFamily.Equals(AddressFamily.InterNetwork))
                        return ipa.ToString();
                }
                return null;
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// WebClient 模拟POST
        /// string url = "http://www.baidu.com/";
        /// string result = string.Empty;
        /// string param = string.Format("WechatOpenID={0}&Content={1}", webchatOpenID, content);
        /// result = HttpPost(url, param);
        /// </summary>
        /// <param name="Url">目标网址</param>
        /// <param name="postDataStr">参数</param>
        /// <returns></returns>
        public static string PostClient(string Url, string postDataStr, Encoding encoding = null)
        {
            WebClient webClient = new WebClient();
            webClient.Encoding = Encoding.UTF8;
            if (encoding != null)
                webClient.Encoding = encoding;
            webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            return webClient.UploadString(Url, postDataStr);
        }
        public static string GetClient(string Url, Encoding encoding = null)
        {
            WebClient webClient = new WebClient();
            webClient.Encoding = Encoding.UTF8;
            if (encoding != null)
                webClient.Encoding = encoding;
            webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            return webClient.DownloadString(Url);
        }

        /// <summary>
        /// body是要传递的参数,格式"roleId=1&uid=2"
        /// post的cotentType填写:
        /// "application/x-www-form-urlencoded"
        /// soap填写:"text/xml; charset=utf-8"
        /// </summary>
        /// <param name="url">目标网址</param>
        /// <param name="postDataStr">是要传递的参数,格式"roleId=1&uid=2"</param>
        /// <param name="contentType">application/x-www-form-urlencoded</param>
        /// <returns></returns>
        public static string PostRequest(string url, string postDataStr, Encoding encoding = null)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/x-www-form-urlencoded";
            httpWebRequest.Method = "POST";
            httpWebRequest.Timeout = 30000;
            if (encoding == null)
                encoding = Encoding.UTF8;
            byte[] btBodys = encoding.GetBytes(postDataStr);
            httpWebRequest.ContentLength = btBodys.Length;
            httpWebRequest.GetRequestStream().Write(btBodys, 0, btBodys.Length);
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream());
            string responseContent = streamReader.ReadToEnd();
            httpWebResponse.Close();
            streamReader.Close();
            httpWebRequest.Abort();
            httpWebResponse.Close();
            return responseContent;
        }
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="userName">账号</param>
        /// <param name="password">密码</param>
        /// <param name="smtp">smtp服务器</param>
        /// <param name="sendTo">收件人列表</param>
        /// <param name="sendCC">抄送人列表</param>
        /// <param name="subject">主体</param>
        /// <param name="body">内容</param>
        /// <param name="attach">附件</param>
        public static void SendeMail(string userName, string password, string smtp, List<string> sendTo, List<string> sendCC, string subject, string body, List<string> attach)
        {
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Host = smtp;
            smtpClient.UseDefaultCredentials = true;
            smtpClient.Credentials = new NetworkCredential(userName, password);
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(userName);
            foreach (string addresses in sendTo)
            {
                mailMessage.To.Add(addresses);
            }
            foreach (string addresses2 in sendCC)
            {
                mailMessage.CC.Add(addresses2);
            }
            foreach (string addresses3 in attach)
            {
                if (File.Exists(addresses3))
                {
                    Attachment item = new Attachment(addresses3);
                    mailMessage.Attachments.Add(item);
                }
            }
            mailMessage.Subject = subject;
            mailMessage.Body = body;
            mailMessage.BodyEncoding = Encoding.UTF8;
            mailMessage.IsBodyHtml = true;
            mailMessage.Priority = MailPriority.High;
            try
            {
                smtpClient.Send(mailMessage);
                Console.WriteLine("发送成功");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="userName">账号</param>
        /// <param name="password">密码</param>
        /// <param name="smtp">smtp服务器</param>
        /// <param name="sendTo">收件人</param>
        /// <param name="subject">主题</param>
        /// <param name="body">内容</param>
        public static void SendeMail(string userName, string password, string smtp, string sendTo, string cc, string subject, string body)
        {
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Host = smtp;
            smtpClient.UseDefaultCredentials = true;
            smtpClient.Credentials = new NetworkCredential(userName, password);
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(userName);
            if (!string.IsNullOrEmpty(sendTo))
            {
                if (sendTo.Contains(";"))
                {
                    foreach (string item in sendTo.Split(';'))
                    {
                        mailMessage.To.Add(item);
                    }
                }
                else
                {
                    mailMessage.To.Add(sendTo);
                }
            }
            if (!string.IsNullOrEmpty(cc))
            {
                if (cc.Contains(";"))
                {
                    foreach (string item in cc.Split(';'))
                    {
                        mailMessage.CC.Add(item);
                    }
                }
                else
                {
                    mailMessage.CC.Add(cc);
                }
            }
            mailMessage.Subject = subject;
            mailMessage.Body = body;
            mailMessage.BodyEncoding = Encoding.UTF8;
            mailMessage.IsBodyHtml = true;
            mailMessage.Priority = MailPriority.High;
            try
            {
                smtpClient.Send(mailMessage);
                Console.WriteLine("发送成功");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}