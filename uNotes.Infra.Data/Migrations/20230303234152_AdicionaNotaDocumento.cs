using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace uNotes.Infra.Data.Migrations
{
    public partial class AdicionaNotaDocumento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentoId",
                table: "Notes");

            migrationBuilder.CreateTable(
                name: "NotasDocumento",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Titulo = table.Column<string>(type: "text", nullable: false),
                    Texto = table.Column<string>(type: "text", nullable: false),
                    CriadorId = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    UsuarioAtualizacaoId = table.Column<Guid>(type: "uuid", nullable: false),
                    DocumentoId = table.Column<Guid>(type: "uuid", nullable: true),
                    DataInclusao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DataExclusao = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotasDocumento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotasDocumento_Documentos_DocumentoId",
                        column: x => x.DocumentoId,
                        principalTable: "Documentos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_NotasDocumento_DocumentoId",
                table: "NotasDocumento",
                column: "DocumentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotasDocumento");

            migrationBuilder.AddColumn<Guid>(
                name: "DocumentoId",
                table: "Notes",
                type: "uuid",
                nullable: true);
        }
    }
}
