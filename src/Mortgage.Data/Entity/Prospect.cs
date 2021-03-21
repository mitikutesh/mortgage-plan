using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mortgage.Data.Entity
{
    public class Prospect
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
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