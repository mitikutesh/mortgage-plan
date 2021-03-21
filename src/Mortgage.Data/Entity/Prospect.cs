using System;
using System.ComponentModel.DataAnnotations;

namespace Mortgage.Data.Entity
{
    public class ProspectEntity
    {
        [Key]
        public int Id { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string CustomerName { get; set; }
        [DataType(DataType.Currency)]
        public Decimal LoanAmount { get; set; }
        public Decimal AnnualInterest { get; set; }
        public int LoanTerm { get; set; }

    }
}