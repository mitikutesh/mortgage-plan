namespace Mortgage.Calculator.Interfaces
{
    public interface IMortgageManager
    {
        public string MortgageCalculatorResponse(string customerName, decimal amount, decimal apr, int loanTerm);
    }
}