using NUnit.Framework;
using System.IO;
using System.Reflection;

namespace Mortgage.Cli.Test
{
    public class Tests
    {
        private static string GetPath(string fileName)
            => Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), fileName);
    
        [Test]
        public void File_Should_Be_Read()
        {
            var path = GetPath("TestData.txt");
            var res = FileReadWrite.ReadFileAsync(path);
            Assert.Pass();
        }
    }
}