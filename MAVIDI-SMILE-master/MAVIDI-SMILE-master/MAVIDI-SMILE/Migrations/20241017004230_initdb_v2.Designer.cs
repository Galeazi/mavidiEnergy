﻿// <auto-generated />
using System;
using MAVIDI_SMILE.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace MAVIDI_SMILE.mavidiSmile.Infrastructure.Migrations
{
    [DbContext(typeof(AppData))]
    [Migration("20241017004230_initdb_v2")]
    partial class initdb_v2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MAVIDI_SMILE.mavidiSmile.Domain.Entities.Amigo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AmigoId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("Id");

                    b.HasIndex("AmigoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("tb_amigos");
                });

            modelBuilder.Entity("MAVIDI_SMILE.mavidiSmile.Domain.Entities.Nivel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Experiencia")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("NivelAtual")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("tb_niveis");
                });

            modelBuilder.Entity("MAVIDI_SMILE.mavidiSmile.Domain.Entities.Premio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("PontuacaoNecessaria")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("Id");

                    b.ToTable("tb_premios");
                });

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
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("tb_progresso");
                });

            modelBuilder.Entity("MAVIDI_SMILE.mavidiSmile.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id");

                    b.ToTable("tb_usuarios");
                });

            modelBuilder.Entity("MAVIDI_SMILE.mavidiSmile.Domain.Entities.Amigo", b =>
                {
                    b.HasOne("MAVIDI_SMILE.mavidiSmile.Domain.Entities.Usuario", "AmigoUsuario")
                        .WithMany()
                        .HasForeignKey("AmigoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MAVIDI_SMILE.mavidiSmile.Domain.Entities.Usuario", "Usuario")
                        .WithMany("Amigos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AmigoUsuario");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("MAVIDI_SMILE.mavidiSmile.Domain.Entities.Nivel", b =>
                {
                    b.HasOne("MAVIDI_SMILE.mavidiSmile.Domain.Entities.Usuario", "Usuario")
                        .WithMany("Niveis")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("MAVIDI_SMILE.mavidiSmile.Domain.Entities.Progresso", b =>
                {
                    b.HasOne("MAVIDI_SMILE.mavidiSmile.Domain.Entities.Usuario", "Usuario")
                        .WithMany("Progresso")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("MAVIDI_SMILE.mavidiSmile.Domain.Entities.Usuario", b =>
                {
                    b.Navigation("Amigos");

                    b.Navigation("Niveis");

                    b.Navigation("Progresso");
                });
#pragma warning restore 612, 618
        }
    }
}
