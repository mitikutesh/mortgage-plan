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
    }
    public class CommandLineOptionsValidator : AbstractValidator<CommandLineOptions>
    {
        public CommandLineOptionsValidator()
        {
            RuleFor(a => a.FilePath).NotEmpty().NotNull().WithMessage("Please provide file path.");
        }

    }
}