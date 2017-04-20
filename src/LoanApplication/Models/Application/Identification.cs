using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoanApplication.Models.Application
{
    public class Identification
    {
        [Key]
        public int identityID { get; set; }

        [Required(ErrorMessage = "Please enter your SSF Number")]
        [Display(Name = "SSF Number")]
        public string SSFNo { get; set; }

        [Required(ErrorMessage = "Please enter your Social Security Number")]
        [Display(Name= "Security Service ID")]
       // [RegularExpression("",ErrorMessage ="Social Security Number must Start with a Letter")]
        [StringLength(13,ErrorMessage ="Wrong Social Security Number ,It must be 13 charaters long")]
        public string SSID { get; set; }

        [Required(ErrorMessage = "Please enter your Voter ID")]
        [Display(Name ="Voter ID")]
        [StringLength(10, ErrorMessage = "Voters ID must be 10 numbers")]
        // [RegularExpression("",ErrorMessage ="This Field Takes only Numbers")]
        public int VoterID { get; set; }  

        [Required(ErrorMessage = "Please enter Issue Date on your Voters Card")]
        [Display(Name = "Issue Date")]
        [DataType(DataType.DateTime)]
        public DateTime IssueDate { get; set; }


        [Required(ErrorMessage = "Please enter Place where your Voter's Card was Issued to You")]
        [Display(Name ="Place Issue")]
        public string placeissue { get; set; }

        [Required]
        [Display(Name = "Upload Document")]
        public Byte[] document { get; set; }

        public List<PersonalDetails> Customers { get; set; }


    }
}
