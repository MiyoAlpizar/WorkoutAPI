using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkoutAPI.Migrations
{
    public partial class UserOwnWorkouts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Public",
                table: "Workouts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Workouts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Public",
                table: "Series",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Series",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Public",
                table: "Rutines",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Rutines",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_UserId",
                table: "Workouts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Series_UserId",
                table: "Series",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rutines_UserId",
                table: "Rutines",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rutines_AspNetUsers_UserId",
                table: "Rutines",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Series_AspNetUsers_UserId",
                table: "Series",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_AspNetUsers_UserId",
                table: "Workouts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rutines_AspNetUsers_UserId",
                table: "Rutines");

            migrationBuilder.DropForeignKey(
                name: "FK_Series_AspNetUsers_UserId",
                table: "Series");

            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_AspNetUsers_UserId",
                table: "Workouts");

            migrationBuilder.DropIndex(
                name: "IX_Workouts_UserId",
                table: "Workouts");

            migrationBuilder.DropIndex(
                name: "IX_Series_UserId",
                table: "Series");

            migrationBuilder.DropIndex(
                name: "IX_Rutines_UserId",
                table: "Rutines");

            migrationBuilder.DropColumn(
                name: "Public",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "Public",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "Public",
                table: "Rutines");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Rutines");
        }
    }
}
