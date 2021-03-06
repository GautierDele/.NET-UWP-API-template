﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebApp.Models.EntityFramework;

namespace WebApp.Migrations
{
    [DbContext(typeof(DSDBContext))]
    [Migration("20201008141549_init_db")]
    partial class init_db
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("WebApp.Models.EntityFramework.Telephone", b =>
                {
                    b.Property<int>("TelephoneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("TEL_ID")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DateSortie")
                        .HasColumnName("TEL_DATESORTIE")
                        .HasColumnType("date");

                    b.Property<string>("Marque")
                        .HasColumnName("TEL_MARQUE")
                        .HasColumnType("text");

                    b.Property<int>("Memoire")
                        .HasColumnName("TEL_MEMOIRE")
                        .HasColumnType("integer");

                    b.Property<string>("Modele")
                        .HasColumnName("TEL_MODELE")
                        .HasColumnType("text");

                    b.Property<string>("Reference")
                        .HasColumnName("TEL_REFERENCE")
                        .HasColumnType("char(5)");

                    b.HasKey("TelephoneId");

                    b.ToTable("T_E_TELEPHONE_TEL");
                });
#pragma warning restore 612, 618
        }
    }
}
