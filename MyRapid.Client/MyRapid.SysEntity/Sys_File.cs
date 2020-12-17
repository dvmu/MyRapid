/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace MyRapid.SysEntity
{
    public class Sys_File
    {
        public string FileId { get; set; }
        public string FileName { get; set; }
        public DateTime FileDate { get; set; }
        public byte[] FileByte { get; set; }
        public string FilePath { get; set; }
        public string FileFullPath { get; set; }
        public string FileType { get; set; }
    }
}