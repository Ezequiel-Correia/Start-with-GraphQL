using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_GraphQL.Migrations
{
    /// <inheritdoc />
    public partial class AlterandocolunasdatabelaBooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Authors");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Authors",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Authors");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Authors",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
