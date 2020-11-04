using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    class_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    school_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.class_id);
                });

            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    exam_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.exam_id);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    grade_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    value = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.grade_id);
                });

            migrationBuilder.CreateTable(
                name: "LessonHours",
                columns: table => new
                {
                    lesson_hour_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonHours", x => x.lesson_hour_id);
                });

            migrationBuilder.CreateTable(
                name: "School_Profiles",
                columns: table => new
                {
                    profile_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School_Profiles", x => x.profile_id);
                });

            migrationBuilder.CreateTable(
                name: "Schools_Types",
                columns: table => new
                {
                    type_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools_Types", x => x.type_id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    subject_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.subject_id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    teacher_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    login = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    passwordHash = table.Column<byte[]>(type: "binary(128)", fixedLength: true, maxLength: 128, nullable: true),
                    passwordSalt = table.Column<byte[]>(type: "binary(128)", fixedLength: true, maxLength: 128, nullable: true),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    surname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    date_of_birth = table.Column<DateTime>(type: "date", nullable: true),
                    pesel = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    subject_id = table.Column<int>(type: "int", nullable: true),
                    address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    postal_code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    city = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    whether_director = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.teacher_id);
                });

            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    school_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    creation_date = table.Column<DateTime>(type: "date", nullable: true),
                    type_id = table.Column<int>(type: "int", nullable: true),
                    profile_id = table.Column<int>(type: "int", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.school_id);
                    table.ForeignKey(
                        name: "FK_Schools_School_Profiles",
                        column: x => x.profile_id,
                        principalTable: "School_Profiles",
                        principalColumn: "profile_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Schools_Schools_Types",
                        column: x => x.type_id,
                        principalTable: "Schools_Types",
                        principalColumn: "type_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Teachers_Classes",
                columns: table => new
                {
                    tc_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    teacher_id = table.Column<int>(type: "int", nullable: true),
                    class_id = table.Column<int>(type: "int", nullable: true),
                    whether_educator = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teachers_classes", x => x.tc_id);
                    table.ForeignKey(
                        name: "FK_teachers_classes_Classes",
                        column: x => x.class_id,
                        principalTable: "Classes",
                        principalColumn: "class_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_teachers_classes_Teachers",
                        column: x => x.teacher_id,
                        principalTable: "Teachers",
                        principalColumn: "teacher_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Teachers_Subjects",
                columns: table => new
                {
                    subject_id = table.Column<int>(type: "int", nullable: true),
                    teacher_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Teachers_Subjects_Subjects",
                        column: x => x.subject_id,
                        principalTable: "Subjects",
                        principalColumn: "subject_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teachers_Subjects_Teachers",
                        column: x => x.teacher_id,
                        principalTable: "Teachers",
                        principalColumn: "teacher_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Disciples",
                columns: table => new
                {
                    nd_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    login = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    passwordHASH = table.Column<byte[]>(type: "binary(128)", fixedLength: true, maxLength: 128, nullable: true),
                    passwordSALT = table.Column<byte[]>(type: "binary(128)", fixedLength: true, maxLength: 128, nullable: true),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    date_of_birth = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    pesel = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    postal_code = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    city = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    create_date = table.Column<DateTime>(type: "date", nullable: true),
                    active = table.Column<bool>(type: "bit", nullable: true),
                    teacher_id = table.Column<int>(type: "int", nullable: true),
                    school_id = table.Column<int>(type: "int", nullable: true),
                    class_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_new_disciples", x => x.nd_id);
                    table.ForeignKey(
                        name: "FK_New_Disciples_Classes",
                        column: x => x.class_id,
                        principalTable: "Classes",
                        principalColumn: "class_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_New_Disciples_Schools",
                        column: x => x.school_id,
                        principalTable: "Schools",
                        principalColumn: "school_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_New_Disciples_Teachers",
                        column: x => x.teacher_id,
                        principalTable: "Teachers",
                        principalColumn: "teacher_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    room_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    school_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.room_id);
                    table.ForeignKey(
                        name: "FK_Rooms_Schools",
                        column: x => x.school_id,
                        principalTable: "Schools",
                        principalColumn: "school_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Teachers_Schools",
                columns: table => new
                {
                    teacher_id = table.Column<int>(type: "int", nullable: true),
                    school_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_teachers_schools_Schools",
                        column: x => x.school_id,
                        principalTable: "Schools",
                        principalColumn: "school_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_teachers_schools_Teachers",
                        column: x => x.teacher_id,
                        principalTable: "Teachers",
                        principalColumn: "teacher_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Completed_exams",
                columns: table => new
                {
                    ce_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    exam_id = table.Column<int>(type: "int", nullable: true),
                    disciple_id = table.Column<int>(type: "int", nullable: true),
                    gained = table.Column<bool>(type: "bit", nullable: true),
                    date = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Completed_exams", x => x.ce_id);
                    table.ForeignKey(
                        name: "FK_Completed_exams_Exams",
                        column: x => x.exam_id,
                        principalTable: "Exams",
                        principalColumn: "exam_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Completed_exams_New_Disciples",
                        column: x => x.disciple_id,
                        principalTable: "Disciples",
                        principalColumn: "nd_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Grades_Issued",
                columns: table => new
                {
                    gi_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    disciple_id = table.Column<int>(type: "int", nullable: true),
                    teacher_id = table.Column<int>(type: "int", nullable: true),
                    date_issued = table.Column<DateTime>(type: "date", nullable: true),
                    subject_id = table.Column<int>(type: "int", nullable: true),
                    grade_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades_Issued", x => x.gi_id);
                    table.ForeignKey(
                        name: "FK_Grades_Issued_grades",
                        column: x => x.grade_id,
                        principalTable: "Grades",
                        principalColumn: "grade_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Grades_Issued_New_Disciples",
                        column: x => x.disciple_id,
                        principalTable: "Disciples",
                        principalColumn: "nd_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Grades_Issued_Subjects",
                        column: x => x.subject_id,
                        principalTable: "Subjects",
                        principalColumn: "subject_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Grades_Issued_Teachers",
                        column: x => x.teacher_id,
                        principalTable: "Teachers",
                        principalColumn: "teacher_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RegisterDisciples",
                columns: table => new
                {
                    registerD_id = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "date", nullable: true),
                    nd_id = table.Column<int>(type: "int", nullable: true),
                    teacher_id = table.Column<int>(type: "int", nullable: true),
                    class_id = table.Column<int>(type: "int", nullable: true),
                    school_id = table.Column<int>(type: "int", nullable: true),
                    status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_RegisterDisciples_Classes",
                        column: x => x.class_id,
                        principalTable: "Classes",
                        principalColumn: "class_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegisterDisciples_New_Disciples",
                        column: x => x.nd_id,
                        principalTable: "Disciples",
                        principalColumn: "nd_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegisterDisciples_Schools",
                        column: x => x.school_id,
                        principalTable: "Schools",
                        principalColumn: "school_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegisterDisciples_Teachers",
                        column: x => x.teacher_id,
                        principalTable: "Teachers",
                        principalColumn: "teacher_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TimeTable",
                columns: table => new
                {
                    timetable_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    subject_id = table.Column<int>(type: "int", nullable: true),
                    class_id = table.Column<int>(type: "int", nullable: true),
                    school_id = table.Column<int>(type: "int", nullable: true),
                    day_of_week = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    lesson_hour_id = table.Column<int>(type: "int", nullable: true),
                    room_id = table.Column<int>(type: "int", nullable: true),
                    teacher_id = table.Column<int>(type: "int", nullable: true),
                    note = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeTable", x => x.timetable_id);
                    table.ForeignKey(
                        name: "FK_TimeTable_Classes",
                        column: x => x.class_id,
                        principalTable: "Classes",
                        principalColumn: "class_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TimeTable_LessonHours",
                        column: x => x.lesson_hour_id,
                        principalTable: "LessonHours",
                        principalColumn: "lesson_hour_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TimeTable_Rooms",
                        column: x => x.room_id,
                        principalTable: "Rooms",
                        principalColumn: "room_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TimeTable_Schools",
                        column: x => x.school_id,
                        principalTable: "Schools",
                        principalColumn: "school_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TimeTable_Subjects",
                        column: x => x.subject_id,
                        principalTable: "Subjects",
                        principalColumn: "subject_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TimeTable_Teachers",
                        column: x => x.teacher_id,
                        principalTable: "Teachers",
                        principalColumn: "teacher_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Completed_exams_disciple_id",
                table: "Completed_exams",
                column: "disciple_id");

            migrationBuilder.CreateIndex(
                name: "IX_Completed_exams_exam_id",
                table: "Completed_exams",
                column: "exam_id");

            migrationBuilder.CreateIndex(
                name: "IX_Disciples_class_id",
                table: "Disciples",
                column: "class_id");

            migrationBuilder.CreateIndex(
                name: "IX_Disciples_school_id",
                table: "Disciples",
                column: "school_id");

            migrationBuilder.CreateIndex(
                name: "IX_Disciples_teacher_id",
                table: "Disciples",
                column: "teacher_id");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_Issued_disciple_id",
                table: "Grades_Issued",
                column: "disciple_id");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_Issued_grade_id",
                table: "Grades_Issued",
                column: "grade_id");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_Issued_subject_id",
                table: "Grades_Issued",
                column: "subject_id");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_Issued_teacher_id",
                table: "Grades_Issued",
                column: "teacher_id");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterDisciples_class_id",
                table: "RegisterDisciples",
                column: "class_id");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterDisciples_nd_id",
                table: "RegisterDisciples",
                column: "nd_id");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterDisciples_school_id",
                table: "RegisterDisciples",
                column: "school_id");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterDisciples_teacher_id",
                table: "RegisterDisciples",
                column: "teacher_id");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_school_id",
                table: "Rooms",
                column: "school_id");

            migrationBuilder.CreateIndex(
                name: "IX_Schools_profile_id",
                table: "Schools",
                column: "profile_id");

            migrationBuilder.CreateIndex(
                name: "IX_Schools_type_id",
                table: "Schools",
                column: "type_id");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_Classes_class_id",
                table: "Teachers_Classes",
                column: "class_id");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_Classes_teacher_id",
                table: "Teachers_Classes",
                column: "teacher_id");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_Schools_school_id",
                table: "Teachers_Schools",
                column: "school_id");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_Schools_teacher_id",
                table: "Teachers_Schools",
                column: "teacher_id");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_Subjects_subject_id",
                table: "Teachers_Subjects",
                column: "subject_id");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_Subjects_teacher_id",
                table: "Teachers_Subjects",
                column: "teacher_id");

            migrationBuilder.CreateIndex(
                name: "IX_TimeTable_class_id",
                table: "TimeTable",
                column: "class_id");

            migrationBuilder.CreateIndex(
                name: "IX_TimeTable_lesson_hour_id",
                table: "TimeTable",
                column: "lesson_hour_id");

            migrationBuilder.CreateIndex(
                name: "IX_TimeTable_room_id",
                table: "TimeTable",
                column: "room_id");

            migrationBuilder.CreateIndex(
                name: "IX_TimeTable_school_id",
                table: "TimeTable",
                column: "school_id");

            migrationBuilder.CreateIndex(
                name: "IX_TimeTable_subject_id",
                table: "TimeTable",
                column: "subject_id");

            migrationBuilder.CreateIndex(
                name: "IX_TimeTable_teacher_id",
                table: "TimeTable",
                column: "teacher_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Completed_exams");

            migrationBuilder.DropTable(
                name: "Grades_Issued");

            migrationBuilder.DropTable(
                name: "RegisterDisciples");

            migrationBuilder.DropTable(
                name: "Teachers_Classes");

            migrationBuilder.DropTable(
                name: "Teachers_Schools");

            migrationBuilder.DropTable(
                name: "Teachers_Subjects");

            migrationBuilder.DropTable(
                name: "TimeTable");

            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Disciples");

            migrationBuilder.DropTable(
                name: "LessonHours");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Schools");

            migrationBuilder.DropTable(
                name: "School_Profiles");

            migrationBuilder.DropTable(
                name: "Schools_Types");
        }
    }
}
