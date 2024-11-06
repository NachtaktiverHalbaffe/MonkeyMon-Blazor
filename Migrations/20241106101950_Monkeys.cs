using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MonkeyMon_Blazor.Migrations
{
    /// <inheritdoc />
    public partial class Monkeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Monkeys",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    KnownFrom = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Weaknesses = table.Column<string>(type: "text", nullable: true),
                    Attack = table.Column<int>(type: "integer", nullable: true),
                    Defense = table.Column<int>(type: "integer", nullable: true),
                    SpecialAttack = table.Column<int>(type: "integer", nullable: true),
                    SpecialDefense = table.Column<int>(type: "integer", nullable: true),
                    HealthPoints = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monkeys", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Monkeys");
        }
    }
}
