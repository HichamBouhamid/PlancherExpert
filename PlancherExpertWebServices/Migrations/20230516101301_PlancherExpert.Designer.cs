﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlancherExpertWebServices.Models;

#nullable disable

namespace PlancherExpertWebServices.Migrations
{
    [DbContext(typeof(CouvrePlancherDBContext))]
    [Migration("20230516101301_PlancherExpert")]
    partial class PlancherExpert
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PlancherExpertWebServices.Models.Commande", b =>
                {
                    b.Property<Guid>("CommandeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CPId")
                        .HasColumnType("int");

                    b.Property<string>("ClientData")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<double>("Largeur")
                        .HasColumnType("float");

                    b.Property<double>("Longueur")
                        .HasColumnType("float");

                    b.HasKey("CommandeId");

                    b.HasIndex("CPId");

                    b.ToTable("Commande");
                });

            modelBuilder.Entity("PlancherExpertWebServices.Models.CouvrePlancher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<float>("PrixMa")
                        .HasColumnType("real");

                    b.Property<float>("PrixMo")
                        .HasColumnType("real");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CouvrePlancher");
                });

            modelBuilder.Entity("PlancherExpertWebServices.Models.Commande", b =>
                {
                    b.HasOne("PlancherExpertWebServices.Models.CouvrePlancher", "CP")
                        .WithMany()
                        .HasForeignKey("CPId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CP");
                });
#pragma warning restore 612, 618
        }
    }
}
