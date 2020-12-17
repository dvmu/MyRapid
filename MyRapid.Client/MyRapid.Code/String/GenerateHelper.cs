/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MyRapid.Code
{
    public static class GenerateHelper
    {
        public static string RandomString(int length)
        {
            try
            {
                StringBuilder rs = new StringBuilder();
                while (rs.Length < length)
                {
                    Guid guid = Guid.NewGuid(); 
                    rs.Append(guid.ToString());
                    rs = rs.Replace("{", "").Replace("}", "").Replace("-", "");
                }
                return rs.ToString().Substring(0, length);
            }
            catch
            {
                throw;
            }
        }
        public static int RandomInt()
        {
            try
            {
                Random random = new Random();
                return random.Next();
            }
            catch
            {
                throw;
            }
        }
        public static int RandomInt(int maxValue)
        {
            try
            {
                Random random = new Random();
                return random.Next(maxValue);
            }
            catch
            {
                throw;
            }
        }
        public static int RandomInt(int minValue, int maxValue)
        {
            try
            {
                Random random = new Random();
                return random.Next(minValue, maxValue);
            }
            catch
            {
                throw;
            }
        }
        public static double RandomDouble()
        {
            try
            {
                Random random = new Random();
                return random.NextDouble();
            }
            catch
            {
                throw;
            }
        }
        public static double RandomDouble(double maxValue)
        {
            try
            {
                Random random = new Random();
                return random.NextDouble() * maxValue;
            }
            catch
            {
                throw;
            }
        }
        public static double RandomDouble(double minValue, double maxValue)
        {
            try
            {
                Random random = new Random();
                return random.NextDouble() * (maxValue - minValue) + minValue;
            }
            catch
            {
                throw;
            }
        }
        public static DataTable RandomTable()
        {
            try
            {
                DataTable dt = new DataTable();
                for (int i = 0; i < 10; i++)
                {
                    dt.Columns.Add("Field" + i.ToString());
                }
                for (int i = 0; i < 10; i++)
                {
                    DataRow dr = dt.NewRow();
                    for (int j = 0; j < 10; j++)
                    {
                        dr[j] = "r" + i.ToString() + "c" + j.ToString();
                    }
                    dt.Rows.Add(dr);
                }
                return dt;
            }
            catch
            {
                throw;
            }
        }
    }
}