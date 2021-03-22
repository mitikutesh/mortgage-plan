namespace Mortgage.Calculator.Interfaces
{
    public interface IMortgageManager
    {
        public string MortgageCalculatorResponse(int id,string customerName, decimal amount, decimal apr, int loanTerm);
    }
}