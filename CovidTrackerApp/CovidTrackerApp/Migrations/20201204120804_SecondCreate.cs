using Microsoft.EntityFrameworkCore.Migrations;

namespace CovidTrackerApp.Migrations
{
    public partial class SecondCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CareWorker_Venue_VenueId",
                table: "CareWorker");

            migrationBuilder.DropForeignKey(
                name: "FK_Patient_Venue_VenueId",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "WorkerNum",
                table: "Venue");

            migrationBuilder.DropColumn(
                name: "Contact",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "Contact",
                table: "CareWorker");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "CareWorker");

            migrationBuilder.AddColumn<int>(
                name: "NumOfWorkers",
                table: "Venue",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "VenueName",
                table: "Venue",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VenueId",
                table: "Patient",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactNumber",
                table: "Patient",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Patient",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VenueId",
                table: "CareWorker",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactNumber",
                table: "CareWorker",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CareWorker",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CareWorker_Venue_VenueId",
                table: "CareWorker",
                column: "VenueId",
                principalTable: "Venue",
                principalColumn: "VenueId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Patient_Venue_VenueId",
                table: "Patient",
                column: "VenueId",
                principalTable: "Venue",
                principalColumn: "VenueId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CareWorker_Venue_VenueId",
                table: "CareWorker");

            migrationBuilder.DropForeignKey(
                name: "FK_Patient_Venue_VenueId",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "NumOfWorkers",
                table: "Venue");

            migrationBuilder.DropColumn(
                name: "VenueName",
                table: "Venue");

            migrationBuilder.DropColumn(
                name: "ContactNumber",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "ContactNumber",
                table: "CareWorker");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "CareWorker");

            migrationBuilder.AddColumn<int>(
                name: "WorkerNum",
                table: "Venue",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "VenueId",
                table: "Patient",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Contact",
                table: "Patient",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Patient",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "VenueId",
                table: "CareWorker",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Contact",
                table: "CareWorker",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "CareWorker",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_CareWorker_Venue_VenueId",
                table: "CareWorker",
                column: "VenueId",
                principalTable: "Venue",
                principalColumn: "VenueId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Patient_Venue_VenueId",
                table: "Patient",
                column: "VenueId",
                principalTable: "Venue",
                principalColumn: "VenueId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
