using System;
using System.Threading.Tasks;
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