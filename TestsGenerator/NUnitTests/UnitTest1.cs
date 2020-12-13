using NUnit.Framework;
using System.IO;
using System.Threading.Tasks;
using TestsGeneratorLibrary;

namespace NUnitTestы
{
    public class Tests
    {
        private TestsGenerator _generator;
        private string _path = "C:\\5 sem\\SPP\\Labs\\Lab_4\\Classes\\AssemblyInfo.cs";
        private string _withoutMethods = "C:\\5 sem\\SPP\\Labs\\Lab_4\\WithoutMethods.cs";
        private string _empty = "C:\\5 sem\\SPP\\Labs\\Lab_4\\Empty.cs";

        [SetUp]
        public void Setup()
        {
            _generator = new TestsGenerator();
        }

        [Test]
        public async Task EmptyFileTest()
        {
            using (StreamReader reader = File.OpenText(_empty))
            {
                var result = await _generator.GenerateTest(reader.ReadToEnd());
                Assert.IsNull(result);
            }
        }


        [Test]
        public async Task CorrectFileTest()
        {
            using (StreamReader reader = File.OpenText(_path))
            {
                var result = await _generator.GenerateTest(reader.ReadToEnd());
                Assert.IsNotEmpty(result.Text);
            }
        }


        [Test]
        public async Task WithoutMethodsTest()
        {
            using (StreamReader reader = File.OpenText(_withoutMethods))
            {
                var result = await _generator.GenerateTest(reader.ReadToEnd());
                Assert.IsTrue(!result.Text.Contains("[Test]"));
            }
        }

        [Test]
        public async Task CorrectNameTest()
        {
            using (StreamReader reader = File.OpenText(_withoutMethods))
            {
                var result = await _generator.GenerateTest(reader.ReadToEnd());
                Assert.IsTrue(result.Text.Contains("public class TestByteGenerator"));
            }
        }
    }
}