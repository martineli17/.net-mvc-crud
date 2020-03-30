﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository.Context;

namespace Repository.Migrations
{
    [DbContext(typeof(ContextBase))]
    partial class ContextBaseModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Entities.Cidade", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("varchar(500)")
                        .IsUnicode(true);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnName("descricao")
                        .HasColumnType("varchar(100)")
                        .IsUnicode(false);

                    b.Property<string>("IdEstado")
                        .IsRequired()
                        .HasColumnName("idEstado")
                        .HasColumnType("varchar(500)")
                        .IsUnicode(true);

                    b.HasKey("Id");

                    b.HasIndex("Descricao");

                    b.HasIndex("Id");

                    b.HasIndex("IdEstado");

                    b.ToTable("Cidade");
                });

            modelBuilder.Entity("Domain.Entities.Estado", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("varchar(500)")
                        .IsUnicode(true);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnName("descricao")
                        .HasColumnType("varchar(100)")
                        .IsUnicode(false);

                    b.Property<string>("IdPais")
                        .IsRequired()
                        .HasColumnName("idPais")
                        .HasColumnType("varchar(500)")
                        .IsUnicode(true);

                    b.HasKey("Id");

                    b.HasIndex("Descricao");

                    b.HasIndex("Id");

                    b.HasIndex("IdPais");

                    b.ToTable("Estado");
                });

            modelBuilder.Entity("Domain.Entities.Paciente", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("varchar(500)")
                        .IsUnicode(false);

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnName("cpf")
                        .HasColumnType("varchar(11)")
                        .IsUnicode(false);

                    b.Property<string>("IdCidade")
                        .IsRequired()
                        .HasColumnName("idCidade")
                        .HasColumnType("varchar(500)")
                        .IsUnicode(true);

                    b.Property<string>("IdEstado")
                        .IsRequired()
                        .HasColumnName("idEstado")
                        .HasColumnType("varchar(500)")
                        .IsUnicode(true);

                    b.Property<string>("IdPais")
                        .IsRequired()
                        .HasColumnName("idPais")
                        .HasColumnType("varchar(500)")
                        .IsUnicode(true);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("nome")
                        .HasColumnType("varchar(100)")
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("Cpf");

                    b.HasIndex("Id");

                    b.HasIndex("IdCidade");

                    b.HasIndex("IdEstado");

                    b.HasIndex("IdPais");

                    b.ToTable("Paciente");
                });

            modelBuilder.Entity("Domain.Entities.Pais", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("varchar(500)")
                        .IsUnicode(true);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnName("descricao")
                        .HasColumnType("varchar(100)")
                        .IsUnicode(false);

                    b.Property<Guid>("IdEstado")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("Descricao");

                    b.HasIndex("Id");

                    b.ToTable("Pais");
                });

            modelBuilder.Entity("Domain.Entities.Cidade", b =>
                {
                    b.HasOne("Domain.Entities.Estado", "Estado")
                        .WithMany("Cidades")
                        .HasForeignKey("IdEstado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Estado", b =>
                {
                    b.HasOne("Domain.Entities.Pais", "Pais")
                        .WithMany("Estados")
                        .HasForeignKey("IdPais")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Paciente", b =>
                {
                    b.HasOne("Domain.Entities.Cidade", "Cidade")
                        .WithMany("Pacientes")
                        .HasForeignKey("IdCidade")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Estado", "Estado")
                        .WithMany("Pacientes")
                        .HasForeignKey("IdEstado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Pais", "Pais")
                        .WithMany("Pacientes")
                        .HasForeignKey("IdPais")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
