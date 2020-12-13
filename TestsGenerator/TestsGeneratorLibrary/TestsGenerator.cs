using System;
using System.Threading.Tasks;

namespace TestsGeneratorLibrary
{
    public class TestsGenerator
    {
        private int _maxTaskCount;

        public TestsGenerator(int maxTasksCount)
        {
            _maxTaskCount = maxTasksCount;
        }

        public static async Task<string> GenerateTest(string file)
        {
            return null;
        }
    }
}
