using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.ServiceProcess;

using FIleMonitoring.Utills;

namespace FIleMonitoring
{
    public partial class FileMonitoring : ServiceBase
    {
        private FileSystemWatcher FileWatcher;
        private string destinationPath;
        private string sourcePath; 
        private string LogFolder;
      
        public FileMonitoring()
        {
           
            InitializeComponent();
            destinationPath = ConfigurationManager.AppSettings["DestinationFolder"];
            sourcePath = ConfigurationManager.AppSettings["SourceFolder"];
            LogFolder = ConfigurationManager.AppSettings["LogFolder"];


            FileFuntions.CreateFolderIfDoesNotExist(LogFolder);
            FileFuntions.CreateFolderIfDoesNotExist(destinationPath);
            FileFuntions.CreateFolderIfDoesNotExist(sourcePath);


        }

        protected override void OnStart(string[] args)
        {
          
         
            Log("Service Started !");
            FileWatcher = new FileSystemWatcher
            {
                Path = sourcePath,
                Filter = "*.*",
                EnableRaisingEvents = true,
                IncludeSubdirectories = false
            };

            FileWatcher.Created += OnFileCreated;
            // Console.WriteLine($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] Service Started !");


        }

        protected override void OnStop()
        {
            FileWatcher.Dispose();
            FileWatcher.EnableRaisingEvents = false;
            
            Log("Service Stopped !");
            Console.WriteLine($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] Service start !");

        }

       
        void Log(string msg)
        {
            string LogPath = Path.Combine(LogFolder, "LogFile.txt");
            string dateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //Console.WriteLine($"[{dateTime}] {msg}");
            File.AppendAllText(LogPath , $"[{dateTime}] {msg}\n");
            if (Environment.UserInteractive)
            {
                Console.WriteLine($"{LogPath} , ${dateTime} {msg}");
            }
        }
       
       
          void OnFileCreated(object sender, FileSystemEventArgs e)
          {
           

            string sourceFile = e.FullPath;
            string destFile = Path.Combine(destinationPath, FIleMonitoring.Utills.FileFuntions.ReplaceFileNameWithGUID(e.Name));


           
             try
             {
                    File.Move(sourceFile, destFile);
                    Log($"File Detected -> {sourceFile}");
                    Log($"File Moved {sourceFile} - > {destFile}");
                    Console.WriteLine($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] File Detected -> {sourceFile}");
                    Console.WriteLine( $"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] File Moved {sourceFile} - > {destFile}");
             }
             catch (Exception ex) {
                    Log($"ERROR moving file '{sourceFile}': {ex.Message}");
             }

          }
      
     
        public void StartOnConsole()
        {
            OnStart(null);
            Console.WriteLine("server start on console ");
            Console.WriteLine();    
            OnStop();
            Console.ReadKey();
        }

      
    }
}
