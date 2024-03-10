﻿// <auto-generated />
using System;
using ManagementCompany.DbStuff;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ManagementCompany.Migrations.ManagmentCompanyDb
{
    [DbContext(typeof(ManagementCompanyDbContext))]
    partial class ManagmentCompanyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ManagementCompany.DbStuff.Models.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("ThumbsDown")
                        .HasColumnType("int");

                    b.Property<int?>("ThumbsUp")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("ManagementCompany.DbStuff.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ArticleId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("ManagementCompany.DbStuff.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.HasIndex("ShortName")
                        .IsUnique();

                    b.HasIndex("StatusId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("ManagementCompany.DbStuff.Models.MemberPermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Permission")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Permission")
                        .IsUnique()
                        .HasFilter("[Permission] IS NOT NULL");

                    b.ToTable("MemberPermissions");
                });

            modelBuilder.Entity("ManagementCompany.DbStuff.Models.MemberStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Status")
                        .IsUnique()
                        .HasFilter("[Status] IS NOT NULL");

                    b.ToTable("MemberStatuses");
                });

            modelBuilder.Entity("ManagementCompany.DbStuff.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CompanyId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("ShortName")
                        .IsUnique()
                        .HasFilter("[ShortName] IS NOT NULL");

                    b.HasIndex("StatusId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("ManagementCompany.DbStuff.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ArticleId")
                        .HasColumnType("int");

                    b.Property<int?>("CompanyId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

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

                    b.Property<int?>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("MemberPermissionId");

                    b.HasIndex("StatusId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ManagementCompany.DbStuff.Models.UserTask", b =>
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

            modelBuilder.Entity("ManagementCompany.DbStuff.Models.UserTaskStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Status")
                        .IsUnique();

                    b.ToTable("TaskStatuses");
                });

            modelBuilder.Entity("ProjectUser", b =>
                {
                    b.Property<int>("ExecutorsId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectsId")
                        .HasColumnType("int");

                    b.HasKey("ExecutorsId", "ProjectsId");

                    b.HasIndex("ProjectsId");

                    b.ToTable("ProjectUser");
                });

            modelBuilder.Entity("ManagementCompany.DbStuff.Models.Article", b =>
                {
                    b.HasOne("ManagementCompany.DbStuff.Models.User", "Author")
                        .WithMany("Articles")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("ManagementCompany.DbStuff.Models.Comment", b =>
                {
                    b.HasOne("ManagementCompany.DbStuff.Models.Article", null)
                        .WithMany("Comments")
                        .HasForeignKey("ArticleId");
                });

            modelBuilder.Entity("ManagementCompany.DbStuff.Models.Company", b =>
                {
                    b.HasOne("ManagementCompany.DbStuff.Models.MemberStatus", "Status")
                        .WithMany("Companies")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Status");
                });

            modelBuilder.Entity("ManagementCompany.DbStuff.Models.Project", b =>
                {
                    b.HasOne("ManagementCompany.DbStuff.Models.Company", "Company")
                        .WithMany("Projects")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("ManagementCompany.DbStuff.Models.MemberStatus", "Status")
                        .WithMany("Projects")
                        .HasForeignKey("StatusId");

                    b.Navigation("Company");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("ManagementCompany.DbStuff.Models.User", b =>
                {
                    b.HasOne("ManagementCompany.DbStuff.Models.Article", null)
                        .WithMany("Watchers")
                        .HasForeignKey("ArticleId");

                    b.HasOne("ManagementCompany.DbStuff.Models.Company", "Company")
                        .WithMany("Executors")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("ManagementCompany.DbStuff.Models.MemberPermission", "MemberPermission")
                        .WithMany("Users")
                        .HasForeignKey("MemberPermissionId");

                    b.HasOne("ManagementCompany.DbStuff.Models.MemberStatus", "Status")
                        .WithMany("Users")
                        .HasForeignKey("StatusId");

                    b.Navigation("Company");

                    b.Navigation("MemberPermission");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("ManagementCompany.DbStuff.Models.UserTask", b =>
                {
                    b.HasOne("ManagementCompany.DbStuff.Models.User", "Author")
                        .WithMany("UserCreatedTasks")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("ManagementCompany.DbStuff.Models.User", "Executor")
                        .WithMany("UserExecutedTasks")
                        .HasForeignKey("ExecutorId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("ManagementCompany.DbStuff.Models.UserTaskStatus", "Status")
                        .WithMany("UserTasks")
                        .HasForeignKey("StatusId");

                    b.Navigation("Author");

                    b.Navigation("Executor");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("ProjectUser", b =>
                {
                    b.HasOne("ManagementCompany.DbStuff.Models.User", null)
                        .WithMany()
                        .HasForeignKey("ExecutorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ManagementCompany.DbStuff.Models.Project", null)
                        .WithMany()
                        .HasForeignKey("ProjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ManagementCompany.DbStuff.Models.Article", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Watchers");
                });

            modelBuilder.Entity("ManagementCompany.DbStuff.Models.Company", b =>
                {
                    b.Navigation("Executors");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("ManagementCompany.DbStuff.Models.MemberPermission", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("ManagementCompany.DbStuff.Models.MemberStatus", b =>
                {
                    b.Navigation("Companies");

                    b.Navigation("Projects");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("ManagementCompany.DbStuff.Models.User", b =>
                {
                    b.Navigation("Articles");

                    b.Navigation("UserCreatedTasks");

                    b.Navigation("UserExecutedTasks");
                });

            modelBuilder.Entity("ManagementCompany.DbStuff.Models.UserTaskStatus", b =>
                {
                    b.Navigation("UserTasks");
                });
#pragma warning restore 612, 618
        }
    }
}
