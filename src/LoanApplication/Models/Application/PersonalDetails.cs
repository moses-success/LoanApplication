using LoanApplication.Models.Admin;
using LoanApplication.Models.Application;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoanApplication.Models.Application
{
    public class PersonalDetails
    {
        [Key]
        [Display(Name = "Customer ID")]
        public int CustomerID { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Title")]
        [StringLength(3)]
        public char Title { get; set; }

        [Required(ErrorMessage = "Please enter your Surname")]
        [StringLength(50)]
        [DataType(DataType.Text)]
        [Display(Name = "Surname")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your Other Names")]
        [StringLength(100)]
        [Display(Name = "Other Names")]
        [DataType(DataType.Text)]
        public string OtherNames { get; set; }


        public string Name
        {
            get
            {
                return string.Format("{0} {1}", this.LastName, this.OtherNames);
            }
        }

        [Required(ErrorMessage = "Please enter your Email Address")]
        [StringLength(50)]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Emails { get; set; }

        [Required(ErrorMessage = "Please enter your Mobile Number")]
        [StringLength(50)]
        [Display(Name = "Mobile Number")]
        public string Phone { get; set; }

        [StringLength(50)]
        [Display(Name = "Telephone Number")]
        public string Work { get; set; }

        [Required(ErrorMessage = "Please enter your Residential Address")]
        [StringLength(50)]
        [Display(Name = "Residential Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter your Date of Birth")]
        [StringLength(50)]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:F}")]
        public DateTime Dateofbirth { get; set; }

        [StringLength(10)]
        [Display(Name = "Gender")]
        [DataType(DataType.Text)]
        public string gender { get; set; }


        public virtual LoanList loantypes {get; set;}

        public virtual LoanDetails loandetails { get; set; }
        public virtual Identification identification { get; set; }
        


    }
}
