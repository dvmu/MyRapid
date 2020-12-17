/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
namespace MyRapid.Launcher
{
    public partial class MyWait : Form
    {
        Process process;
        string TargetName = "";
        string ImagePath = "";
        string FormName = "主窗体";
        string urlPath = "";
        int WaitSecond = 30;
        Stopwatch sw = new Stopwatch();

        public MyWait()
        {
            sw.Restart();
            InitializeComponent();
            //用参数把4个变量传入
            //分别为
            //1 ProcessName 程序路径
            //2 ImagePath 动画路径
            //3 ScriptName 预更新脚本
            //4 FormName 启动程序的标识,用于判断程序是否加在完毕
            TargetName = GetVal("exePath");
            ImagePath = GetVal("imgPath");
            FormName = GetVal("exeTitle");

            MoveHandle(label1);
            MoveHandle(this);
            MoveHandle(progressBar1);
            if (File.Exists("tips.txt"))
            {
                tips = File.ReadAllLines("tips.txt");
            }
        }

        private void UpdateFile()
        {
            try
            {

                DateTime ver = DateTime.Parse(GetVal("version"));
                WebClient wc = new WebClient();
                wc.Encoding = Encoding.UTF8;
                label1.Text = "正在检查更新...";
                string updateFile = "update.txt";
                urlPath = GetVal("urlPath");
                wc.DownloadFile(urlPath, updateFile);
                if (!File.Exists(updateFile)) return;
                string[] verString = File.ReadAllLines(updateFile);
                if (verString.Length == 0) return;
                if (DateTime.Parse(verString[0]) <= ver) return;

                string fName = Path.GetFileNameWithoutExtension(TargetName);
                fName = Path.GetFileName(TargetName);
                var prcList = Process.GetProcesses().Where(pr => pr.ProcessName == Path.GetFileNameWithoutExtension(TargetName) || pr.ProcessName == Path.GetFileName(TargetName));
                if (prcList.Count() > 0)
                {
                    label1.Text = "主程序运行中，无法更新...";
                    return;
                }

                progressBar1.Style = ProgressBarStyle.Continuous;
                progressBar1.Maximum = verString.Length;
                progressBar1.Value = 0;
                foreach (string sf in verString)
                {
                    //Tips
                    if (tips != null && tips.Length > 0 && sw.Elapsed.TotalSeconds % 5 == 1)
                    {
                        int i = DateTime.Now.Millisecond % (tips.Length - 1);
                        label3.Text = string.Format(tip, tips[i]);
                        this.Refresh();
                    }

                    if (progressBar1.Value < verString.Length)
                        progressBar1.Value += 1;
                    if (!sf.Contains("|")) continue;
                    string[] ups = sf.Split('|');

                    if (DateTime.Parse(ups[0]) <= ver) continue;


                    //如果目录不存在这创建
                    string fDir = Path.GetDirectoryName(ups[1]);
                    if (!string.IsNullOrEmpty(fDir) && !Directory.Exists(fDir))
                    {
                        Directory.CreateDirectory(fDir);
                    }
                    //下载文件
                    label1.Text = ups[1];
                    this.Refresh();
                    wc.DownloadFile(ups[2], ups[1]);
                }

                SetVal("version", DateTime.Now.ToString());

                label1.Text = "更新结束：正在启动主程序...";
                progressBar1.Style = ProgressBarStyle.Marquee;
            }
            catch (Exception ex)
            {
                label1.Text += "更新失败，请重试或联系管理员协助处理：" + ex.Message;
            }
        }

        private void StartMain()
        {
            //执行预更新脚本
            if (File.Exists("update.vbs"))
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "wscript.exe";
                startInfo.Arguments = "update.vbs";
                Process script = Process.Start(startInfo);
                //script.WaitForExit();
            }

            if (File.Exists("update.bat"))
            {
                Process script = Process.Start("update.bat");
                //script.WaitForExit();
            }



            if (File.Exists(TargetName))
            {
                //启动程序
                ProcessStartInfo processStartInfo = new ProcessStartInfo();
                processStartInfo.FileName = TargetName;
                processStartInfo.WorkingDirectory = Path.GetDirectoryName(TargetName);
                process = Process.Start(processStartInfo);
            }
            else
            {
                Environment.Exit(0);
            }

