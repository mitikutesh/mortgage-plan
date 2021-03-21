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
    public class Program
    {

        public static async Task Main(string[] args)
        {
            try
            {
                var arguments = CommandLineParser.ReadCmdLine(args);
                if (arguments is null) return;
                //var path = @"C:\Users\mitik\Downloads\Codetest-Mortageplan (1)\prospects.txt";
                await FileReadWrite.DisplayDataAsync(arguments.FilePath);

                ReadKey();
            }
            catch (Exception ex)
            {
                WriteLine("Error: " + ex.Message);
            }finally
            {
                WriteLine("Try Re running!");
            }
         
        }


       

    }
}