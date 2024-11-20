using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MAVIDI_ENERGY.Infrastructure.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Email = table.Column<string>(maxLength: 150, nullable: false),
                    PasswordHash = table.Column<string>(maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                }
            );

            // Tabela EnergyUsage
            migrationBuilder.CreateTable(
                name: "EnergyUsages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    MonthlyConsumption = table.Column<decimal>(nullable: false),
                    Region = table.Column<string>(maxLength: 100, nullable: false),
                    EstimatedCost = table.Column<decimal>(nullable: false),
                    CO2Emissions = table.Column<decimal>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnergyUsages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnergyUsages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                }
            );
            
            migrationBuilder.CreateTable(
                name: "SolarProviders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 150, nullable: false),
                    Location = table.Column<string>(maxLength: 100, nullable: false),
                    ContactInfo = table.Column<string>(maxLength: 255, nullable: false),
                    Rating = table.Column<decimal>(type: "decimal(3,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolarProviders", x => x.Id);
                }
            );
            
            migrationBuilder.CreateIndex(
                name: "IX_EnergyUsages_UserId",
                table: "EnergyUsages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SolarProviders");

            migrationBuilder.DropTable(
                name: "EnergyUsages");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
