using Mortgage.Calculator.Interfaces;

namespace Mortgage.Calculator
{
    public class MortgageManager : IMortgageManager
    {
        public string MortgageCalculatorResponse(int id, string customerName, decimal amount, decimal apr, int loanTerm)
        {
            try
            {
                var monthlyPaymenet = MortgageMath.FixedMonthlyPayment(amount, apr, loanTerm);

                var response = "****************************************************************************************************\n" +
                               $"Prospect {id}: {customerName} wants to borrow {amount}€ for a period of {loanTerm} years and pay {monthlyPaymenet}€ each month. \n" +
                               "***************************************************************************************************";
                return response;
            }
            catch (System.Exception ex) 
            {
                //log error
                return ex.Message;               
            }
                          
        }
    }
}