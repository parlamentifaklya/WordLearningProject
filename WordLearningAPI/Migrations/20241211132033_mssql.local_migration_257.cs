using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WordLearningAPI.Migrations
{
    /// <inheritdoc />
    public partial class mssqllocal_migration_257 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Words",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hun = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Eng = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SucsessCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Words");
        }
    }
}
