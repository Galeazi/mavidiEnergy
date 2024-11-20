﻿// <auto-generated />
using System;
using MAVIDI_SMILE.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace MAVIDI_SMILE.mavidiSmile.Infrastructure.Migrations
{
    [DbContext(typeof(AppData))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            // Configuração da entidade Usuario
            modelBuilder.Entity("MAVIDI_SMILE.mavidiSmile.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("TIMESTAMP(7)");

                    b.HasKey("Id");

                    b.ToTable("tb_usuarios");
                });

            // Configuração da entidade Progresso
            modelBuilder.Entity("MAVIDI_SMILE.mavidiSmile.Domain.Entities.Progresso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Atividade")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTime>("Data")
                        .IsRequired()
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("tb_progresso");

                    b.HasOne("MAVIDI_SMILE.mavidiSmile.Domain.Entities.Usuario", "Usuario")
                        .WithMany("Progresso")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            // Configuração da entidade Amigo
            modelBuilder.Entity("MAVIDI_SMILE.mavidiSmile.Domain.Entities.Amigo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("UsuarioId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("AmigoId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.HasIndex("AmigoId");

                    b.ToTable("tb_amigos");

                    b.HasOne("MAVIDI_SMILE.mavidiSmile.Domain.Entities.Usuario", "Usuario")
                        .WithMany("Amigos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MAVIDI_SMILE.mavidiSmile.Domain.Entities.Usuario", "AmigoUsuario")
                        .WithMany()
                        .HasForeignKey("AmigoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");

                    b.Navigation("AmigoUsuario");
                });

            // Configuração da entidade Nivel
            modelBuilder.Entity("MAVIDI_SMILE.mavidiSmile.Domain.Entities.Nivel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("NivelAtual")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("Experiencia")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("tb_niveis");

                    b.HasOne("MAVIDI_SMILE.mavidiSmile.Domain.Entities.Usuario", "Usuario")
                        .WithMany("Niveis")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            // Configuração da entidade Premio
            modelBuilder.Entity("MAVIDI_SMILE.mavidiSmile.Domain.Entities.Premio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Descricao")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("PontuacaoNecessaria")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("Id");

                    b.ToTable("tb_premios");
                });

            // Definição de relacionamentos
            modelBuilder.Entity("MAVIDI_SMILE.mavidiSmile.Domain.Entities.Usuario", b =>
                {
                    b.Navigation("Progresso");

                    b.Navigation("Niveis");

                    b.Navigation("Amigos");
                });
#pragma warning restore 612, 618
        }
    }
}