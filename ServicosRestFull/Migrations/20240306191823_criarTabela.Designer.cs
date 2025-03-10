﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ServicosRestFull.Models;

#nullable disable

namespace ServicosRestFull.Migrations
{
    [DbContext(typeof(MeuBanco))]
    [Migration("20240306191823_criarTabela")]
    partial class criarTabela
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ServicosRestFull.Models.Vinho", b =>
                {
                    b.Property<int>("Cod_vinho")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Cod_vinho"));

                    b.Property<int>("Idade_vinho")
                        .HasColumnType("integer");

                    b.Property<string>("Nome_vinho")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR");

                    b.Property<decimal>("Preco_vinho")
                        .HasColumnType("numeric");

                    b.HasKey("Cod_vinho");

                    b.ToTable("vinho");
                });
#pragma warning restore 612, 618
        }
    }
}
