using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeoCRON.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigraion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GeoInfos",
                columns: table => new
                {
                    IpLocal = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Organization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Postal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timezone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Readme = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeoInfos", x => x.IpLocal);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeoInfos");
        }
    }
}
