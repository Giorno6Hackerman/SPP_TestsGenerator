using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace TestsGeneratorLibrary
{
    public class TestsGenerator
    {
        public static async Task<TestClass> GenerateTest(string file)
        {
            SyntaxTree tree = CSharpSyntaxTree.ParseText(file);
            TestClass test = new TestClass();
            test.Name = "Test" + tree.FilePath.Substring(tree.FilePath.LastIndexOf("\\") + 1);
            CancellationToken token = new CancellationToken(false);

            var classes = tree.GetRoot().DescendantNodes().Where(n => n.IsKind(SyntaxKind.ClassDeclaration));
            var methods = classes.SelectMany(n => n.DescendantNodes().Where(node => node.IsKind(SyntaxKind.MethodDeclaration)));
            methods = methods.Where(m => m.ChildTokens().Any(t => t.IsKind(SyntaxKind.PublicKeyword)));

            test.Text = "using System;\r\n";
            test.Text += "namespace MyCode.Tests\r\n";
            test.Text += "{\r\n";
            test.Text += "\t[TestClass]\r\n";
            test.Text += "\tpublic class " + test.Name.Substring(0, test.Name.IndexOf(".")) + "\r\n";
            test.Text += "\t{\r\n";



            return test;
        }
    }
}
