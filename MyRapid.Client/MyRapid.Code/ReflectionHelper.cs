/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using Microsoft.CSharp;
using Microsoft.VisualBasic;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
namespace MyRapid.Code
{
    public static class ReflectionHelper
    {
        /// <summary>
        /// 判断控件是否已经绑定事件
        /// </summary>
        /// <param name="control"></param>
        /// <param name="EventName"></param>
        /// <returns></returns>
        public static bool IsBindEvent(object control, string EventName)
        {
            try
            {
                BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy;
                Type typeFromHandle = typeof(Control);
                FieldInfo field = typeFromHandle.GetField("Event" + EventName, bindingAttr);
                PropertyInfo property = control.GetType().GetProperty("Events", bindingAttr);
                EventHandlerList eventHandlerList = property.GetValue(control, null) as EventHandlerList;
                if (eventHandlerList != null)
                {
                    object obj = RuntimeHelpers.GetObjectValue(field.GetValue(control));
                    Delegate @delegate = eventHandlerList[obj];
                    if (@delegate != null && @delegate.GetInvocationList().Count<Delegate>() > 0)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    throw ex.InnerException;
                }
                throw ex;
            }
        }
        /// <summary>
        /// 根据属性名读取属性值
        /// </summary>
        /// <param name="obj">待检查对象</param>
        /// <param name="PropertyName">PropertyName</param>
        /// <returns></returns>
        public static bool SetProperty(object obj, string PropertyName, object value)
        {
            try
            {
                PropertyInfo[] propertyInfos = obj.GetType().GetProperties();
                foreach (PropertyInfo propertyInfo in propertyInfos)
                {
                    if (propertyInfo.Name.Equals(PropertyName))
                    {
                        propertyInfo.SetValue(obj, value, null);
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    throw ex.InnerException;
                }
                throw ex;
            }
        }
        /// <summary>
        /// 根据属性名设置属性值
        /// </summary>
        /// <param name="obj">待检查对象</param>
        /// <param name="PropertyName">PropertyName</param>
        /// <returns></returns>
        public static object GetProperty(object obj, string PropertyName)
        {
            try
            {
                PropertyInfo[] propertyInfos = obj.GetType().GetProperties();
                foreach (PropertyInfo propertyInfo in propertyInfos)
                {
                    if (propertyInfo.Name.Equals(PropertyName))
                    {
                        return propertyInfo.GetValue(obj, null);
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    throw ex.InnerException;
                }
                throw ex;
            }
        }
        /// <summary>
        /// 复制对象
        /// </summary>
        /// <typeparam name="TSource">源对象</typeparam>
        /// <typeparam name="TTarget">目标</typeparam>
        /// <param name="tIn"></param>
        /// <returns></returns>
        public static TTarget CopyProperty<TSource, TTarget>(TSource tIn)
        {
            //如果是字符串或值类型则直接返回
            //if (tIn is string || tIn.GetType().IsValueType) return null;
            //TTarget retval = Activator.CreateInstance<TTarget>();
            //FieldInfo[] fields = tIn.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            //foreach (FieldInfo field in fields)
            //{
            //    try { field.SetValue(retval, DeepCopyByReflect(field.GetValue(tIn))); }
            //    catch { }
            //}
            //return retval;
            TTarget tOut = Activator.CreateInstance<TTarget>();
            var tInType = tIn.GetType();
            foreach (var itemOut in tOut.GetType().GetProperties())
            {
                var itemIn = tInType.GetProperty(itemOut.Name);
                if (itemIn != null && itemOut.CanWrite && itemOut.PropertyType == itemIn.PropertyType)
                {
                    try
                    {
                        object obj = itemIn.GetValue(tIn, null);
                        itemOut.SetValue(tOut, obj, null);
                    }
                    catch //(Exception ex)
                    {
                        //Console.WriteLine(ex.ToJson());
                    }
                }
            }
            return tOut;
        }

        /// <summary>
        /// 检查是否有名为PropertyName的属性
        /// </summary>
        /// <param name="obj">待检查对象</param>
        /// <param name="PropertyName">PropertyName</param>
        /// <returns></returns>
        public static bool ChkProperty(object obj, string PropertyName)
        {
            try
            {
                PropertyInfo[] propertyInfos = obj.GetType().GetProperties();
                foreach (PropertyInfo propertyInfo in propertyInfos)
                {
                    if (propertyInfo.Name.Equals(PropertyName))
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    throw ex.InnerException;
                }
                throw ex;
            }
        }
        /// <summary>
        /// 检查是否有名为EventName的属性
        /// </summary>
        /// <param name="obj">待检查对象</param>
        /// <param name="EventName"></param>
        /// <returns></returns>
        public static bool ChkEvent(object obj, string EventName)
        {
            try
            {
                EventInfo[] eventInfos = obj.GetType().GetEvents();
                foreach (EventInfo eventInfo in eventInfos)
                {
                    if (eventInfo.Name.Equals(EventName))
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    throw ex.InnerException;
                }
                throw ex;
            }
        }
        /// <summary>
        /// 加载方法/函数
        /// </summary>
        /// <param name="obj">实例</param>
        /// <param name="methodName">要调用的方法/函数名称</param>
        /// <param name="paramter">函数需要使用的参数数组</param>
        /// <returns></returns>
        public static object LoadMethod(object obj, string methodName, object[] paramter)
        {
            try
            {
                Type[] pts = new Type[paramter.Length];
                for (int i = 0; i < paramter.Length; i++)
                {
                    pts[i] = paramter[i].GetType();
                }
                Type type = obj.GetType();
                MethodInfo methodInfo = type.GetMethod(methodName, pts);
                return methodInfo.Invoke(obj, paramter);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    throw ex.InnerException;
                }
                throw ex;
            }
        }
        /// <summary>
        /// 加载方法/函数
        /// </summary>
        /// <param name="asmFile">待反射文件的路径(相对路径或绝对路径)</param>
        /// <param name="asmClass">要反射的类的全名(包括命名空间)</param>
        /// <param name="methodName">要调用的方法/函数名称</param>
        /// <param name="paramter">函数需要使用的参数数组</param>
        /// <returns></returns>
        public static object LoadMethod(string asmFile, string asmClass, string methodName, object[] paramter)
        {
            try
            {
                //if (!File.Exists(asmFile)) return null;
                //读取为Byte[]防止出现文件占用
                //byte[] fileData = System.IO.File.ReadAllBytes(asmFile);
                //加载程序集（EXE 或 DLL） 
                System.Reflection.Assembly assembly = System.Reflection.Assembly.LoadFrom(asmFile);
                //调用方法
                Type type = assembly.GetType(asmClass);
                object obj = assembly.CreateInstance(asmClass);
                System.Reflection.MethodInfo methodInfo = type.GetMethod(methodName);
                //所调用方法需要用到的参数
                //object[] paramter = new object[1];
                //paramter[0] = "test";
                return methodInfo.Invoke(obj, paramter);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    throw ex.InnerException;
                }
                throw ex;
            }
        }
        /// <summary>
        /// 反射取得窗体对象实例
        /// </summary>
        /// <param name="asmFile">待反射文件的路径(相对路径或绝对路径)</param>
        /// <param name="asmClass">要反射的类的全名(包括命名空间)</param>
        /// <returns></returns>
        public static object LoadForm(string asmFile, string asmClass)
        {
            try
            {
                //if (!File.Exists(asmFile)) return null;
                //读取为Byte[]防止出现文件占用
                //byte[] fileData = System.IO.File.ReadAllBytes(asmFile);
                //加载程序集（EXE 或 DLL）
                System.Reflection.Assembly assembly = System.Reflection.Assembly.LoadFrom(asmFile);
                //创建类的实例
                object form = assembly.CreateInstance(asmClass);
                return form;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    throw ex.InnerException;
                }
                throw ex;
            }
        }
        public static object ExecuteFromFile(string[] refList, string fileName, string className, string methodName, object[] paramter, bool isCSharp = true, bool debug = false)
        {
            try
            {
                refList = refList.Distinct<string>().ToArray();
                CompilerParameters compilerParameters = new CompilerParameters();
                if (refList != null)
                {
                    compilerParameters.ReferencedAssemblies.AddRange(refList);
                }
                compilerParameters.IncludeDebugInformation = debug;
                string Output = className + ".dll";
                compilerParameters.OutputAssembly = Output;
                //if (debug)
                //{
                compilerParameters.GenerateInMemory = false;
                //}
                //else
                //{
                //    compilerParameters.GenerateInMemory = true;
                //}
                CompilerResults cr;
                if (isCSharp)
                {
                    CSharpCodeProvider ccp = new CSharpCodeProvider();
                    cr = ccp.CompileAssemblyFromFile(compilerParameters, new string[] { fileName });
                    ccp.Dispose();
                }
                else
                {
                    VBCodeProvider vcp = new VBCodeProvider();
                    cr = vcp.CompileAssemblyFromFile(compilerParameters, new string[] { fileName });
                    vcp.Dispose();
                }
                if (!cr.Errors.HasErrors)
                {
                    //AppDomainSetup setup = new AppDomainSetup();
                    //setup.ApplicationName = "ApplicationLoader";
                    //setup.ApplicationBase = AppDomain.CurrentDomain.BaseDirectory;
                    //setup.PrivateBinPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "private");
                    //setup.CachePath = setup.ApplicationBase;
                    //setup.ShadowCopyFiles = "true";
                    //setup.ShadowCopyDirectories = setup.ApplicationBase;
                    //AppDomain appDomain = AppDomain.CreateDomain(className, null, setup);
                    //Assembly assembly = cr.CompiledAssembly;
                    //Type type = assembly.GetType(className);
                    //object obj = appDomain.CreateInstanceFromAndUnwrap(Output, className);
                    //MethodInfo methodInfo = type.GetMethod(methodName);
                    //object rtn = methodInfo.Invoke(obj, paramter);
                    //AppDomain.Unload(appDomain);
                    //return rtn;
                    Assembly assembly = cr.CompiledAssembly;
                    //调用方法
                    Type type = assembly.GetType(className);
                    object obj = assembly.CreateInstance(className);
                    MethodInfo methodInfo = type.GetMethod(methodName);
                    //所调用方法需要用到的参数
                    //object[] paramter = new object[1];
                    //paramter[0] = "test";
                    return methodInfo.Invoke(obj, paramter);
                }
                else
                {
                    StringBuilder error = new StringBuilder();
                    foreach (CompilerError compilerError in cr.Errors)
                    {
                        error.Append(compilerError.ErrorNumber);
                        error.Append("\t");
                        error.Append(compilerError.Line);
                        error.Append("\t");
                        error.Append(compilerError.ErrorText);
                        error.Append("\r\n");
                    }
                    throw new Exception(error.ToString());
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    throw ex.InnerException;
                }
                throw ex;
            }
        }
        public static object ExecuteFromCode(string[] refList, string sourceCode, string className, string methodName, object[] paramter, bool isCSharp = true, bool debug = false)
        {
            try
            {
                string fileName = className;
                if (isCSharp)
                    fileName += ".cs";
                else
                    fileName += ".vb";
                File.WriteAllText(fileName, sourceCode);
                return ExecuteFromFile(refList, fileName, className, methodName, paramter, isCSharp, debug);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    throw ex.InnerException;
                }
                throw ex;
            }
        }
        public static object ExecuteScript(string script)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("using System;");
            sb.Append(Environment.NewLine);
            sb.Append("namespace DynamicScript");
            sb.Append(Environment.NewLine);
            sb.Append("{");
            sb.Append(Environment.NewLine);
            sb.Append("    public class HelloWorld");
            sb.Append(Environment.NewLine);
            sb.Append("    {");
            sb.Append(Environment.NewLine);
            sb.Append("        public string OutPut()");
            sb.Append(Environment.NewLine);
            sb.Append("        {");
            sb.Append(Environment.NewLine);
            sb.Append(script);
            sb.Append(Environment.NewLine);
            sb.Append("        }");
            sb.Append(Environment.NewLine);
            sb.Append("    }");
            sb.Append(Environment.NewLine);
            sb.Append("}");
            string code = sb.ToString();
            // 1.CSharpCodePrivoder
            CSharpCodeProvider objCSharpCodePrivoder = new CSharpCodeProvider();
            // 3.CompilerParameters
            CompilerParameters objCompilerParameters = new CompilerParameters();
            objCompilerParameters.ReferencedAssemblies.Add("System.dll");
            objCompilerParameters.GenerateExecutable = false;
            objCompilerParameters.GenerateInMemory = true;
            // 3.CompilerResults
            CompilerResults cr = objCSharpCodePrivoder.CompileAssemblyFromSource(objCompilerParameters, code);
            if (cr.Errors.HasErrors)
            {
                //Console.WriteLine("编译错误：");
                //foreach (CompilerError err in cr.Errors)
                //{
                //    Console.WriteLine(err.ErrorText);
                //}
                return "HasErrors";
            }
            else
            {
                // 通过反射，调用HelloWorld的实例
                Assembly objAssembly = cr.CompiledAssembly;
                object objHelloWorld = objAssembly.CreateInstance("DynamicScript.HelloWorld");
                MethodInfo objMI = objHelloWorld.GetType().GetMethod("OutPut");
                return objMI.Invoke(objHelloWorld, null);
            }
        }
    }
}