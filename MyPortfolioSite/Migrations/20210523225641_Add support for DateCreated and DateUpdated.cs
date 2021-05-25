using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyPortfolioSite.Migrations
{
    public partial class AddsupportforDateCreatedandDateUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Tags",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Tags",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Projects",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Projects",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "BlogPosts",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "BlogPosts",
                type: "datetime(6)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "BlogPosts");
        }
    }
}
