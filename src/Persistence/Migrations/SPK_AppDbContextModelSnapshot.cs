﻿// <auto-generated />
using System;
using Academie.PawnShop.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Academie.PawnShop.Persistence.Migrations
{
    [DbContext(typeof(PawnShopDbContext))]
    partial class SPK_AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Academie.PawnShop.Domain.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate");

                    b.Property<DateTime?>("DeleteDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("LastUpdateDate");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Academie.PawnShop.Domain.Entities.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate");

                    b.Property<DateTime?>("DeleteDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<Guid?>("JobTitleId");

                    b.Property<string>("LastName");

                    b.Property<DateTime?>("LastUpdateDate");

                    b.Property<string>("Name");

                    b.Property<float>("Salary");

                    b.HasKey("Id");

                    b.HasIndex("JobTitleId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Academie.PawnShop.Domain.Entities.EmployeePay", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate");

                    b.Property<DateTime?>("DeleteDate");

                    b.Property<Guid>("EmployeeId");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("LastUpdateDate");

                    b.Property<Guid>("PayId");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("PayId");

                    b.ToTable("EmployeePay");
                });

            modelBuilder.Entity("Academie.PawnShop.Domain.Entities.JobTitle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate");

                    b.Property<DateTime?>("DeleteDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("LastUpdateDate");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("JobTitles");
                });

            modelBuilder.Entity("Academie.PawnShop.Domain.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Client");

                    b.Property<DateTime>("CreationDate");

                    b.Property<DateTime?>("DeleteDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("LastUpdateDate");

                    b.Property<float>("Total");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Academie.PawnShop.Domain.Entities.OrderEntry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate");

                    b.Property<DateTime?>("DeleteDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("LastUpdateDate");

                    b.Property<Guid>("OrderId");

                    b.Property<Guid>("ProductId");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderEntry");
                });

            modelBuilder.Entity("Academie.PawnShop.Domain.Entities.Pay", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate");

                    b.Property<DateTime?>("DeleteDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("LastUpdateDate");

                    b.Property<float>("TotalPay");

                    b.HasKey("Id");

                    b.ToTable("Pay");
                });

            modelBuilder.Entity("Academie.PawnShop.Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate");

                    b.Property<DateTime?>("DeleteDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("LastUpdateDate");

                    b.Property<string>("Name");

                    b.Property<double>("Price");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Academie.PawnShop.Domain.Entities.ProductCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CategoryId");

                    b.Property<DateTime>("CreationDate");

                    b.Property<DateTime?>("DeleteDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("LastUpdateDate");

                    b.Property<Guid>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductCategory");
                });

            modelBuilder.Entity("Academie.PawnShop.Domain.Entities.Role", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Academie.PawnShop.Domain.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Academie.PawnShop.Domain.Entities.Employee", b =>
                {
                    b.HasOne("Academie.PawnShop.Domain.Entities.JobTitle", "JobTitle")
                        .WithMany()
                        .HasForeignKey("JobTitleId");

                    b.OwnsOne("Academie.PawnShop.Domain.Entities.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("EmployeeId");

                            b1.Property<string>("City");

                            b1.Property<string>("PostalCode");

                            b1.Property<string>("Street");

                            b1.HasKey("EmployeeId");

                            b1.ToTable("Employees");

                            b1.HasOne("Academie.PawnShop.Domain.Entities.Employee")
                                .WithOne("Address")
                                .HasForeignKey("Academie.PawnShop.Domain.Entities.Address", "EmployeeId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("Academie.PawnShop.Domain.Entities.EmployeePay", b =>
                {
                    b.HasOne("Academie.PawnShop.Domain.Entities.Employee", "Employee")
                        .WithMany("Pay")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Academie.PawnShop.Domain.Entities.Pay", "Pay")
                        .WithMany("Employees")
                        .HasForeignKey("PayId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Academie.PawnShop.Domain.Entities.OrderEntry", b =>
                {
                    b.HasOne("Academie.PawnShop.Domain.Entities.Order", "Order")
                        .WithMany("Entries")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Academie.PawnShop.Domain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Academie.PawnShop.Domain.Entities.ProductCategory", b =>
                {
                    b.HasOne("Academie.PawnShop.Domain.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Academie.PawnShop.Domain.Entities.Product", "Product")
                        .WithMany("Categories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Academie.PawnShop.Domain.Entities.User", b =>
                {
                    b.OwnsOne("Academie.PawnShop.Domain.Entities.Address", "Address", b1 =>
                        {
                            b1.Property<string>("UserId");

                            b1.Property<string>("City");

                            b1.Property<string>("PostalCode");

                            b1.Property<string>("Street");

                            b1.HasKey("UserId");

                            b1.ToTable("AspNetUsers");

                            b1.HasOne("Academie.PawnShop.Domain.Entities.User")
                                .WithOne("Address")
                                .HasForeignKey("Academie.PawnShop.Domain.Entities.Address", "UserId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Academie.PawnShop.Domain.Entities.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Academie.PawnShop.Domain.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Academie.PawnShop.Domain.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Academie.PawnShop.Domain.Entities.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Academie.PawnShop.Domain.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Academie.PawnShop.Domain.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
