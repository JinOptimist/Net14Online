﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Net14Web.DbStuff;

#nullable disable

namespace Net14Web.Migrations.ManagmentCompanyDb
{
    [DbContext(typeof(ManagmentCompanyDbContext))]
    [Migration("20240124093904_FixBaseAttributes")]
    partial class FixBaseAttributes
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ExecutorProject", b =>
                {
                    b.Property<int>("ExecutorsId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectsId")
                        .HasColumnType("int");

                    b.HasKey("ExecutorsId", "ProjectsId");

                    b.HasIndex("ProjectsId");

                    b.ToTable("ExecutorProject");
                });

            modelBuilder.Entity("Net14Web.DbStuff.ManagmentCompany.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CompanyStatusId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyStatusId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("Net14Web.DbStuff.ManagmentCompany.Models.Executor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ExecutorStatusId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ExpireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MemberPermissionId")
                        .HasColumnType("int");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ExecutorStatusId");

                    b.HasIndex("MemberPermissionId");

                    b.ToTable("Executors");
                });

            modelBuilder.Entity("Net14Web.DbStuff.ManagmentCompany.Models.MemberPermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Permission")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MemberPermissions");
                });

            modelBuilder.Entity("Net14Web.DbStuff.ManagmentCompany.Models.MemberStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MemberStatuses");
                });

            modelBuilder.Entity("Net14Web.DbStuff.ManagmentCompany.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CompanyId")
                        .HasColumnType("int");

                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProjectStatusId")
                        .HasColumnType("int");

                    b.Property<string>("ShortName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("ProjectStatusId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Net14Web.DbStuff.ManagmentCompany.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MemberPermissionId")
                        .HasColumnType("int");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserStatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MemberPermissionId");

                    b.HasIndex("UserStatusId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Net14Web.DbStuff.ManagmentCompany.Models.UserTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AuthorId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CompletionDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ExecutorId")
                        .HasColumnType("int");

                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("ExecutorId");

                    b.HasIndex("StatusId");

                    b.ToTable("UserTasks");
                });

            modelBuilder.Entity("Net14Web.DbStuff.ManagmentCompany.Models.UserTaskStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TaskStatuses");
                });

            modelBuilder.Entity("ExecutorProject", b =>
                {
                    b.HasOne("Net14Web.DbStuff.ManagmentCompany.Models.Executor", null)
                        .WithMany()
                        .HasForeignKey("ExecutorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Net14Web.DbStuff.ManagmentCompany.Models.Project", null)
                        .WithMany()
                        .HasForeignKey("ProjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Net14Web.DbStuff.ManagmentCompany.Models.Company", b =>
                {
                    b.HasOne("Net14Web.DbStuff.ManagmentCompany.Models.MemberStatus", "CompanyStatus")
                        .WithMany("Companies")
                        .HasForeignKey("CompanyStatusId");

                    b.Navigation("CompanyStatus");
                });

            modelBuilder.Entity("Net14Web.DbStuff.ManagmentCompany.Models.Executor", b =>
                {
                    b.HasOne("Net14Web.DbStuff.ManagmentCompany.Models.MemberStatus", "ExecutorStatus")
                        .WithMany("Executors")
                        .HasForeignKey("ExecutorStatusId");

                    b.HasOne("Net14Web.DbStuff.ManagmentCompany.Models.MemberPermission", "MemberPermission")
                        .WithMany("Executors")
                        .HasForeignKey("MemberPermissionId");

                    b.Navigation("ExecutorStatus");

                    b.Navigation("MemberPermission");
                });

            modelBuilder.Entity("Net14Web.DbStuff.ManagmentCompany.Models.Project", b =>
                {
                    b.HasOne("Net14Web.DbStuff.ManagmentCompany.Models.Company", "Company")
                        .WithMany("Projects")
                        .HasForeignKey("CompanyId");

                    b.HasOne("Net14Web.DbStuff.ManagmentCompany.Models.MemberStatus", "ProjectStatus")
                        .WithMany("Projects")
                        .HasForeignKey("ProjectStatusId");

                    b.Navigation("Company");

                    b.Navigation("ProjectStatus");
                });

            modelBuilder.Entity("Net14Web.DbStuff.ManagmentCompany.Models.User", b =>
                {
                    b.HasOne("Net14Web.DbStuff.ManagmentCompany.Models.MemberPermission", "MemberPermission")
                        .WithMany("Users")
                        .HasForeignKey("MemberPermissionId");

                    b.HasOne("Net14Web.DbStuff.ManagmentCompany.Models.MemberStatus", "UserStatus")
                        .WithMany("Users")
                        .HasForeignKey("UserStatusId");

                    b.Navigation("MemberPermission");

                    b.Navigation("UserStatus");
                });

            modelBuilder.Entity("Net14Web.DbStuff.ManagmentCompany.Models.UserTask", b =>
                {
                    b.HasOne("Net14Web.DbStuff.ManagmentCompany.Models.User", "Author")
                        .WithMany("UserTasks")
                        .HasForeignKey("AuthorId");

                    b.HasOne("Net14Web.DbStuff.ManagmentCompany.Models.Executor", "Executor")
                        .WithMany("ExecutorTasks")
                        .HasForeignKey("ExecutorId");

                    b.HasOne("Net14Web.DbStuff.ManagmentCompany.Models.UserTaskStatus", "Status")
                        .WithMany("UserTasks")
                        .HasForeignKey("StatusId");

                    b.Navigation("Author");

                    b.Navigation("Executor");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Net14Web.DbStuff.ManagmentCompany.Models.Company", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("Net14Web.DbStuff.ManagmentCompany.Models.Executor", b =>
                {
                    b.Navigation("ExecutorTasks");
                });

            modelBuilder.Entity("Net14Web.DbStuff.ManagmentCompany.Models.MemberPermission", b =>
                {
                    b.Navigation("Executors");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Net14Web.DbStuff.ManagmentCompany.Models.MemberStatus", b =>
                {
                    b.Navigation("Companies");

                    b.Navigation("Executors");

                    b.Navigation("Projects");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Net14Web.DbStuff.ManagmentCompany.Models.User", b =>
                {
                    b.Navigation("UserTasks");
                });

            modelBuilder.Entity("Net14Web.DbStuff.ManagmentCompany.Models.UserTaskStatus", b =>
                {
                    b.Navigation("UserTasks");
                });
#pragma warning restore 612, 618
        }
    }
}