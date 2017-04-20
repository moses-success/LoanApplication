using LoanApplication.Data;
using LoanApplication.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanApplication.Repository
{
    public class ListingsRepository
    {
        private LoanDbContext _context = new LoanDbContext();

        //List All Loan Entries
        public List<LoanList> GetLoans()
        {
            var allData = _context.loanlist.ToList();

            return allData;
        }

    }
}
