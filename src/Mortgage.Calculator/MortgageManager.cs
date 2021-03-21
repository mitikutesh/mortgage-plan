using Mortgage.Calculator.Interfaces;

namespace Mortgage.Calculator
{
    public class MortgageManager : IMortgageManager
    {
        public string MortgageCalculatorResponse(string customerName, decimal amount, decimal apr, int loanTerm)
        {
            var monthlyPaymenet = MortgageMath.FixedMonthlyPayment(amount, apr, loanTerm);

            var response = "****************************************************************************************************\n" +
                           $"Prospect 1: {customerName} wants to borrow {amount}€ for a period of {loanTerm} years and pay {monthlyPaymenet}€ each month \n" +
                           "* **************************************************************************************************";
            return response;                   
        }
    }
}