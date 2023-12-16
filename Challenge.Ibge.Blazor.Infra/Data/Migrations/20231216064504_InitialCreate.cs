using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Challenge.Ibge.Blazor.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "IBGE",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "CHAR(7)", nullable: false),
                    State = table.Column<string>(type: "CHAR(2)", maxLength: 2, nullable: true),
                    City = table.Column<string>(type: "NVARCHAR(80)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IBGE", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IBGE",
                schema: "dbo");
        }
    }
}
