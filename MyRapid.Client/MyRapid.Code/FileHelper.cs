/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using MyRapid.SysEntity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
namespace MyRapid.Code
{
    public static class FileHelper
    {
        /// <summary>
        /// 识别：txt,aspx,asp,sql,xml,htm,html,js
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns></returns>
        public static bool IsTxt(string filePath)
        {
            string ext = Path.GetExtension(filePath);
            string typ = ".txt.aspx.asp.sql.xml.htm.html.js";
            return typ.Contains(ext);
        }
        public static List<string> FindFiles(string dirPath, string search = "*.*")
        {
            List<string> files = new List<string>();
            if (Directory.Exists(dirPath))
            {
                files.AddRange(Directory.GetFiles(dirPath, search));
                foreach (string dir in Directory.GetDirectories(dirPath))
                {
                    files.AddRange(FindFiles(dir, search));
                }
            }
            return files;
        }
        public static void DepartFiles(string dirPath, int parts = 10)
        {
            List<string> fs = FindFiles(dirPath);
            while (fs.Count > 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    string path = dirPath + i.ToStringEx();
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    if (fs.Count > 0)
                    {
                        File.Copy(fs[0], path + @"\" + Path.GetFileName(fs[0]), true);
                        fs.RemoveAt(0);
                    }
                }
            }
        }
        public static void UploadFile(string path, string url)
        {
            try
            {
                Sys_File f = new Sys_File();
                f.FileId = Guid.NewGuid().ToString();
                f.FileByte = File.ReadAllBytes(path);
                string s = f.ToJson();
                s = GZipHelper.Compress(s);
                string sUrl = string.Format("{0}/ApiService.svc/SetFile?file={1}", url, s);
                string result = WebHelper.GetClient(sUrl);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private class ApiResult
        {
            public bool Succeed { get; set; }
            public string Data { get; set; }
            public string Message { get; set; }
        }
        public static void DownLoadFile(string path, string url, string fileName)
        {
            try
            {
                string sUrl = string.Format("{0}/ApiService.svc/GetFile?fileName={1}", url, fileName);
                string sjs = WebHelper.GetClient(sUrl);
                ApiResult ar = sjs.ToObject<ApiResult>();
                List<Sys_File> fds = ar.Data.ToObject<List<Sys_File>>();
                if (fds != null && fds.Count > 0)
                    File.WriteAllBytes(path, fds[0].FileByte);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}