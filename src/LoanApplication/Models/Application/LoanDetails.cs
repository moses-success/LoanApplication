using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoanApplication.Models.Application
{
    public class LoanDetails
    {
        [Key]
        public int LoanId { get; set; }

        [Required(ErrorMessage = "Please enter Loan Amonut Required")]
        [Display(Name="Loan Amonut Required")]
        [DataType(DataType.Currency)]
        public double Amount { get; set; }

        [Required(ErrorMessage = "Please enter Loan Terms Proposed")]
        [Display(Name = "Loan Terms Proposed(Months)")]
        //[RegularExpression("",ErrorMessage ="Enter Total Months")]
        public int loanterm { get; set; }

        [Required(ErrorMessage = "Please enter Purpose for Taking the Loan")]
        [Display(Name = "Purpose of Loan")]
        public string purpose { get; set; }

        [Required(ErrorMessage = "Please enter Customer Account Number")]
        [Display(Name = "Customer Account Number")]
        [StringLength(13, ErrorMessage ="Enter Full Account Number" )]
        public int AccountNo { get; set; }
                
        public List<PersonalDetails> Customers { get; set; }
    }
}
