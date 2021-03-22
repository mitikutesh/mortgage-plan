using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mortgage.Data.DTO
{
    public class ProspectDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Customer Name Required")]
        [DisplayName("Customer Name")]
        public string CustomerName { get; set; }

        [DisplayName("Loan Amount")]
        [DataType(DataType.Currency)]
        public Decimal LoanAmount { get; set; }
        //fixedyearlyinterest
        [DisplayName("Fixed yearly interest")]
        public Decimal AnnualInterest { get; set; }

        [DisplayName("Loan Term")]
        public int LoanTerm { get; set; }
      
    }
}
