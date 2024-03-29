﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TesteMaturidadeLinkedin.DataContext;

#nullable disable

namespace TesteMaturidadeLinkedin.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("siteProfissionalFG.Models.PessoaModel", b =>
                {
                    b.Property<int>("IdPessoa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdPessoa"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Linkedin")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NomeCompleto")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Whatsapp")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IdPessoa");

                    b.ToTable("Pessoa");
                });

            modelBuilder.Entity("siteProfissionalFG.Models.ResultadoModel", b =>
                {
                    b.Property<int>("IdResultado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdResultado"));

                    b.Property<int>("IdPessoa")
                        .HasColumnType("integer");

                    b.Property<DateTime>("RespondidoEm")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("pergunta")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("resposta")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IdResultado");

                    b.ToTable("Resultado");
                });
#pragma warning restore 612, 618
        }
    }
}
