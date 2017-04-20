using LoanApplication.Models.Application;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoanApplication.Models.Admin
{
    public class LoanList
    {
        [Key]
        public int loatypeID { get; set; }

        [Required(ErrorMessage = "Please enter the name of your Institution")]
        [Display(Name = "Name of Institution")]
        public string  Bank { get; set; }

        [Required(ErrorMessage = "Please enter Type of Loan")]
        [Display(Name = "Loan Type")]
        public string LoanType{ get; set; }

        [Required(ErrorMessage = "Please enter Interest Rate")]
        [Display(Name = "Interest Rate")]
        public string Rate{ get; set; }

        [Required(ErrorMessage = "Please enter Years")]
        [Display(Name ="Years")]
        public int Years { get; set; }

        [Required(ErrorMessage = "Please enter Documents Required")]
        [Display(Name = "Required Documents")]
        public string Documents{ get; set; }

        public List<PersonalDetails> Customers { get; set; }


    }
}
