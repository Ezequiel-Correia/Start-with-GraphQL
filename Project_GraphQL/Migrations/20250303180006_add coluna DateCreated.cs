using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_GraphQL.Migrations
{
    /// <inheritdoc />
    public partial class addcolunaDateCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Books",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Books");
        }
    }
}
