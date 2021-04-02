using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkoutAPI.Migrations
{
    public partial class WorkoutImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Workouts_WorkoutId",
                table: "Images");

            migrationBuilder.DropTable(
                name: "WorkoutImages");

            migrationBuilder.AlterColumn<int>(
                name: "WorkoutId",
                table: "Images",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Workouts_WorkoutId",
                table: "Images",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Workouts_WorkoutId",
                table: "Images");

            migrationBuilder.AlterColumn<int>(
                name: "WorkoutId",
                table: "Images",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "WorkoutImages",
                columns: table => new
                {
                    WorkoutId = table.Column<int>(type: "int", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutImages", x => new { x.WorkoutId, x.ImageId });
                    table.ForeignKey(
                        name: "FK_WorkoutImages_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkoutImages_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutImages_ImageId",
                table: "WorkoutImages",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Workouts_WorkoutId",
                table: "Images",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
