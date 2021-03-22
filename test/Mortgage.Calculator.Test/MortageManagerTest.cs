using Mortgage.Calculator.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Mortgage.Calculator.Test
{
    public abstract class BaseTest
    {
        protected abstract IMortgageManager CreateInstance();

        [Test]
        public void Test1()
        {
            IMortgageManager instance = CreateInstance();
            //Do some testing on the instance...
        }

        //And some more tests.
    }

    [TestFixture]
    public class MortageManagerTest : BaseTest
    {
        private static string GetPath(string fileName)
             => Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), fileName);

        public static string[] TestCases()// = new string[]
        {
             var path = GetPath("TestData.txt");
            return File.ReadAllLines(path)
            .Skip(1)
            .TakeWhile(s => !string.IsNullOrEmpty(s))
            .ToArray();
        }


        [Test, TestCaseSource("TestCases")]
        public void Mortage_Calculator_Response_should_Work(string testCase)
        {
            var test = testCase.Split(',');
            string customerName = test[0];
            Decimal amount = Decimal.Parse(test[1].Replace(".", ","));
            Decimal apr = Decimal.Parse(test[2].Replace(".", ","));
            int loanTerm = int.Parse(test[3]);
            Decimal monthlyPayement = Decimal.Parse(test[4].Replace(".", ","));

            var expected = "****************************************************************************************************\n" +
             $"Prospect 1: {customerName} wants to borrow {amount}€ for a period of {loanTerm} years and pay {monthlyPayement}€ each month. \n" +
             "***************************************************************************************************";

            var result = CreateInstance().MortgageCalculatorResponse(1,customerName, amount, apr, loanTerm);
            Assert.AreEqual(expected, result);
        }

        protected override IMortgageManager CreateInstance()
        {
            return new MortgageManager();
        }
    }
}
