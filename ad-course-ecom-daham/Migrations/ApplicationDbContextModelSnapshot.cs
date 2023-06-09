﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ad_course_ecom_daham.Data;

#nullable disable

namespace ad_course_ecom_daham.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ad_course_ecom_daham.Models.CustomerModels.Customer", b =>
                {
                    b.Property<Guid>("cId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("cBillingAddress")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("cBirthDay")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("cEmail")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("cGender")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("cName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("cNic")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("cNumber")
                        .HasColumnType("int");

                    b.Property<string>("cPassword")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("cPayCardNum")
                        .HasColumnType("int");

                    b.Property<int>("cPayCvs")
                        .HasColumnType("int");

                    b.Property<int>("cPayExpDate")
                        .HasColumnType("int");

                    b.Property<string>("cShippingAddress")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("cId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("ad_course_ecom_daham.Models.Order", b =>
                {
                    b.Property<Guid>("oId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("cId")
                        .HasColumnType("char(36)");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("totalPrice")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("totalQty")
                        .HasColumnType("int");

                    b.HasKey("oId");

                    b.HasIndex("cId");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("ad_course_ecom_daham.Models.OrderItem", b =>
                {
                    b.Property<Guid>("orId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("comId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("oId")
                        .HasColumnType("char(36)");

                    b.Property<int>("qty")
                        .HasColumnType("int");

                    b.HasKey("orId");

                    b.HasIndex("comId");

                    b.HasIndex("oId");

                    b.ToTable("orderItems");
                });

            modelBuilder.Entity("ad_course_ecom_daham.Models.Product.Category", b =>
                {
                    b.Property<Guid>("cateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("cateName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("cateId");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("ad_course_ecom_daham.Models.Product.Computer", b =>
                {
                    b.Property<Guid>("comId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("cImage")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("cName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("cateId")
                        .HasColumnType("char(36)");

                    b.Property<decimal>("normalPrice")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("qty")
                        .HasColumnType("int");

                    b.Property<Guid>("seriesId")
                        .HasColumnType("char(36)");

                    b.HasKey("comId");

                    b.HasIndex("cateId");

                    b.HasIndex("seriesId");

                    b.ToTable("computers");
                });

            modelBuilder.Entity("ad_course_ecom_daham.Models.Product.ComVariation", b =>
                {
                    b.Property<Guid>("comvId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("comId")
                        .HasColumnType("char(36)");

                    b.Property<string>("comvName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("comvId");

                    b.HasIndex("comId");

                    b.ToTable("comVariations");
                });

            modelBuilder.Entity("ad_course_ecom_daham.Models.Product.ComVariationOption", b =>
                {
                    b.Property<Guid>("comvopId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("comvId")
                        .HasColumnType("char(36)");

                    b.Property<string>("comvopName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("price")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.HasKey("comvopId");

                    b.HasIndex("comvId");

                    b.ToTable("comVariationOptions");
                });

            modelBuilder.Entity("ad_course_ecom_daham.Models.Product.Series", b =>
                {
                    b.Property<Guid>("seriesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("cateId")
                        .HasColumnType("char(36)");

                    b.Property<string>("seriesName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("seriesId");

                    b.HasIndex("cateId");

                    b.ToTable("series");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ad_course_ecom_daham.Models.Order", b =>
                {
                    b.HasOne("ad_course_ecom_daham.Models.CustomerModels.Customer", "customer")
                        .WithMany()
                        .HasForeignKey("cId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("customer");
                });

            modelBuilder.Entity("ad_course_ecom_daham.Models.OrderItem", b =>
                {
                    b.HasOne("ad_course_ecom_daham.Models.Product.Computer", "computer")
                        .WithMany()
                        .HasForeignKey("comId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ad_course_ecom_daham.Models.Order", "order")
                        .WithMany()
                        .HasForeignKey("oId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("computer");

                    b.Navigation("order");
                });

            modelBuilder.Entity("ad_course_ecom_daham.Models.Product.Computer", b =>
                {
                    b.HasOne("ad_course_ecom_daham.Models.Product.Category", "category")
                        .WithMany()
                        .HasForeignKey("cateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ad_course_ecom_daham.Models.Product.Series", "series")
                        .WithMany()
                        .HasForeignKey("seriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("category");

                    b.Navigation("series");
                });

            modelBuilder.Entity("ad_course_ecom_daham.Models.Product.ComVariation", b =>
                {
                    b.HasOne("ad_course_ecom_daham.Models.Product.Computer", "computer")
                        .WithMany()
                        .HasForeignKey("comId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("computer");
                });

            modelBuilder.Entity("ad_course_ecom_daham.Models.Product.ComVariationOption", b =>
                {
                    b.HasOne("ad_course_ecom_daham.Models.Product.ComVariation", "comVariation")
                        .WithMany()
                        .HasForeignKey("comvId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("comVariation");
                });

            modelBuilder.Entity("ad_course_ecom_daham.Models.Product.Series", b =>
                {
                    b.HasOne("ad_course_ecom_daham.Models.Product.Category", "category")
                        .WithMany()
                        .HasForeignKey("cateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("category");
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
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
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

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
