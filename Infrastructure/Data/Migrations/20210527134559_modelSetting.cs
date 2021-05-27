using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class modelSetting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Faculties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FacultyName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Semesters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SemesterName = table.Column<string>(nullable: true),
                    Year = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semesters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudyTimes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyTimes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudyPrograms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProgramName = table.Column<string>(nullable: true),
                    FacultyId = table.Column<int>(nullable: true),
                    StudyTimeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyPrograms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudyPrograms_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudyPrograms_StudyTimes_StudyTimeId",
                        column: x => x.StudyTimeId,
                        principalTable: "StudyTimes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Classrooms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClassRoomCode = table.Column<string>(nullable: true),
                    ClassRoomName = table.Column<string>(nullable: true),
                    StudyProgramId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classrooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Classrooms_StudyPrograms_StudyProgramId",
                        column: x => x.StudyProgramId,
                        principalTable: "StudyPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentAffairs",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    FacultyId = table.Column<int>(nullable: true),
                    StudyProgramId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAffairs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentAffairs_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentAffairs_StudyPrograms_StudyProgramId",
                        column: x => x.StudyProgramId,
                        principalTable: "StudyPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    SchoolNumber = table.Column<string>(nullable: true),
                    RegistrationTime = table.Column<DateTime>(nullable: false),
                    SemesterId = table.Column<int>(nullable: true),
                    StudyProgramId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Semesters_SemesterId",
                        column: x => x.SemesterId,
                        principalTable: "Semesters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_StudyPrograms_StudyProgramId",
                        column: x => x.StudyProgramId,
                        principalTable: "StudyPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    StudyProgramId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teachers_StudyPrograms_StudyProgramId",
                        column: x => x.StudyProgramId,
                        principalTable: "StudyPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StudentId = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    PublicId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentPersonalityInformations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StudentId = table.Column<string>(nullable: true),
                    TcNumber = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: false),
                    BirthCity = table.Column<string>(nullable: true),
                    Nationality = table.Column<string>(nullable: true),
                    MilitaryStatus = table.Column<bool>(nullable: false),
                    MotherName = table.Column<string>(nullable: true),
                    FatherName = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: false),
                    MaritalStatus = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentPersonalityInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentPersonalityInformations_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    LessonCode = table.Column<string>(nullable: false),
                    Akts = table.Column<int>(nullable: false),
                    TheoryTime = table.Column<int>(nullable: false),
                    PracticeTime = table.Column<int>(nullable: false),
                    LessonName = table.Column<string>(nullable: true),
                    ExamDate = table.Column<DateTime>(nullable: false),
                    MidTermTime = table.Column<DateTime>(nullable: false),
                    FinalExamTime = table.Column<DateTime>(nullable: false),
                    MakeUpExamTime = table.Column<DateTime>(nullable: false),
                    LessonClassRoomId = table.Column<int>(nullable: true),
                    ExamClassRoomId = table.Column<int>(nullable: true),
                    StudyTime = table.Column<DateTime>(nullable: false),
                    LessonDay = table.Column<string>(nullable: true),
                    LessonStartHour = table.Column<int>(nullable: false),
                    LessonofNumber = table.Column<int>(nullable: false),
                    TeacherId = table.Column<string>(nullable: true),
                    SemesterId = table.Column<int>(nullable: true),
                    StudyProgramId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.LessonCode);
                    table.ForeignKey(
                        name: "FK_Lessons_Classrooms_ExamClassRoomId",
                        column: x => x.ExamClassRoomId,
                        principalTable: "Classrooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lessons_Classrooms_LessonClassRoomId",
                        column: x => x.LessonClassRoomId,
                        principalTable: "Classrooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lessons_Semesters_SemesterId",
                        column: x => x.SemesterId,
                        principalTable: "Semesters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lessons_StudyPrograms_StudyProgramId",
                        column: x => x.StudyProgramId,
                        principalTable: "StudyPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lessons_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentInformations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StudentId = table.Column<string>(nullable: true),
                    EducationType = table.Column<string>(nullable: false),
                    StudyTimeId = table.Column<int>(nullable: true),
                    AdvisorTeacherId = table.Column<string>(nullable: true),
                    GradeAverage = table.Column<double>(nullable: false),
                    FacultyId = table.Column<int>(nullable: true),
                    StudyProgramId = table.Column<int>(nullable: true),
                    SemesterId = table.Column<int>(nullable: true),
                    RecordType = table.Column<string>(nullable: false),
                    ComeFromUniversity = table.Column<string>(nullable: true),
                    ComeFromFaculty = table.Column<string>(nullable: true),
                    ComeFromBranch = table.Column<string>(nullable: true),
                    GraduationYear = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentInformations_Teachers_AdvisorTeacherId",
                        column: x => x.AdvisorTeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentInformations_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentInformations_Semesters_SemesterId",
                        column: x => x.SemesterId,
                        principalTable: "Semesters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentInformations_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentInformations_StudyPrograms_StudyProgramId",
                        column: x => x.StudyProgramId,
                        principalTable: "StudyPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentInformations_StudyTimes_StudyTimeId",
                        column: x => x.StudyTimeId,
                        principalTable: "StudyTimes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LessonCode = table.Column<string>(nullable: true),
                    StudentId = table.Column<string>(nullable: true),
                    FailedAbsenteeism = table.Column<bool>(nullable: false),
                    FailedLowGrade = table.Column<bool>(nullable: false),
                    MidTerm = table.Column<int>(nullable: true),
                    FinalExam = table.Column<int>(nullable: true),
                    MakeUpExam = table.Column<int>(nullable: true),
                    Average = table.Column<int>(nullable: true),
                    GradeLetter = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grades_Lessons_LessonCode",
                        column: x => x.LessonCode,
                        principalTable: "Lessons",
                        principalColumn: "LessonCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Grades_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PdfFiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LessonCode = table.Column<string>(nullable: true),
                    PublicId = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    LessonCode1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PdfFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PdfFiles_Lessons_LessonCode1",
                        column: x => x.LessonCode1,
                        principalTable: "Lessons",
                        principalColumn: "LessonCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudyLessons",
                columns: table => new
                {
                    LessonCode = table.Column<string>(nullable: false),
                    StudentId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyLessons", x => new { x.StudentId, x.LessonCode });
                    table.ForeignKey(
                        name: "FK_StudyLessons_Lessons_LessonCode",
                        column: x => x.LessonCode,
                        principalTable: "Lessons",
                        principalColumn: "LessonCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudyLessons_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classrooms_StudyProgramId",
                table: "Classrooms",
                column: "StudyProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_LessonCode",
                table: "Grades",
                column: "LessonCode");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_StudentId",
                table: "Grades",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_ExamClassRoomId",
                table: "Lessons",
                column: "ExamClassRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_LessonClassRoomId",
                table: "Lessons",
                column: "LessonClassRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_SemesterId",
                table: "Lessons",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_StudyProgramId",
                table: "Lessons",
                column: "StudyProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_TeacherId",
                table: "Lessons",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_PdfFiles_LessonCode1",
                table: "PdfFiles",
                column: "LessonCode1");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_StudentId",
                table: "Photos",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentAffairs_FacultyId",
                table: "StudentAffairs",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAffairs_StudyProgramId",
                table: "StudentAffairs",
                column: "StudyProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentInformations_AdvisorTeacherId",
                table: "StudentInformations",
                column: "AdvisorTeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentInformations_FacultyId",
                table: "StudentInformations",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentInformations_SemesterId",
                table: "StudentInformations",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentInformations_StudentId",
                table: "StudentInformations",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentInformations_StudyProgramId",
                table: "StudentInformations",
                column: "StudyProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentInformations_StudyTimeId",
                table: "StudentInformations",
                column: "StudyTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentPersonalityInformations_StudentId",
                table: "StudentPersonalityInformations",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_SemesterId",
                table: "Students",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_StudyProgramId",
                table: "Students",
                column: "StudyProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyLessons_LessonCode",
                table: "StudyLessons",
                column: "LessonCode");

            migrationBuilder.CreateIndex(
                name: "IX_StudyPrograms_FacultyId",
                table: "StudyPrograms",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyPrograms_StudyTimeId",
                table: "StudyPrograms",
                column: "StudyTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_StudyProgramId",
                table: "Teachers",
                column: "StudyProgramId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "PdfFiles");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "StudentAffairs");

            migrationBuilder.DropTable(
                name: "StudentInformations");

            migrationBuilder.DropTable(
                name: "StudentPersonalityInformations");

            migrationBuilder.DropTable(
                name: "StudyLessons");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Classrooms");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Semesters");

            migrationBuilder.DropTable(
                name: "StudyPrograms");

            migrationBuilder.DropTable(
                name: "Faculties");

            migrationBuilder.DropTable(
                name: "StudyTimes");
        }
    }
}
