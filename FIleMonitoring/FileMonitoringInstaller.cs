using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace FIleMonitoring
{
    [RunInstaller(true)]
    public partial class FileMonitoringInstaller : System.Configuration.Install.Installer
    {
        private ServiceProcessInstaller serviceProcessInstaller;
        private ServiceInstaller serviceInstaller;
        public FileMonitoringInstaller()
        {
            InitializeComponent();

            // Configure the Service Process Installer
            serviceProcessInstaller = new ServiceProcessInstaller
            {
                Account = ServiceAccount.LocalService // Adjust as needed (e.g., NetworkService, LocalService)
            };

            // Configure the Service Installer
            serviceInstaller = new ServiceInstaller
            {
                ServiceName = "FileMonitoring", // Must match the ServiceName in your ServiceBase class
                DisplayName = "File Monitoring Service",
                StartType = ServiceStartMode.Manual // Or Automatic, depending on requirements
            };
            serviceInstaller.ServicesDependedOn = new string[]
           {
                "RpcSs",
                "EventLog",
                "LanmanWorkstation"// allow network (shares) path
           };

            // Add installers to the installer collection
            Installers.Add(serviceProcessInstaller);
            Installers.Add(serviceInstaller);
           

        }
    }
}
