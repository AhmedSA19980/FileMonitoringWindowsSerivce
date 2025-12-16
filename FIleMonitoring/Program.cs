using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace FIleMonitoring
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
  


        static void Main()
        {
            if (Environment.UserInteractive) { 
             FileMonitoring f  =new FileMonitoring();
                f.StartOnConsole();
            }
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {

                new FileMonitoring()


            };
            ServiceBase.Run(ServicesToRun);
        }




    }
}
