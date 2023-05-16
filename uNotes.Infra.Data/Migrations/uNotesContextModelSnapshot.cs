﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using uNotes.Infra.Data.Contexto;

#nullable disable

namespace uNotes.Infra.Data.Migrations
{
    [DbContext(typeof(uNotesContext))]
    partial class uNotesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("uNotes.Domain.Entidades.Categoria", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CategoriaPai")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CriadorId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DataExclusao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Categorias");
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

                    b.Property<Guid?>("CategoriaId")
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
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UsuarioAtualizacaoId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Documentos");
                });

            modelBuilder.Entity("uNotes.Domain.Entidades.NotaDocumento", b =>
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

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("Texto")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UsuarioAtualizacaoId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("DocumentoId");

                    b.ToTable("NotasDocumento");
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

                    b.Property<int>("Status")
                        .HasColumnType("integer");

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

                    b.Property<string>("Avatar")
                        .HasColumnType("text");

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

            modelBuilder.Entity("uNotes.Domain.Entidades.UsuarioCategoria", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoriaId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("UsuariosCategorias");
                });

            modelBuilder.Entity("uNotes.Domain.Entidades.Documento", b =>
                {
                    b.HasOne("uNotes.Domain.Entidades.Categoria", "Categoria")
                        .WithMany("Documentos")
                        .HasForeignKey("CategoriaId");

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("uNotes.Domain.Entidades.NotaDocumento", b =>
                {
                    b.HasOne("uNotes.Domain.Entidades.Documento", "Documento")
                        .WithMany("Notas")
                        .HasForeignKey("DocumentoId");

                    b.Navigation("Documento");
                });

            modelBuilder.Entity("uNotes.Domain.Entidades.Usuario", b =>
                {
                    b.HasOne("uNotes.Domain.Entidades.Cargo", "Cargo")
                        .WithMany()
                        .HasForeignKey("CargoId");

                    b.Navigation("Cargo");
                });

            modelBuilder.Entity("uNotes.Domain.Entidades.UsuarioCategoria", b =>
                {
                    b.HasOne("uNotes.Domain.Entidades.Categoria", "Categoria")
                        .WithMany("Usuarios")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("uNotes.Domain.Entidades.Usuario", "Usuario")
                        .WithMany("Categorias")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("uNotes.Domain.Entidades.Categoria", b =>
                {
                    b.Navigation("Documentos");

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("uNotes.Domain.Entidades.Documento", b =>
                {
                    b.Navigation("Notas");
                });

            modelBuilder.Entity("uNotes.Domain.Entidades.Usuario", b =>
                {
                    b.Navigation("Categorias");
                });
#pragma warning restore 612, 618
        }
    }
}
