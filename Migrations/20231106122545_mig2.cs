﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityTest.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TuttuguTakim",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TuttuguTakim",
                table: "AspNetUsers");
        }
    }
}
