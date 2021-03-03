using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Petshop.Api.Persistence.Migrations
{
    public partial class NovaMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accommodations_Animals_AnimalId",
                table: "Accommodations");

            migrationBuilder.DropIndex(
                name: "IX_Accommodations_AnimalId",
                table: "Accommodations");

            migrationBuilder.DropColumn(
                name: "AnimalId",
                table: "Accommodations");

            migrationBuilder.AlterColumn<string>(
                name: "ReasonHospitalization",
                table: "Animals",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Animals",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Animals",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HealthCondition",
                table: "Animals",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "GuardianPhone",
                table: "Animals",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GuardianName",
                table: "Animals",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GuardianAddress",
                table: "Animals",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Animals",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "AccommodationId",
                table: "Animals",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Accommodations",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AccommodationStatus",
                table: "Accommodations",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Accommodations",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_AccommodationId",
                table: "Animals",
                column: "AccommodationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Accommodations_AccommodationId",
                table: "Animals",
                column: "AccommodationId",
                principalTable: "Accommodations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Accommodations_AccommodationId",
                table: "Animals");

            migrationBuilder.DropIndex(
                name: "IX_Animals_AccommodationId",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "AccommodationId",
                table: "Animals");

            migrationBuilder.AlterColumn<string>(
                name: "ReasonHospitalization",
                table: "Animals",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Animals",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Animals",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HealthCondition",
                table: "Animals",
                type: "int",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "GuardianPhone",
                table: "Animals",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GuardianName",
                table: "Animals",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GuardianAddress",
                table: "Animals",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Animals",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Accommodations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AccommodationStatus",
                table: "Accommodations",
                type: "int",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Accommodations",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "AnimalId",
                table: "Accommodations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Accommodations_AnimalId",
                table: "Accommodations",
                column: "AnimalId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Accommodations_Animals_AnimalId",
                table: "Accommodations",
                column: "AnimalId",
                principalTable: "Animals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
