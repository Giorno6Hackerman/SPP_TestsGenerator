using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using TestsGeneratorLibrary;

namespace TestsGeneratorConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> _files = new List<string>();
            Console.WriteLine("Enter file's path(or 0 to finish): ");
            // + check file existing
            string path;
            path = Console.ReadLine();
            while (path != "0")
            {
                _files.Add(path);
                path = Console.ReadLine();
            }

            Console.WriteLine("Enter max tasks count: ");
            int _maxTasksCount = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter max loaded files count: ");
            int _maxLoadedFilesCount = Int32.Parse(Console.ReadLine());
            double x = 1 + 1;
            Console.WriteLine("Enter max stored files count: ");
            int _maxStoredFilesCount = Int32.Parse(Console.ReadLine());

            // + check dir existing
            Console.WriteLine("Enter destination folder path: ");
            string _destinationFolder = Console.ReadLine();

            // call loader(_files, _maxLoadedFilesCount)
            // 
            // call generator(fromLoader, _maxTasksCount)
            // call writer(fromgenerator, _destinationFolder, _maxStoredFilesCount)
        }

        public async Task<string> LoadText(string path)
        {
            using (StreamReader reader = File.OpenText(path))
            {
                return await reader.ReadToEndAsync();
            }
        }

        public async Task WriteFile()
        {
            // await WriteAsync
        }
    }
}
