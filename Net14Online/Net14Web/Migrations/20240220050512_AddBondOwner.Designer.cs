﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Net14Web.DbStuff;

#nullable disable

namespace Net14Web.Migrations
{
    [DbContext(typeof(WebDbContext))]
    [Migration("20240220050512_AddBondOwner")]
    partial class AddBondOwner
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HeroWeapon", b =>
                {
                    b.Property<int>("HeroesWhoKnowsTheWeaponId")
                        .HasColumnType("int");

                    b.Property<int>("KnowedWeaponsId")
                        .HasColumnType("int");

                    b.HasKey("HeroesWhoKnowsTheWeaponId", "KnowedWeaponsId");

                    b.HasIndex("KnowedWeaponsId");

                    b.ToTable("HeroWeapon");
                });

            modelBuilder.Entity("Net14Web.DbStuff.Models.Bonds.Bond", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Bonds");
                });

            modelBuilder.Entity("Net14Web.DbStuff.Models.Bonds.Coupon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BondId")
                        .HasColumnType("int");

                    b.Property<int>("CouponSize")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BondId");

                    b.ToTable("Coupons");
                });

            modelBuilder.Entity("Net14Web.DbStuff.Models.BookingWeb.LoginBooking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OwnerId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("LoginsBooking");
                });

            modelBuilder.Entity("Net14Web.DbStuff.Models.BookingWeb.Search", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Checkin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Checkout")
                        .HasColumnType("datetime2");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LoginBookingId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LoginBookingId");

                    b.ToTable("Searches");
                });

            modelBuilder.Entity("Net14Web.DbStuff.Models.Dividend", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfReplenishment")
                        .HasColumnType("datetime2");

                    b.Property<int>("StockId")
                        .HasColumnType("int");

                    b.Property<int>("TheAmountOfTheDividend")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StockId");

                    b.ToTable("Dividend");
                });

            modelBuilder.Entity("Net14Web.DbStuff.Models.GameShop.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Genre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LogoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Raiting")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("Net14Web.DbStuff.Models.GameShop.GameComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CommentedGameId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CommentedGameId");

                    b.ToTable("GameComments");
                });

            modelBuilder.Entity("Net14Web.DbStuff.Models.Hero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AvatarUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<int>("Coins")
                        .HasColumnType("int");

                    b.Property<int?>("FavoriteWeaponId")
                        .HasColumnType("int");

                    b.Property<int>("Hp")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OwnerId")
                        .HasColumnType("int");

                    b.Property<int>("Race")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FavoriteWeaponId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Heroes");
                });

            modelBuilder.Entity("Net14Web.DbStuff.Models.InvestPort.Stock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("Net14Web.DbStuff.Models.LifeScore.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Assists")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Goals")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Net14Web.DbStuff.Models.LifeScore.SportGame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Team1Goals")
                        .HasColumnType("int");

                    b.Property<int?>("Team2Goals")
                        .HasColumnType("int");

                    b.Property<int?>("TeamIDWin")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("SportGames");
                });

            modelBuilder.Entity("Net14Web.DbStuff.Models.LifeScore.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Liga")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Net14Web.DbStuff.Models.Movies.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeOfWriting")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Net14Web.DbStuff.Models.Movies.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PosterUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("Net14Web.DbStuff.Models.Movies.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AvatarUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Net14Web.DbStuff.Models.PcShop.CpuModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Cores")
                        .HasColumnType("int");

                    b.Property<int>("Frequency")
                        .HasColumnType("int");

                    b.Property<string>("Generation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<string>("Socket")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Threads")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CpuModel");
                });

            modelBuilder.Entity("Net14Web.DbStuff.Models.PcShop.PCModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CPUId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CPUId");

                    b.ToTable("PCModel");
                });

            modelBuilder.Entity("Net14Web.DbStuff.Models.PcShop.UsersPcShop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserPcShop");
                });

            modelBuilder.Entity("Net14Web.DbStuff.Models.RetroConsoles.RetroUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RetroUsers");
                });

            modelBuilder.Entity("Net14Web.DbStuff.Models.TaskTracker.TaskInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TaskInfos");
                });

            modelBuilder.Entity("Net14Web.DbStuff.Models.Weapon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Damage")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Weapons");
                });

            modelBuilder.Entity("SportGameTeam", b =>
                {
                    b.Property<int>("GamesId")
                        .HasColumnType("int");

                    b.Property<int>("TeamsId")
                        .HasColumnType("int");

                    b.HasKey("GamesId", "TeamsId");

                    b.HasIndex("TeamsId");

                    b.ToTable("SportGameTeam");
                });

            modelBuilder.Entity("HeroWeapon", b =>
                {
                    b.HasOne("Net14Web.DbStuff.Models.Hero", null)
                        .WithMany()
                        .HasForeignKey("HeroesWhoKnowsTheWeaponId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Net14Web.DbStuff.Models.Weapon", null)
                        .WithMany()
                        .HasForeignKey("KnowedWeaponsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Net14Web.DbStuff.Models.Bonds.Bond", b =>
                {
                    b.HasOne("Net14Web.DbStuff.Models.Movies.User", "Owner")
                        .WithMany("Bonds")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Net14Web.DbStuff.Models.Bonds.Coupon", b =>
                {
                    b.HasOne("Net14Web.DbStuff.Models.Bonds.Bond", "Bond")
                        .WithMany("Coupons")
                        .HasForeignKey("BondId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bond");
                });

            modelBuilder.Entity("Net14Web.DbStuff.Models.BookingWeb.LoginBooking", b =>
                {
                    b.HasOne("Net14Web.DbStuff.Models.Movies.User", "Owner")
                        .WithMany("LoginsBooking")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Net14Web.DbStuff.Models.BookingWeb.Search", b =>
                {
                    b.HasOne("Net14Web.DbStuff.Models.BookingWeb.LoginBooking", "LoginBooking")
                        .WithMany("Searches")
                        .HasForeignKey("LoginBookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LoginBooking");
                });

            modelBuilder.Entity("Net14Web.DbStuff.Models.Dividend", b =>
                {
                    b.HasOne("Net14Web.DbStuff.Models.InvestPort.Stock", "Stock")
                        .WithMany()
                        .HasForeignKey("StockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stock");
                });

            modelBuilder.Entity("Net14Web.DbStuff.Models.GameShop.GameComment", b =>
                {
                    b.HasOne("Net14Web.DbStuff.Models.GameShop.Game", "CommentedGame")
                        .WithMany("Comments")
                        .HasForeignKey("CommentedGameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CommentedGame");
                });

            modelBuilder.Entity("Net14Web.DbStuff.Models.Hero", b =>
                {
                    b.HasOne("Net14Web.DbStuff.Models.Weapon", "FavoriteWeapon")
                        .WithMany("HeroesWhoLikeTheWeapon")
                        .HasForeignKey("FavoriteWeaponId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Net14Web.DbStuff.Models.Movies.User", "Owner")
                        .WithMany("MyHeroes")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("FavoriteWeapon");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Net14Web.DbStuff.Models.LifeScore.Player", b =>
                {
                    b.HasOne("Net14Web.DbStuff.Models.LifeScore.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("Net14Web.DbStuff.Models.Movies.Comment", b =>
                {
                    b.HasOne("Net14Web.DbStuff.Models.Movies.Movie", "Movie")
                        .WithMany("Comments")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Net14Web.DbStuff.Models.Movies.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Net14Web.DbStuff.Models.PcShop.PCModel", b =>
                {
                    b.HasOne("Net14Web.DbStuff.Models.PcShop.CpuModel", "CPU")
                        .WithMany()
                        .HasForeignKey("CPUId");

                    b.Navigation("CPU");
                });

            modelBuilder.Entity("SportGameTeam", b =>
                {
                    b.HasOne("Net14Web.DbStuff.Models.LifeScore.SportGame", null)
                        .WithMany()
                        .HasForeignKey("GamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Net14Web.DbStuff.Models.LifeScore.Team", null)
                        .WithMany()
                        .HasForeignKey("TeamsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Net14Web.DbStuff.Models.Bonds.Bond", b =>
                {
                    b.Navigation("Coupons");
                });

            modelBuilder.Entity("Net14Web.DbStuff.Models.BookingWeb.LoginBooking", b =>
                {
                    b.Navigation("Searches");
                });

            modelBuilder.Entity("Net14Web.DbStuff.Models.GameShop.Game", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("Net14Web.DbStuff.Models.LifeScore.Team", b =>
                {
                    b.Navigation("Players");
                });

            modelBuilder.Entity("Net14Web.DbStuff.Models.Movies.Movie", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("Net14Web.DbStuff.Models.Movies.User", b =>
                {
                    b.Navigation("Bonds");

                    b.Navigation("Comments");

                    b.Navigation("LoginsBooking");

                    b.Navigation("MyHeroes");
                });

            modelBuilder.Entity("Net14Web.DbStuff.Models.Weapon", b =>
                {
                    b.Navigation("HeroesWhoLikeTheWeapon");
                });
#pragma warning restore 612, 618
        }
    }
}
