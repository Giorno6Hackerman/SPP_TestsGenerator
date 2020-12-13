using System;
using System.Collections.Generic;

namespace TestsGeneratorConsole
{
    class Program
    {
        private static List<string> _files = new List<string>();
        private static string _destinationFolder;
        private static int _maxTasksCount;
        private static int _maxLoadedFilesCount;
        private static int _maxStoredFilesCount;

        static void Main(string[] args)
        {
            Console.WriteLine("Enter file's path(or 0 to finish): ");
            string path;
            path = Console.ReadLine();
            while (path != "0")
            {
                _files.Add(path);
                path = Console.ReadLine();
            }

            Console.WriteLine("Enter max tasks count: ");
            _maxTasksCount = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter max loaded files count: ");
            _maxLoadedFilesCount = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter max stored files count: ");
            _maxStoredFilesCount = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter destination folder path: ");
            _destinationFolder = Console.ReadLine();

            // call loader(_files, _maxLoadedFilesCount)
            // call generator(fromLoader, _maxTasksCount)
            // call writer(fromgenerator, _destinationFolder, _maxStoredFilesCount)
        }
    }
}
