using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using LoanApplication.Data;

namespace LoanApplication.Migrations
{
    [DbContext(typeof(LoanDbContext))]
    [Migration("20170417214556_secondMigration")]
    partial class secondMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LoanApplication.Models.Admin.AdminLogin", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConfirmPassword");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("id");

                    b.ToTable("admins");
                });

            modelBuilder.Entity("LoanApplication.Models.Admin.LoanList", b =>
                {
                    b.Property<int>("loatypeID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bank")
                        .IsRequired();

                    b.Property<string>("Documents")
                        .IsRequired();

                    b.Property<string>("LoanType")
                        .IsRequired();

                    b.Property<string>("Rate")
                        .IsRequired();

                    b.Property<int>("Years");

                    b.HasKey("loatypeID");

                    b.ToTable("loanlist");
                });

            modelBuilder.Entity("LoanApplication.Models.Application.Documents", b =>
                {
                    b.Property<int>("docId")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("document");

                    b.HasKey("docId");

                    b.ToTable("documents");
                });

            modelBuilder.Entity("LoanApplication.Models.Application.Identification", b =>
                {
                    b.Property<int>("identityID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("IssueDate");

                    b.Property<string>("SSFNo")
                        .IsRequired();

                    b.Property<string>("SSID")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 13);

                    b.Property<int>("VoterID")
                        .HasAnnotation("MaxLength", 10);

                    b.Property<string>("placeissue")
                        .IsRequired();

                    b.HasKey("identityID");

                    b.ToTable("identification");
                });

            modelBuilder.Entity("LoanApplication.Models.Application.LoanDetails", b =>
                {
                    b.Property<int>("LoanId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccountNo")
                        .HasAnnotation("MaxLength", 13);

                    b.Property<double>("Amount");

                    b.Property<int>("loanterm");

                    b.Property<string>("purpose")
                        .IsRequired();

                    b.HasKey("LoanId");

                    b.ToTable("loandetails");
                });

            modelBuilder.Entity("LoanApplication.Models.Application.PersonalDetails", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<DateTime>("Dateofbirth")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("Emails")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("OtherNames")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<char>("Title")
                        .HasAnnotation("MaxLength", 3);

                    b.Property<string>("Work")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<int?>("documentsdocId");

                    b.Property<string>("gender")
                        .HasAnnotation("MaxLength", 10);

                    b.Property<int?>("identificationidentityID");

                    b.Property<int?>("loandetailsLoanId");

                    b.Property<int?>("loantypesloatypeID");

                    b.HasKey("CustomerID");

                    b.HasIndex("documentsdocId");

                    b.HasIndex("identificationidentityID");

                    b.HasIndex("loandetailsLoanId");

                    b.HasIndex("loantypesloatypeID");

                    b.ToTable("personalDetails");
                });

            modelBuilder.Entity("LoanApplication.Models.LoanApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("LoanApplication.Models.ManageAccounts.Customers", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConfirmPassword");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("UserName")
                        .IsRequired();

                    b.HasKey("id");

                    b.ToTable("customer");
                });

            modelBuilder.Entity("LoanApplication.Models.ManageAccounts.LoginModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("id");

                    b.ToTable("loginModel");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("LoanApplication.Models.Application.PersonalDetails", b =>
                {
                    b.HasOne("LoanApplication.Models.Application.Documents", "documents")
                        .WithMany("Customers")
                        .HasForeignKey("documentsdocId");

                    b.HasOne("LoanApplication.Models.Application.Identification", "identification")
                        .WithMany("Customers")
                        .HasForeignKey("identificationidentityID");

                    b.HasOne("LoanApplication.Models.Application.LoanDetails", "loandetails")
                        .WithMany("Customers")
                        .HasForeignKey("loandetailsLoanId");

                    b.HasOne("LoanApplication.Models.Admin.LoanList", "loantypes")
                        .WithMany("Customers")
                        .HasForeignKey("loantypesloatypeID");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("LoanApplication.Models.LoanApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("LoanApplication.Models.LoanApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LoanApplication.Models.LoanApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
