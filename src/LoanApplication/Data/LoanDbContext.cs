using LoanApplication.Models;
using LoanApplication.Models.Admin;
using LoanApplication.Models.Application;
using LoanApplication.Models.ManageAccounts;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanApplication.Data
{
    public class LoanDbContext : IdentityDbContext<LoanApplicationUser>
    {
        public LoanDbContext(DbContextOptions<LoanDbContext> options)
            : base(options)
        {
        }

        public LoanDbContext()
        {
        }

        public DbSet<Customers> customer { get; set; }
        public DbSet<AdminLogin> admins { get; set; }
        public DbSet<LoanList> loanlist { get; set; }
        public DbSet<Identification> identification { get; set; }

        public DbSet<LoanDetails> loandetails { get; set; }
        public DbSet<PersonalDetails> personalDetails { get; set; }
        public DbSet<LoginModel> loginModel { get; set; }


    }

}

