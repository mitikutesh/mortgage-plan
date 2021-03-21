using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Mortgage.Calculator;
using static System.Console;

namespace Mortgage.Cli
{
    public static class FileReadWrite
    {
        public static async IAsyncEnumerable<string> ReadFileAsync(string path)
        {
            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (var reader = new StreamReader(stream, Encoding.UTF8))
            {
                reader.ReadLine(); //skip first line
                while (!reader.EndOfStream)
                    yield return await reader.ReadLineAsync();
            }
        }

        public static  async Task DisplayDataAsync(string FilePath)
        {
            OutputEncoding = System.Text.Encoding.UTF8; //Display euro symbol
            await foreach (var a in ReadFileAsync(FilePath))
            {
                if (string.IsNullOrWhiteSpace(a)) continue;
                var data = Regex.Split(a, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)").Where(s2 => !string.IsNullOrEmpty(s2)).ToArray();
                string customerName = data[0];
                Decimal amount = Decimal.Parse(data[1].Replace(".", ","));
                Decimal apr = Decimal.Parse(data[2].Replace(".", ","));
                int loanTerm = int.Parse(data[3]);
                WriteLine((new MortgageManager()).MortgageCalculatorResponse(customerName, amount, apr, loanTerm));
            }
        }
    }
}
