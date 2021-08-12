using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderMonitor
{
    class Program
    {
        static void Main(string[] args)
        {
            string rootPath = @"C:\Users\morten.olsen\Documents\Morten\Heartbeat";
            string [] dirs = Directory.GetDirectories(rootPath);
       

          string[] files = Directory.GetFiles(rootPath);
            //var size = new DirectoryInfo(rootPath).GetDirectorySize();
            long size = 0;
            DirectoryInfo dir = new DirectoryInfo(rootPath);
            Console.WriteLine("Test :"+GetDirectorySize(@"C:\Users\morten.olsen\Documents\Morten"));
            foreach (FileInfo fi in dir.GetFiles(" *.*", SearchOption.AllDirectories))
            {
                size += fi.Length;
            }
            Console.WriteLine(size);

            foreach (string file in files)
            {
                Console.WriteLine(file);
            }
          
            /*foreach (var dir in dirs)
            {
                Console.WriteLine(dir);

            }*/


            Console.ReadLine();
        }
        static long GetDirectorySize(string p)
        {
            // 1.
            // Get array of all file names.
            string[] a = Directory.GetFiles(p, "*.*");

            // 2.
            // Calculate total bytes of all files in a loop.
            long b = 0;
            foreach (string name in a)
            {
                // 3.
                // Use FileInfo to get length of each file.
                FileInfo info = new FileInfo(name);
                b += info.Length;
            }
            // 4.
            // Return total size
            return b;
        }
    }




}
