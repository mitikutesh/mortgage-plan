using System.Collections.Generic;
using CommandLine;
using FluentValidation;

namespace Mortgage.Cli
{
    public class CommandLineParser
    {
        public static CommandLineOptions ReadCmdLine(string[] args)
            => Parser.Default.ParseArguments<CommandLineOptions>(args)
                .MapResult(ParsedArgs, NotParsedArgs);
        private static CommandLineOptions ParsedArgs(CommandLineOptions model)
        {
            var val = new CommandLineOptionsValidator()
                .Validate(model, a =>
                {
                    a.ThrowOnFailures();
                    a.IncludeProperties(x => x.FilePath);
                    a.IncludeProperties(x => x.CustomerName);
                    a.IncludeProperties(x => x.CustomerName);
                    a.IncludeProperties(x => x.LoanTerm);
                    a.IncludeProperties(x => x.Interest);
                });
            return model;
        }

        private static CommandLineOptions NotParsedArgs(IEnumerable<Error> errors)
        {
            //TODO log error => errors.ToList().ForEach(a => WriteLine(a.ToString()));
            return null;
        }
    }
}