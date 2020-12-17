/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using DevExpress.XtraCharts.Localization;
using MyRapid.Proxy;
using MyRapid.Proxy.MainService;
using MyRapid.SysEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MyRapid.GlobalLocalizer
{
    public class MyChartLocalizer : ChartLocalizer 
    {
        public override string GetLocalizedString(ChartStringId ID)
        {
            return BaseLocalizer.GetLocalizedString<ChartStringId>((int)ID, base.GetLocalizedString(ID), base.GetType().Name);
            //string enumName = Enum.GetName(typeof(ChartStringId), ID);
            //List<Sys_Globalization> sys_Globalizations = (List<Sys_Globalization>)Provider["Sys_Globalization"];
            //Sys_Globalization sys_Globalization = sys_Globalizations.Find(l => l.Globalization_Cultural == ((Sys_User)Provider["Sys_User"]).User_Cultural
            //                                 && l.Globalization_Partition.ToLower() == "devexpress"
            //                                 && l.Globalization_Localizer.ToLower() == base.GetType().Name.ToLower()
            //                                 && l.Globalization_Name.ToLower() == enumName.ToLower());
            //if (sys_Globalization != null)
            //{
            //    return sys_Globalization.Globalization_Nick;
            //}
            //List<MyParameter> myParameters = new List<MyParameter>();
            //myParameters.Add("@Globalization_Cultural", SqlDbType.Int, ((Sys_User)Provider["Sys_User"]).User_Cultural, null);
            //myParameters.Add("@Globalization_Partition", SqlDbType.NVarChar, "Devexpress", null);
            //myParameters.Add("@Globalization_Localizer", SqlDbType.NVarChar, base.GetType().Name, null);
            //myParameters.Add("@Globalization_Name", SqlDbType.NVarChar, enumName, null);
            //myParameters.Add("@Globalization_Nick", SqlDbType.NVarChar, base.GetLocalizedString(ID), null);
            //myParameters.Add("@Globalization_StringId", SqlDbType.Int, (int)ID, null);
            //BaseService.Open_Sys_WorkSet("Save_Sys_Globalization", myParameters);
            //return base.GetLocalizedString(ID);
        }
    }
}