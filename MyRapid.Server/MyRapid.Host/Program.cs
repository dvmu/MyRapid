using MyRapid.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyRapid.Host
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            ServiceHost host = new ServiceHost(typeof(MainService));
            //服务启动
            host.Opened += delegate { Console.WriteLine("服务已启动，按任意键停止服务"); };
            host.Open();
            Console.ReadKey();
        }
    }
}
