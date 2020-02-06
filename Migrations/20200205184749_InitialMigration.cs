using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nordlys.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(maxLength: 20, nullable: true),
                    rank = table.Column<sbyte>(nullable: false),
                    signed_up = table.Column<DateTime>(nullable: false),
                    email = table.Column<string>(maxLength: 50, nullable: true),
                    date_of_birth = table.Column<string>(nullable: true),
                    motto = table.Column<string>(maxLength: 40, nullable: true),
                    figure = table.Column<string>(maxLength: 90, nullable: true),
                    gender = table.Column<string>(maxLength: 1, nullable: true),
                    coins = table.Column<int>(nullable: false),
                    achievement_points = table.Column<int>(nullable: false),
                    authentication_ticket = table.Column<string>(maxLength: 70, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
