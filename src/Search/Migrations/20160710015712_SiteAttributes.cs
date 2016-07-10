using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Search.Migrations
{
    public partial class SiteAttributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Uri",
                table: "Sites",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Sites",
                maxLength: 50,
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Uri",
                table: "Sites",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Sites",
                nullable: true);
        }
    }
}
