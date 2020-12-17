/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using System;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("ScintillaNET")]
[assembly: AssemblyDescription("Source Editing Component")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Jacob Slusser")]
[assembly: AssemblyProduct("ScintillaNET")]
[assembly: AssemblyCopyright("Copyright (c) 2018, Jacob Slusser. All rights reserved.")]
[assembly: AssemblyTrademark("The MIT License (MIT)")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("f8ac48e7-9378-482d-8c7f-92c8408dd4f2")]

// http://stackoverflow.com/a/65062
// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("6.12.24.10")]
[assembly: AssemblyFileVersion("6.12.24.10")]
[assembly: AssemblyInformationalVersion("18.1130.6909")]
[assembly: NeutralResourcesLanguageAttribute("en-US")]

#if (DEBUG)
// For my own personal testing of internal members
[assembly: InternalsVisibleToAttribute("ScintillaNET.Test")]
#endif