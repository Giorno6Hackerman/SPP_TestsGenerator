using System;
using System.Collections.Generic;
using System.Text;

namespace TestsGeneratorConsole
{
    public class TextLoader
    {
        private int _maxLoadedFilesCount;

        public TextLoader(int maxLoadedFilesCount)
        {
            _maxLoadedFilesCount = maxLoadedFilesCount;
        }
    }
}
