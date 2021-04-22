﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PaymentServices.Entities;

namespace PaymentServices.Migrations
{
    [DbContext(typeof(PaymentContext))]
    partial class PaymentContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PaymentServices.Entities.PaymentRequest", b =>
                {
                    b.Property<string>("CreditCardNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CardHolder")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SecurityCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CreditCardNumber");

                    b.ToTable("PaymentRequest");
                });

            modelBuilder.Entity("PaymentServices.Entities.PaymentStatus", b =>
                {
                    b.Property<int>("LogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreditCardNoCreditCardNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PaymentState")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LogId");

                    b.HasIndex("CreditCardNoCreditCardNumber");

                    b.ToTable("PaymentStatus");
                });

            modelBuilder.Entity("PaymentServices.Entities.PaymentStatus", b =>
                {
                    b.HasOne("PaymentServices.Entities.PaymentRequest", "CreditCardNo")
                        .WithMany()
                        .HasForeignKey("CreditCardNoCreditCardNumber");

                    b.Navigation("CreditCardNo");
                });
#pragma warning restore 612, 618
        }
    }
}
