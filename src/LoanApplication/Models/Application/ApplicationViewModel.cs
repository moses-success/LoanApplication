using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanApplication.Models.Application
{
    public class ApplicationViewModel
    {
        public List<Identification> identification { get; set; }
        public List<LoanDetails> loanDetails { get; set; }
        public List<PersonalDetails> personalDetails { get; set; }

    }
}
