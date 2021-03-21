using System;
using System.Collections.Generic;
using Mortgage.Calculator;
using static System.Console;

namespace Mortgage.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            OutputEncoding = System.Text.Encoding.UTF8; //Display euro symbol

            var arguments = CommandLineParser.ReadCmdLine(args);
            if (arguments is null) return;
            
            WriteLine((new MortgageManager())
                .MortgageCalculatorResponse(arguments.CustomerName, arguments.LoanAmount, arguments.Interest,
                    arguments.LoanTerm));
            ReadKey();
        }
    }
}