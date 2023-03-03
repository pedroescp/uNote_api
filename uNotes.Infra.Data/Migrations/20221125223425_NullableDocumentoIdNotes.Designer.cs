﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using uNotes.Infra.Data.Contexto;

#nullable disable

namespace uNotes.Infra.Data.Migrations
{
    [DbContext(typeof(uNotesContext))]
    [Migration("20221125223425_NullableDocumentoIdNotes")]
    partial class NullableDocumentoIdNotes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("uNotes.Domain.Entidades.Cargo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DataExclusao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Cargos");
                });

            modelBuilder.Entity("uNotes.Domain.Entidades.Colaboradores", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DataExclusao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("DocumentoId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NotaId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UsuarioId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Colaboradores");
                });

            modelBuilder.Entity("uNotes.Domain.Entidades.Documento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CriadorId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DataExclusao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("Lixeira")
                        .HasColumnType("boolean");

                    b.Property<string>("Texto")
                        .HasColumnType("text");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UsuarioAtualizacaoId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Documentos");
                });

            modelBuilder.Entity("uNotes.Domain.Entidades.Grupo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DataExclusao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Grupos");
                });

            modelBuilder.Entity("uNotes.Domain.Entidades.Notes", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CriadorId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DataExclusao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("DocumentoId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Fixado")
                        .HasColumnType("boolean");

                    b.Property<bool>("Lixeira")
                        .HasColumnType("boolean");

                    b.Property<string>("Texto")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UsuarioAtualizacaoId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("uNotes.Domain.Entidades.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("uNotes.Domain.Entidades.TagsNotas", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("NotaId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TagId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("TagsNotas");
                });

            modelBuilder.Entity("uNotes.Domain.Entidades.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("Avatar")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CargoId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DataExclusao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Telefone")
                        .HasColumnType("text");

                    b.Property<Guid>("UsuarioPaiId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CargoId");

                    b.ToTable("Usuario", (string)null);
                });

            modelBuilder.Entity("uNotes.Domain.Entidades.UsuarioGrupo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DataExclusao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("GrupoId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("GrupoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("UsuariosGrupos");
                });

            modelBuilder.Entity("uNotes.Domain.Entidades.Usuario", b =>
                {
                    b.HasOne("uNotes.Domain.Entidades.Cargo", "Cargo")
                        .WithMany()
                        .HasForeignKey("CargoId");

                    b.Navigation("Cargo");
                });

            modelBuilder.Entity("uNotes.Domain.Entidades.UsuarioGrupo", b =>
                {
                    b.HasOne("uNotes.Domain.Entidades.Grupo", "Grupo")
                        .WithMany("Vinculos")
                        .HasForeignKey("GrupoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("uNotes.Domain.Entidades.Usuario", "Usuario")
                        .WithMany("Grupos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grupo");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("uNotes.Domain.Entidades.Grupo", b =>
                {
                    b.Navigation("Vinculos");
                });

            modelBuilder.Entity("uNotes.Domain.Entidades.Usuario", b =>
                {
                    b.Navigation("Grupos");
                });
#pragma warning restore 612, 618
        }
    }
}
