using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestsGeneratorConsole
{
    public class TestWriter
    {
        private int _maxStoredFilesCount;
        private string _destFolder;

        public TestWriter(int maxStoredFilesCount, string destFolder)
        {
            _maxStoredFilesCount = maxStoredFilesCount;
            _destFolder = destFolder;
        }

        public async Task WriteFile()
        { 
        
        }
    }
}