            if (File.Exists(ImagePath))
            {
                //加载动画
                Image image = Image.FromFile(ImagePath);
                this.BackgroundImage = image;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //这里是用于判断结束 分两种  超时  或  已完成
            if (sw.Elapsed.TotalSeconds > WaitSecond)
                Environment.Exit(0);
            if (process == null)
                Environment.Exit(0);
            if (process.HasExited)
                Environment.Exit(0);
            process.Refresh();
            if (process.MainWindowTitle.Equals(FormName))
                Environment.Exit(0);



            //Console.WriteLine(process.MainWindowTitle);
            //Console.WriteLine(sw.Elapsed.TotalMilliseconds);
        }

        private void MyWait_Shown(object sender, EventArgs e)
        {
            this.Refresh();
            clearDir(Application.StartupPath);
            UpdateFile();
            if (File.Exists("update.txt"))
                File.Delete("update.txt");
            sw.Restart();
            timer1.Enabled = true;
            StartMain();
        }

        #region Tips
        string[] tips;
        string tip = "小贴士:{0}";

        #endregion

        #region Function

        public string GetVal(string key)
        {
            try
            {
                return ConfigurationManager.AppSettings.Get(key);
            }
            catch
            {
                throw;
            }
        }

        public void SetVal(string key, string value)
        {
            try
            {
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                configuration.AppSettings.Settings[key].Value = value;
                configuration.Save(ConfigurationSaveMode.Modified);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 为控件添加移动功能
        /// </summary>
        /// <param name="ctrl">鼠标按下的控件</param>
        /// <param name="who">移动的控件(若不存在则为控件自己) 
        /// 1:控件所在窗体; 
        /// 2:控件的父级; 
        /// 3:控件自己. </param>
        public void MoveHandle(Control ctrl, int who = 1)
        {
            try
            {
                Control mCtrl;//= ctrl.FindForm();
                switch (who)
                {
                    case 1:
                        mCtrl = ctrl.FindForm();
                        break;
                    case 2:
                        mCtrl = ctrl.Parent;
                        break;
                    case 3:
                        mCtrl = ctrl;
                        break;
                    default:
                        mCtrl = ctrl.FindForm();
                        break;
                }
                if (mCtrl == null)
                {
                    mCtrl = ctrl;
                }

                Point sourcePoint = new Point(0, 0);
                bool isMove = false;
                ctrl.MouseDown += delegate (object sender, MouseEventArgs e)
                {
                    sourcePoint = e.Location;
                    isMove = true;
                };
                ctrl.MouseMove += delegate (object sender, MouseEventArgs e)
                {
                    if (isMove)
                        mCtrl.Location = new Point(mCtrl.Location.X + e.X - sourcePoint.X, mCtrl.Location.Y + e.Y - sourcePoint.Y);
                };
                ctrl.MouseUp += delegate (object sender, MouseEventArgs e)
                {
                    isMove = false;
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region 清理同名文件保留最新文件

        //防止重复文件无法覆盖
        Dictionary<string, DateTime> dic = new Dictionary<string, DateTime>();
        Dictionary<string, string> lst = new Dictionary<string, string>();
        private void clearDir(string dir)
        {
            foreach (var item in Directory.GetFiles(dir))
            {
                FileInfo fileInfo = new FileInfo(item);

                Console.WriteLine(fileInfo.FullName);
                Console.WriteLine(fileInfo.LastWriteTime);
                //存在旧文件删除旧文件保留新的
                if (dic.ContainsKey(fileInfo.Name))
                {
                    if (dic[fileInfo.Name] > fileInfo.LastWriteTime)
                    {
                        File.Delete(fileInfo.FullName);
                    }
                    else
                    {
                        File.Delete(lst[fileInfo.Name]);
                        dic[fileInfo.Name] = fileInfo.LastWriteTime;
                        lst[fileInfo.Name] = fileInfo.FullName;
                    }
                }
                else
                {
                    dic[fileInfo.Name] = fileInfo.LastWriteTime;
                    lst[fileInfo.Name] = fileInfo.FullName;
                }

            }

            foreach (var item in Directory.GetDirectories(dir))
            {
                clearDir(item);
            }

        }
        #endregion
    }




}