using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ServicosRestFull.Migrations
{
    /// <inheritdoc />
    public partial class criarTabela : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "vinho",
                columns: table => new
                {
                    Cod_vinho = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome_vinho = table.Column<string>(type: "VARCHAR", maxLength: 100, nullable: false),
                    Idade_vinho = table.Column<int>(type: "integer", nullable: false),
                    Preco_vinho = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vinho", x => x.Cod_vinho);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "vinho");
        }
    }
}
