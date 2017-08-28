using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NoteTaking.DataAccess.EfCore.Migrations
{
    public partial class _02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeStamp",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "TimeStamp",
                table: "Notes");

            migrationBuilder.AddColumn<byte[]>(
                name: "ConcurrencyToken",
                table: "Users",
                type: "bytea",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ConcurrencyToken",
                table: "Notes",
                type: "bytea",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Notes",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Notes",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Notes",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConcurrencyToken",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ConcurrencyToken",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "Notes");

            migrationBuilder.AddColumn<byte[]>(
                name: "TimeStamp",
                table: "Users",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Notes",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "TimeStamp",
                table: "Notes",
                rowVersion: true,
                nullable: true);
        }
    }
}
