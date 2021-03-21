using System;
using Mortgage.Calculator;

namespace Mortgage.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            var arguments = CommandLineParser.ReadCmdLine(args);
            if(arguments is null) return;
            
            var test = (new MortgageManager()).MortgageCalculatorResponse("Juha", 1000, 5, 2);
            Console.WriteLine("Hello World!");
        }
    }
}