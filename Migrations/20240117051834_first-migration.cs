using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TesteMaturidadeLinkedin.Migrations
{
    /// <inheritdoc />
    public partial class firstmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    IdPessoa = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomeCompleto = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Whatsapp = table.Column<string>(type: "text", nullable: false),
                    Linkedin = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.IdPessoa);
                });

            migrationBuilder.CreateTable(
                name: "Resultado",
                columns: table => new
                {
                    IdResultado = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RespondidoEm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    pergunta = table.Column<string>(type: "text", nullable: false),
                    resposta = table.Column<string>(type: "text", nullable: false),
                    IdPessoa = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resultado", x => x.IdResultado);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pessoa");

            migrationBuilder.DropTable(
                name: "Resultado");
        }
    }
}
