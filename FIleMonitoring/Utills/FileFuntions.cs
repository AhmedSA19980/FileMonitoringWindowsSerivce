using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIleMonitoring.Utills
{
    public  class FileFuntions
    {
        public static string GenerateGUID()
        {
            Guid newID = Guid.NewGuid();

            return newID.ToString();


        }

        public static string ReplaceFileNameWithGUID(string SoruceFile)
        {

            string FileName = SoruceFile;
            FileInfo fi = new FileInfo(FileName);
            string extn = fi.Extension;

            return GenerateGUID() + extn;

        }

        public static bool CreateFolderIfDoesNotExist(string FolderPath)
        {

            
            if (!Directory.Exists(FolderPath))
            {
                try
                {
                   
                    Directory.CreateDirectory(FolderPath);
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error creating folder: " + ex.Message);
                    return false;
                }
            }

            return true;

        }
  
    }
}
