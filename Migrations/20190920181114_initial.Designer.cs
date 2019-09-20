﻿// <auto-generated />
using Bar.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Bar.Migrations
{
    [DbContext(typeof(BarContext))]
    [Migration("20190920181114_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Bar.Models.BarMenu", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DrinkDescription");

                    b.Property<string>("DrinkName");

                    b.Property<decimal>("Price");

                    b.Property<int>("Quantity");

                    b.HasKey("ID");

                    b.ToTable("BarMenu");
                });

            modelBuilder.Entity("Bar.Models.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomerName");

                    b.Property<int>("MenuID");

                    b.Property<int>("QuantityOfBeers");

                    b.Property<decimal>("Total");

                    b.HasKey("ID");

                    b.HasIndex("MenuID")
                        .IsUnique();

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Bar.Models.Order", b =>
                {
                    b.HasOne("Bar.Models.BarMenu", "BarMenu")
                        .WithOne("Order")
                        .HasForeignKey("Bar.Models.Order", "MenuID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}