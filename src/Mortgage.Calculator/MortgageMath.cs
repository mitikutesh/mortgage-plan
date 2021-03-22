using System;

namespace Mortgage.Calculator
{
    public static class MortgageMath
    {
        public static decimal Power(decimal baseNumber, int expNumber)
        {
            try
            {
                decimal result = 1;
                //for negative force
                bool sing = true;
                if (expNumber < 0)
                {
                    sing = false;
                    expNumber = expNumber * -1;
                }

                for (int i = 1; i <= expNumber; i++)
                {
                    if (sing)
                        result = result * baseNumber;
                    else
                        result /= baseNumber;
                }

                return result;
            }
            catch (Exception)
            {
                //log exception
                throw;
            }

            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="apr">in percent</param>
        /// <param name="loanTerm"></param>
        /// <returns></returns>
        public static decimal FixedMonthlyPayment(decimal amount, decimal apr, int loanTerm)
        {
            /*
              E = Fixed monthly payment
              b = Interest on a monthly basis
              U = Total loan
              p = Number of payments(monthes)

              E = U[b(1 + b)^p]/[(1 + b)^p - 1]
            */

            try
            {
                decimal E, U, b;
                int p;
                U = amount;
                p = 12 * loanTerm;
                b = (apr / 12) / 100;
                E = U * b * Power(1 + (b), p) / (Power((1 + (b)), p) - 1);
                E = Decimal.Round(E, 2);
                return E;
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}