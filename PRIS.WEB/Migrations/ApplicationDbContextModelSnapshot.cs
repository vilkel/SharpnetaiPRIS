﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PRIS.WEB.Data;

namespace PRIS.WEB.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "2301D884-221A-4E7D-B509-0113DCC043E1",
                            ConcurrencyStamp = "a3f94748-6570-43cf-b19d-0ee6ed5b6eeb",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "a2a6f863-1265-44b7-805c-88fba182b55f",
                            ConcurrencyStamp = "2df69c73-20ac-42dc-881a-25df8ab9bb43",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasData(
                        new
                        {
                            UserId = "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                            RoleId = "2301D884-221A-4E7D-B509-0113DCC043E1"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("PRIS.WEB.Data.Models.AcademicYear", b =>
                {
                    b.Property<int>("AcademicYearID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AcademicYearEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("AcademicYearStart")
                        .HasColumnType("datetime2");

                    b.HasKey("AcademicYearID");

                    b.ToTable("AcademicYear");
                });

            modelBuilder.Entity("PRIS.WEB.Data.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<bool>("ChangeInitialPassword")
                        .HasColumnType("bit");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                            AccessFailedCount = 0,
                            ChangeInitialPassword = true,
                            ConcurrencyStamp = "5fc61b9a-442a-4aa1-83f5-2ecd52cb993a",
                            Email = "Admin1@Admin.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@ADMIN.COM",
                            NormalizedUserName = "ADMIN1@ADMIN.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEGGZzAxCe13t34HYgcsHRZ1XQoAk7l0Jm3ZFuqGGEMpG3HP8zCqgTUTl9shktLN6Ew==",
                            PhoneNumber = "XXXXXXXXXXXXX",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "00000000-0000-0000-0000-000000000000",
                            TwoFactorEnabled = false,
                            UserName = "Admin1@Admin.com"
                        });
                });

            modelBuilder.Entity("PRIS.WEB.Data.Models.Contract", b =>
                {
                    b.Property<int>("ContractId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ContractDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ContractType")
                        .HasColumnType("int");

                    b.Property<bool>("IsContractSigned")
                        .HasColumnType("bit");

                    b.Property<string>("SignedByFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SignedByLastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContractId");

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("PRIS.WEB.Data.Models.InterviewQuestionsAnswers", b =>
                {
                    b.Property<int>("InterviewQuestionsAnswersID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CandidateID")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InterviewTaskID")
                        .HasColumnType("int");

                    b.HasKey("InterviewQuestionsAnswersID");

                    b.HasIndex("CandidateID");

                    b.HasIndex("InterviewTaskID");

                    b.ToTable("InterviewQuestionsAnswers");
                });

            modelBuilder.Entity("PRIS.WEB.Data.Models.InterviewResult", b =>
                {
                    b.Property<int>("InterviewResultID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CandidateId")
                        .HasColumnType("int");

                    b.Property<string>("GeneralComment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("InterviewResultID");

                    b.HasIndex("CandidateId");

                    b.ToTable("InterviewResult");
                });

            modelBuilder.Entity("PRIS.WEB.Data.Models.InterviewTask", b =>
                {
                    b.Property<int>("InterviewTaskID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("InterviewTaskDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.HasKey("InterviewTaskID");

                    b.ToTable("InterviewTask");
                });

            modelBuilder.Entity("PRIS.WEB.Data.Models.InterviewTemplate", b =>
                {
                    b.Property<int>("InterviewTemplateID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AcademicYearID")
                        .HasColumnType("int");

                    b.HasKey("InterviewTemplateID");

                    b.HasIndex("AcademicYearID");

                    b.ToTable("InterviewTemplate");
                });

            modelBuilder.Entity("PRIS.WEB.Data.Models.InterviewTemplateTask", b =>
                {
                    b.Property<int>("InterviewTaskID")
                        .HasColumnType("int");

                    b.Property<int>("InterviewTemplateID")
                        .HasColumnType("int");

                    b.HasKey("InterviewTaskID", "InterviewTemplateID");

                    b.HasIndex("InterviewTemplateID");

                    b.ToTable("InterviewTemplateTask");
                });

            modelBuilder.Entity("PRIS.WEB.Data.Models.TaskResult", b =>
                {
                    b.Property<int>("TaskResultId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CandidateId")
                        .HasColumnType("int");

                    b.Property<int>("TaskResultLimitId")
                        .HasColumnType("int");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("TaskResultId");

                    b.HasIndex("CandidateId");

                    b.HasIndex("TaskResultLimitId");

                    b.ToTable("TaskResult");
                });

            modelBuilder.Entity("PRIS.WEB.Data.Models.TaskResultLimit", b =>
                {
                    b.Property<int>("TaskResultLimitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<double>("MaxValue")
                        .HasColumnType("float");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<int>("TaskGroupID")
                        .HasColumnType("int");

                    b.HasKey("TaskResultLimitId");

                    b.HasIndex("TaskGroupID");

                    b.ToTable("TaskResultLimits");
                });

            modelBuilder.Entity("PRIS.WEB.Models.Candidate", b =>
                {
                    b.Property<int>("CandidateID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("InvitedToInterview")
                        .HasColumnType("bit");

                    b.Property<bool>("InvitedToStudy")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.Property<int>("TestId")
                        .HasColumnType("int");

                    b.HasKey("CandidateID");

                    b.HasIndex("TestId");

                    b.ToTable("Candidate");
                });

            modelBuilder.Entity("PRIS.WEB.Models.CandidateModule", b =>
                {
                    b.Property<int>("CandidateID")
                        .HasColumnType("int");

                    b.Property<int>("ModuleID")
                        .HasColumnType("int");

                    b.Property<int>("OrderNr")
                        .HasColumnType("int");

                    b.HasKey("CandidateID", "ModuleID");

                    b.HasIndex("ModuleID");

                    b.ToTable("CandidateModule");
                });

            modelBuilder.Entity("PRIS.WEB.Models.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CityId");

                    b.ToTable("City");
                });

            modelBuilder.Entity("PRIS.WEB.Models.Module", b =>
                {
                    b.Property<int>("ModuleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ModuleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ModuleID");

                    b.ToTable("Module");
                });

            modelBuilder.Entity("PRIS.WEB.Models.TaskGroup", b =>
                {
                    b.Property<int>("TaskGroupID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TaskGroupName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TaskGroupID");

                    b.ToTable("TaskGroup");
                });

            modelBuilder.Entity("PRIS.WEB.Models.Test", b =>
                {
                    b.Property<int>("TestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AcademicYearID")
                        .HasColumnType("int");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfTest")
                        .HasColumnType("datetime2");

                    b.HasKey("TestId");

                    b.HasIndex("AcademicYearID");

                    b.HasIndex("CityId");

                    b.ToTable("Test");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("PRIS.WEB.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("PRIS.WEB.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PRIS.WEB.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("PRIS.WEB.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PRIS.WEB.Data.Models.InterviewQuestionsAnswers", b =>
                {
                    b.HasOne("PRIS.WEB.Models.Candidate", "Candidate")
                        .WithMany()
                        .HasForeignKey("CandidateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PRIS.WEB.Data.Models.InterviewTask", "InterviewTask")
                        .WithMany()
                        .HasForeignKey("InterviewTaskID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PRIS.WEB.Data.Models.InterviewResult", b =>
                {
                    b.HasOne("PRIS.WEB.Models.Candidate", "Candidate")
                        .WithMany()
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PRIS.WEB.Data.Models.InterviewTemplate", b =>
                {
                    b.HasOne("PRIS.WEB.Data.Models.AcademicYear", "AcademicYear")
                        .WithMany()
                        .HasForeignKey("AcademicYearID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PRIS.WEB.Data.Models.InterviewTemplateTask", b =>
                {
                    b.HasOne("PRIS.WEB.Data.Models.InterviewTask", "InterviewTask")
                        .WithMany()
                        .HasForeignKey("InterviewTaskID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PRIS.WEB.Data.Models.InterviewTemplate", "InterviewTemplate")
                        .WithMany("InterviewTemplateTasks")
                        .HasForeignKey("InterviewTemplateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PRIS.WEB.Data.Models.TaskResult", b =>
                {
                    b.HasOne("PRIS.WEB.Models.Candidate", "Candidate")
                        .WithMany()
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PRIS.WEB.Data.Models.TaskResultLimit", "TaskResultLimit")
                        .WithMany()
                        .HasForeignKey("TaskResultLimitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PRIS.WEB.Data.Models.TaskResultLimit", b =>
                {
                    b.HasOne("PRIS.WEB.Models.TaskGroup", "TaskGroup")
                        .WithMany()
                        .HasForeignKey("TaskGroupID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PRIS.WEB.Models.Candidate", b =>
                {
                    b.HasOne("PRIS.WEB.Models.Test", "Test")
                        .WithMany()
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PRIS.WEB.Models.CandidateModule", b =>
                {
                    b.HasOne("PRIS.WEB.Models.Candidate", "Candidate")
                        .WithMany("CandidateModules")
                        .HasForeignKey("CandidateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PRIS.WEB.Models.Module", "Module")
                        .WithMany()
                        .HasForeignKey("ModuleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PRIS.WEB.Models.Test", b =>
                {
                    b.HasOne("PRIS.WEB.Data.Models.AcademicYear", "AcademicYear")
                        .WithMany()
                        .HasForeignKey("AcademicYearID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PRIS.WEB.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
