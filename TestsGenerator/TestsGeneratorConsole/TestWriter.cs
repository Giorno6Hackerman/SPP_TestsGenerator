using System;
using System.Collections.Generic;
using System.Text;

namespace TestsGeneratorConsole
{
    public class TestWriter
    {
        private int _maxStoredFilesCount;

        public TestWriter(int maxStoredFilesCount)
        {
            _maxStoredFilesCount = maxStoredFilesCount;
        }
    }
}
