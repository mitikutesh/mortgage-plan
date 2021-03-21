using System;
using CommandLine;
using FluentValidation;

namespace Mortgage.Cli
{
    //command line options
    public class CommandLineOptions
    {
        [Option('p', "filepath ", Required = false, HelpText = "File path.")]
        public string FilePath { get; set; }

        [Option('n', "name ", Required = false, HelpText = " Customer Name.")]
        public string CustomerName { get; set; }

        [Option('l', "amount", Required = false, HelpText = "Total loan amount.")]
        public Decimal LoanAmount { get; set; } 

        [Option('i', "annualInterest", Required = false, HelpText = "Annual interest rate in percent")]
        public decimal Interest { get; set; }

        [Option('y', "years", Required = false, HelpText = "Set loan term in year")]
        public int LoanTerm { get; set; }
    }
    public class CommandLineOptionsValidator : AbstractValidator<CommandLineOptions>
    {
        public CommandLineOptionsValidator()
        {
            RuleFor(a => a.FilePath).NotEmpty().NotNull().WithMessage("Please provide file path.");
            //RuleFor(a => a.CustomerName).NotEmpty().NotNull().WithMessage("Customer Name cannot be empty!.");
            //RuleFor(a => a.LoanAmount).NotEmpty().NotNull().WithMessage("Please check loan amount!");
            //RuleFor(a => a.Interest).NotEmpty().WithMessage("Please put annual interest rate in percent!");
            //RuleFor(a => a.LoanTerm).NotEmpty().NotNull().WithMessage("Loan term cannot be empty!");
        }

    }
}