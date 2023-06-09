﻿// <auto-generated />
using System;
using LibreriaAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LibreriaAPI.Migrations
{
    [DbContext(typeof(LibreriaDbContext))]
    partial class LibreriaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("LibreriaAPI.Models.Domain.Categoria", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Categorie");
                });

            modelBuilder.Entity("LibreriaAPI.Models.Domain.Documento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("AnnoDiRilascio")
                        .HasColumnType("int");

                    b.Property<Guid>("CategoriaId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Icona")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("MarchioId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("StatoId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("TipologiaId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("MarchioId");

                    b.HasIndex("StatoId");

                    b.HasIndex("TipologiaId");

                    b.ToTable("Documenti");
                });

            modelBuilder.Entity("LibreriaAPI.Models.Domain.Marchio", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Marchi");
                });

            modelBuilder.Entity("LibreriaAPI.Models.Domain.Stato", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Descrizione")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Stati");
                });

            modelBuilder.Entity("LibreriaAPI.Models.Domain.Tipologia", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Tipologie");
                });

            modelBuilder.Entity("LibreriaAPI.Models.Domain.Documento", b =>
                {
                    b.HasOne("LibreriaAPI.Models.Domain.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibreriaAPI.Models.Domain.Marchio", "Marchio")
                        .WithMany()
                        .HasForeignKey("MarchioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibreriaAPI.Models.Domain.Stato", "Stato")
                        .WithMany()
                        .HasForeignKey("StatoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibreriaAPI.Models.Domain.Tipologia", "Tipologia")
                        .WithMany()
                        .HasForeignKey("TipologiaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Marchio");

                    b.Navigation("Stato");

                    b.Navigation("Tipologia");
                });
#pragma warning restore 612, 618
        }
    }
}
