using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using TestsGeneratorLibrary;

namespace TestsGeneratorConsole
{
    class Program
    {
        private static string _destinationFolder = "C:\\5 sem\\SPP\\Labs\\Lab_4\\TestClasses";
        private static int _maxTasksCount = 2;
        private static int _maxLoadedFilesCount = 2;
        private static int _maxStoredFilesCount = 2;
        private static List<string> _files = new List<string>()
        {
            "C:\\5 sem\\SPP\\Labs\\Lab_4\\Classes\\AssemblyInfo.cs",
            "C:\\5 sem\\SPP\\Labs\\Lab_4\\Classes\\BooleanGenerator.cs",
            "C:\\5 sem\\SPP\\Labs\\Lab_4\\Classes\\Browser.cs",
            "C:\\5 sem\\SPP\\Labs\\Lab_4\\Classes\\ByteGenerator.cs",
            "C:\\5 sem\\SPP\\Labs\\Lab_4\\Classes\\CharGenerator.cs",
            "C:\\5 sem\\SPP\\Labs\\Lab_4\\Classes\\Generator.cs",
        };

        static void Main(string[] args)
        {/*
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
            _maxTasksCount = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter max loaded files count: ");
            _maxLoadedFilesCount = Int32.Parse(Console.ReadLine());
            
            Console.WriteLine("Enter max stored files count: ");
            _maxStoredFilesCount = Int32.Parse(Console.ReadLine());

            // + check dir existing
            Console.WriteLine("Enter destination folder path: ");
            _destinationFolder = Console.ReadLine();
            */

            var loadBlock = new TransformBlock<string, string>(LoadText, new ExecutionDataflowBlockOptions() 
                                                                { MaxDegreeOfParallelism = _maxLoadedFilesCount });
            var generateBlock = new TransformBlock<string, TestClass>(TestsGenerator.GenerateTest, new ExecutionDataflowBlockOptions()
                                                                    { MaxDegreeOfParallelism = _maxTasksCount });
            var writeBlock = new ActionBlock<TestClass>(WriteFile, new ExecutionDataflowBlockOptions()
                                                           { MaxDegreeOfParallelism = _maxStoredFilesCount });

            loadBlock.LinkTo(generateBlock);
            generateBlock.LinkTo(writeBlock);
        }

        public static async Task<string> LoadText(string path)
        {
            using (StreamReader reader = File.OpenText(path))
            {
                return await reader.ReadToEndAsync();
            }
        }

        public static async Task WriteFile(TestClass test)
        {
            using (StreamWriter writer = File.CreateText(_destinationFolder + "\\" + test.Name))
            {
                await writer.WriteAsync(test.Text);
            }
        }
    }
}
