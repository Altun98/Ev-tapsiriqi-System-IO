using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Controller
{
    public static class Controllers
    {
        public static bool FolderController(string path)
        {
            if (!Directory.Exists(path)) { return false; }
            else
            {
                Console.WriteLine("folder movcuddur");
                return true;
            }
            //    Directory.CreateDirectory(path);
            //else
            //    
        }
        public static void FolderCreate(string path)
        {
            Directory.CreateDirectory(path);
        }
        public static bool FileController(string path)
        {

            if (!File.Exists(path))
            {
                return false;
            }
            else
            {
                Console.WriteLine("fayl sistemde movcuddur");
                return true;
            }
        }
        public static void FileCreate(string path)
        {

            File.Create(path);
        }

    }
}
