using System;
using CommandLine;
using FluentValidation;

namespace Mortgage.Cli
{
    //command line options
    public class CommandLineOptions
    {
        [Option('n', "name ", Required = true, HelpText = " Customer Name.")]
        public string CustomerName { get; set; }

        [Option('l', "amount", Required = true, HelpText = "Total loan amount.")]
        public Decimal LoanAmount { get; set; } 

        [Option('i', "annualInterest", Required = true, HelpText = "Annual interest rate in percent")]
        public decimal Interest { get; set; }

        [Option('y', "years", Required = true, HelpText = "Set loan term in year")]
        public int LoanTerm { get; set; }
    }
    public class CommandLineOptionsValidator : AbstractValidator<CommandLineOptions>
    {
        public CommandLineOptionsValidator()
        {
            RuleFor(a => a.CustomerName).NotEmpty().NotNull().WithMessage("Customer Name cannot be empty!.");
            RuleFor(a => a.LoanAmount).NotEmpty().NotNull().WithMessage("Please check loan amount!");
            RuleFor(a => a.Interest).NotEmpty().WithMessage("Please put annual interest rate in percent!");
            RuleFor(a => a.LoanTerm).NotEmpty().NotNull().WithMessage("Loan term cannot be empty!");
        }

    }
}