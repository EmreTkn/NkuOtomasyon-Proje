using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class AddLessonTypeFromLessons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "LessonType",
                table: "Lessons",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfLessonTaken",
                table: "Grades",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LessonType",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "NumberOfLessonTaken",
                table: "Grades");
        }
    }
}
