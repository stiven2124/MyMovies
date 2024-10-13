using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyMovies.Migrations
{
    /// <inheritdoc />
    public partial class AddReleaseDateToMovie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "genre",
                table: "Movies",
                newName: "Genre");

            migrationBuilder.RenameColumn(
                name: "AverageRting",
                table: "Movies",
                newName: "AverageRating");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Genre",
                table: "Movies",
                newName: "genre");

            migrationBuilder.RenameColumn(
                name: "AverageRating",
                table: "Movies",
                newName: "AverageRting");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Movies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
