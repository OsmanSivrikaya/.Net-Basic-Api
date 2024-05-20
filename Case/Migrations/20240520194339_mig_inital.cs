using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Case.Migrations
{
    /// <inheritdoc />
    public partial class mig_inital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Demand",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    useer_name = table.Column<string>(type: "nvarchar(254)", nullable: false),
                    complaint = table.Column<string>(type: "nvarchar(4000)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(254)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Demand", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Demand");
        }
    }
}
