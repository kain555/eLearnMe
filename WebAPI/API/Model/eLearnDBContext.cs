﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace API.Model
{
    public partial class eLearnDBContext : DbContext
    {
        private string connectionString;
        public eLearnDBContext()
        {
        }

        public eLearnDBContext(DbContextOptions<eLearnDBContext> options)
            : base(options)
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: false);
            var configuration = builder.Build();

            connectionString = configuration.GetConnectionString("DefaultConnection").ToString();
        }

        public virtual DbSet<AllDiscipleGrade> AllDiscipleGrades { get; set; }
        public virtual DbSet<AllLogin> AllLogins { get; set; }
        public virtual DbSet<Announce> Announces { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<ClassInSchool> ClassInSchools { get; set; }
        public virtual DbSet<CompletedExam> CompletedExams { get; set; }
        public virtual DbSet<CompletedExams3000> CompletedExams3000s { get; set; }
        public virtual DbSet<CountDiscipleInClass> CountDiscipleInClasses { get; set; }
        public virtual DbSet<Disciple> Disciples { get; set; }
        public virtual DbSet<DiscipleGradesAll> DiscipleGradesAlls { get; set; }
        public virtual DbSet<Exam> Exams { get; set; }
        public virtual DbSet<GetGrade> GetGrades { get; set; }
        public virtual DbSet<GetTimeTableDatum> GetTimeTableData { get; set; }
        public virtual DbSet<GetTtbyDiscipleId> GetTtbyDiscipleIds { get; set; }
        public virtual DbSet<Grade> Grades { get; set; }
        public virtual DbSet<GradesIssued> GradesIssueds { get; set; }
        public virtual DbSet<LessonHour> LessonHours { get; set; }
        public virtual DbSet<RegisterDisciple> RegisterDisciples { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<School> Schools { get; set; }
        public virtual DbSet<SchoolAnnouncement> SchoolAnnouncements { get; set; }
        public virtual DbSet<SchoolProfile> SchoolProfiles { get; set; }
        public virtual DbSet<SchoolsType> SchoolsTypes { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<TeachersClass> TeachersClasses { get; set; }
        public virtual DbSet<TeachersSchool> TeachersSchools { get; set; }
        public virtual DbSet<TeachersSubject> TeachersSubjects { get; set; }
        public virtual DbSet<TeachingStaff> TeachingStaffs { get; set; }
        public virtual DbSet<TimeTable> TimeTables { get; set; }
        public virtual DbSet<TimeTableDatum> TimeTableData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AllDiscipleGrade>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("AllDiscipleGrades");

                entity.Property(e => e.DiscipleName).HasMaxLength(50);

                entity.Property(e => e.DiscipleSurname).HasMaxLength(50);

                entity.Property(e => e.GName)
                    .HasMaxLength(50)
                    .HasColumnName("gName");

                entity.Property(e => e.GValue).HasColumnName("gValue");

                entity.Property(e => e.GiDate)
                    .HasColumnType("date")
                    .HasAnnotation("Relational:ColumnType", "date");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Subject).HasMaxLength(25);

                entity.Property(e => e.TeacherName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TeacherSurname)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AllLogin>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("AllLogins");

                entity.Property(e => e.Login).HasMaxLength(50);
            });

            modelBuilder.Entity<Announce>(entity =>
            {
                entity.ToTable("Announce");

                entity.Property(e => e.AnnounceId).HasColumnName("announce_id");

                entity.Property(e => e.AddDate)
                    .HasColumnType("date")
                    .HasColumnName("add_date")
                    .HasAnnotation("Relational:ColumnType", "date");

                entity.Property(e => e.AnnounceContent)
                    .HasColumnType("text")
                    .HasColumnName("announce_content")
                    .HasAnnotation("Relational:ColumnType", "text");

                entity.Property(e => e.AnnouncingBy)
                    .HasMaxLength(50)
                    .HasColumnName("announcing_by");

                entity.Property(e => e.KindOf)
                    .HasMaxLength(50)
                    .HasColumnName("kind_of");

                entity.Property(e => e.Piority)
                    .HasMaxLength(50)
                    .HasColumnName("piority");

                entity.Property(e => e.SchoolId).HasColumnName("school_id");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.Property(e => e.ClassId).HasColumnName("class_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.SchoolId).HasColumnName("school_id");
            });

            modelBuilder.Entity<ClassInSchool>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ClassInSchool");

                entity.Property(e => e.ClassId).HasColumnName("class_id");

                entity.Property(e => e.NdId).HasColumnName("nd_id");

                entity.Property(e => e.SchoolId).HasColumnName("school_id");
            });

            modelBuilder.Entity<CompletedExam>(entity =>
            {
                entity.HasKey(e => e.CeId);

                entity.ToTable("Completed_exams");

                entity.Property(e => e.CeId).HasColumnName("ce_id");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date")
                    .HasAnnotation("Relational:ColumnType", "date");

                entity.Property(e => e.DiscipleId).HasColumnName("disciple_id");

                entity.Property(e => e.ExamId).HasColumnName("exam_id");

                entity.Property(e => e.Gained).HasColumnName("gained");

                entity.HasOne(d => d.Disciple)
                    .WithMany(p => p.CompletedExams)
                    .HasForeignKey(d => d.DiscipleId)
                    .HasConstraintName("FK_Completed_exams_New_Disciples");

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.CompletedExams)
                    .HasForeignKey(d => d.ExamId)
                    .HasConstraintName("FK_Completed_exams_Exams");
            });

            modelBuilder.Entity<CompletedExams3000>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("'Completed_exams 3000$'");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.DiscipleId).HasColumnName("disciple_id");

                entity.Property(e => e.ExamId).HasColumnName("exam_id");

                entity.Property(e => e.Gained).HasColumnName("gained");
            });

            modelBuilder.Entity<CountDiscipleInClass>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("CountDiscipleInClass");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.SchoolId).HasColumnName("school_id");
            });

            modelBuilder.Entity<Disciple>(entity =>
            {
                entity.HasKey(e => e.NdId)
                    .HasName("PK_new_disciples");

                entity.Property(e => e.NdId).HasColumnName("nd_id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .HasColumnName("address");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .HasColumnName("city");

                entity.Property(e => e.ClassId).HasColumnName("class_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("date")
                    .HasColumnName("create_date")
                    .HasAnnotation("Relational:ColumnType", "date");

                entity.Property(e => e.DateOfBirth)
                    .HasMaxLength(50)
                    .HasColumnName("date_of_birth");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Login)
                    .HasMaxLength(50)
                    .HasColumnName("login");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(128)
                    .HasColumnName("passwordHASH")
                    .IsFixedLength(true);

                entity.Property(e => e.PasswordSalt)
                    .HasMaxLength(128)
                    .HasColumnName("passwordSALT")
                    .IsFixedLength(true);

                entity.Property(e => e.Pesel)
                    .HasMaxLength(12)
                    .HasColumnName("pesel");

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(10)
                    .HasColumnName("postal_code")
                    .IsFixedLength(true);

                entity.Property(e => e.Surname)
                    .HasMaxLength(50)
                    .HasColumnName("surname");

                entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Disciples)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK_New_Disciples_Classes");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Disciples)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK_New_Disciples_Teachers");
            });

            modelBuilder.Entity<DiscipleGradesAll>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("DiscipleGradesAll");

                entity.Property(e => e.DiscipleName).HasMaxLength(50);

                entity.Property(e => e.DiscipleSurname).HasMaxLength(50);

                entity.Property(e => e.GName)
                    .HasMaxLength(50)
                    .HasColumnName("gName");

                entity.Property(e => e.GValue).HasColumnName("gValue");

                entity.Property(e => e.GiDate)
                    .HasColumnType("date")
                    .HasAnnotation("Relational:ColumnType", "date");

                entity.Property(e => e.Subject).HasMaxLength(25);

                entity.Property(e => e.TeacherName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TeacherSurname)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Exam>(entity =>
            {
                entity.Property(e => e.ExamId).HasColumnName("exam_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<GetGrade>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("getGrades");

                entity.Property(e => e.DateIssued)
                    .HasColumnType("date")
                    .HasColumnName("dateIssued")
                    .HasAnnotation("Relational:ColumnType", "date");

                entity.Property(e => e.DiscipleId).HasColumnName("discipleId");

                entity.Property(e => e.DiscipleName)
                    .HasMaxLength(50)
                    .HasColumnName("discipleName");

                entity.Property(e => e.DiscipleSurname)
                    .HasMaxLength(50)
                    .HasColumnName("discipleSurname");

                entity.Property(e => e.GradeName)
                    .HasMaxLength(50)
                    .HasColumnName("gradeName");

                entity.Property(e => e.GradeValue).HasColumnName("gradeValue");

                entity.Property(e => e.SubjectId).HasColumnName("subjectId");

                entity.Property(e => e.SubjectName)
                    .HasMaxLength(25)
                    .HasColumnName("subjectName");

                entity.Property(e => e.TeacherId).HasColumnName("teacherId");

                entity.Property(e => e.TeacherName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("teacherName");

                entity.Property(e => e.TeacherSurname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("teacherSurname");
            });

            modelBuilder.Entity<GetTimeTableDatum>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("getTimeTableData");

                entity.Property(e => e.ClassId).HasColumnName("classId");

                entity.Property(e => e.ClassName)
                    .HasMaxLength(50)
                    .HasColumnName("className");

                entity.Property(e => e.DayOfWeek)
                    .HasMaxLength(20)
                    .HasColumnName("dayOfWeek");

                entity.Property(e => e.DayOfWeekId).HasColumnName("dayOfWeekId");

                entity.Property(e => e.LessonHour)
                    .HasMaxLength(20)
                    .HasColumnName("lessonHour");

                entity.Property(e => e.LessonHourId).HasColumnName("lessonHourId");

                entity.Property(e => e.RoomName)
                    .HasMaxLength(50)
                    .HasColumnName("roomName");

                entity.Property(e => e.SchoolId).HasColumnName("schoolId");

                entity.Property(e => e.SchoolName)
                    .HasMaxLength(50)
                    .HasColumnName("schoolName");

                entity.Property(e => e.Subject)
                    .HasMaxLength(25)
                    .HasColumnName("subject");

                entity.Property(e => e.TeacheId).HasColumnName("teacheId");

                entity.Property(e => e.TeacherName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("teacherName");

                entity.Property(e => e.TeacherSurname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("teacherSurname");
            });

            modelBuilder.Entity<GetTtbyDiscipleId>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("getTTbyDiscipleID");

                entity.Property(e => e.ClassName).HasMaxLength(50);

                entity.Property(e => e.DayOfWeek).HasMaxLength(20);

                entity.Property(e => e.DayOfWeekId).HasColumnName("DayOfWeekID");

                entity.Property(e => e.DiscipleId).HasColumnName("DiscipleID");

                entity.Property(e => e.LessonHour).HasMaxLength(20);

                entity.Property(e => e.Subject).HasMaxLength(25);

                entity.Property(e => e.TeacherName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TeacherSurname)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.Property(e => e.GradeId).HasColumnName("grade_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Value).HasColumnName("value");
            });

            modelBuilder.Entity<GradesIssued>(entity =>
            {
                entity.HasKey(e => e.GiId);

                entity.ToTable("Grades_Issued");

                entity.Property(e => e.GiId).HasColumnName("gi_id");

                entity.Property(e => e.DateIssued)
                    .HasColumnType("date")
                    .HasColumnName("date_issued")
                    .HasAnnotation("Relational:ColumnType", "date");

                entity.Property(e => e.DiscipleId).HasColumnName("disciple_id");

                entity.Property(e => e.GradeId).HasColumnName("grade_id");

                entity.Property(e => e.SubjectId).HasColumnName("subject_id");

                entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

                entity.HasOne(d => d.Disciple)
                    .WithMany(p => p.GradesIssueds)
                    .HasForeignKey(d => d.DiscipleId)
                    .HasConstraintName("FK_Grades_Issued_New_Disciples");

                entity.HasOne(d => d.Grade)
                    .WithMany(p => p.GradesIssueds)
                    .HasForeignKey(d => d.GradeId)
                    .HasConstraintName("FK_Grades_Issued_grades");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.GradesIssueds)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_Grades_Issued_Subjects");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.GradesIssueds)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK_Grades_Issued_Teachers");
            });

            modelBuilder.Entity<LessonHour>(entity =>
            {
                entity.Property(e => e.LessonHourId).HasColumnName("lesson_hour_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<RegisterDisciple>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.ClassId).HasColumnName("class_id");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date")
                    .HasAnnotation("Relational:ColumnType", "date");

                entity.Property(e => e.NdId).HasColumnName("nd_id");

                entity.Property(e => e.RegisterDId).HasColumnName("registerD_id");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

                entity.HasOne(d => d.Class)
                    .WithMany()
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK_RegisterDisciples_Classes");

                entity.HasOne(d => d.Nd)
                    .WithMany()
                    .HasForeignKey(d => d.NdId)
                    .HasConstraintName("FK_RegisterDisciples_New_Disciples");

                entity.HasOne(d => d.Teacher)
                    .WithMany()
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK_RegisterDisciples_Teachers");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.Property(e => e.RoomId).HasColumnName("room_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .HasColumnName("name");

                entity.Property(e => e.SchoolId).HasColumnName("school_id");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK_Rooms_Schools");
            });

            modelBuilder.Entity<School>(entity =>
            {
                entity.Property(e => e.SchoolId).HasColumnName("school_id");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("date")
                    .HasColumnName("creation_date")
                    .HasAnnotation("Relational:ColumnType", "date");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description")
                    .HasAnnotation("Relational:ColumnType", "text");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.ProfileId).HasColumnName("profile_id");

                entity.Property(e => e.TypeId).HasColumnName("type_id");

                entity.HasOne(d => d.Profile)
                    .WithMany(p => p.Schools)
                    .HasForeignKey(d => d.ProfileId)
                    .HasConstraintName("FK_Schools_School_Profiles");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Schools)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK_Schools_Schools_Types");
            });

            modelBuilder.Entity<SchoolAnnouncement>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("School_announcements");

                entity.Property(e => e.AnnounceId).HasColumnName("announce_id");

                entity.Property(e => e.SchoolId).HasColumnName("school_id");

                entity.HasOne(d => d.Announce)
                    .WithMany()
                    .HasForeignKey(d => d.AnnounceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_School_announcements_Announce");

                entity.HasOne(d => d.School)
                    .WithMany()
                    .HasForeignKey(d => d.SchoolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_School_announcements_Schools");
            });

            modelBuilder.Entity<SchoolProfile>(entity =>
            {
                entity.HasKey(e => e.ProfileId);

                entity.ToTable("School_Profiles");

                entity.Property(e => e.ProfileId).HasColumnName("profile_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<SchoolsType>(entity =>
            {
                entity.HasKey(e => e.TypeId);

                entity.ToTable("Schools_Types");

                entity.Property(e => e.TypeId).HasColumnName("type_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.Property(e => e.SubjectId).HasColumnName("subject_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(25)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .HasColumnName("address");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .HasColumnName("city");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("date")
                    .HasColumnName("date_of_birth")
                    .HasAnnotation("Relational:ColumnType", "date");

                entity.Property(e => e.Login)
                    .HasMaxLength(50)
                    .HasColumnName("login");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(128)
                    .HasColumnName("passwordHash")
                    .IsFixedLength(true);

                entity.Property(e => e.PasswordSalt)
                    .HasMaxLength(128)
                    .HasColumnName("passwordSalt")
                    .IsFixedLength(true);

                entity.Property(e => e.Pesel)
                    .HasMaxLength(12)
                    .HasColumnName("pesel");

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(10)
                    .HasColumnName("postal_code");

                entity.Property(e => e.SubjectId).HasColumnName("subject_id");

                entity.Property(e => e.Surname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("surname");

                entity.Property(e => e.WhetherDirector).HasColumnName("whether_director");
            });

            modelBuilder.Entity<TeachersClass>(entity =>
            {
                entity.HasKey(e => e.TcId)
                    .HasName("PK_teachers_classes");

                entity.ToTable("Teachers_Classes");

                entity.Property(e => e.TcId).HasColumnName("tc_id");

                entity.Property(e => e.ClassId).HasColumnName("class_id");

                entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

                entity.Property(e => e.WhetherEducator).HasColumnName("whether_educator");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.TeachersClasses)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK_teachers_classes_Classes");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.TeachersClasses)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK_teachers_classes_Teachers");
            });

            modelBuilder.Entity<TeachersSchool>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Teachers_Schools");

                entity.Property(e => e.SchoolId).HasColumnName("school_id");

                entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

                entity.HasOne(d => d.School)
                    .WithMany()
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK_teachers_schools_Schools");

                entity.HasOne(d => d.Teacher)
                    .WithMany()
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK_teachers_schools_Teachers");
            });

            modelBuilder.Entity<TeachersSubject>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Teachers_Subjects");

                entity.Property(e => e.SubjectId).HasColumnName("subject_id");

                entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

                entity.HasOne(d => d.Subject)
                    .WithMany()
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_Teachers_Subjects_Subjects");

                entity.HasOne(d => d.Teacher)
                    .WithMany()
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK_Teachers_Subjects_Teachers");
            });

            modelBuilder.Entity<TeachingStaff>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("TeachingStaff");

                entity.Property(e => e.ClassName).HasMaxLength(50);

                entity.Property(e => e.SchoolName).HasMaxLength(50);

                entity.Property(e => e.SubjectName).HasMaxLength(25);

                entity.Property(e => e.TeacherLogin).HasMaxLength(50);

                entity.Property(e => e.TeacherName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TeacherSurname)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TimeTable>(entity =>
            {
                entity.ToTable("TimeTable");

                entity.Property(e => e.TimetableId).HasColumnName("timetable_id");

                entity.Property(e => e.ClassId).HasColumnName("class_id");

                entity.Property(e => e.DayOfWeek)
                    .HasMaxLength(20)
                    .HasColumnName("day_of_week");

                entity.Property(e => e.DayOfWeekId).HasColumnName("day_of_week_id");

                entity.Property(e => e.LessonHourId).HasColumnName("lesson_hour_id");

                entity.Property(e => e.Note)
                    .HasColumnType("text")
                    .HasColumnName("note")
                    .HasAnnotation("Relational:ColumnType", "text");

                entity.Property(e => e.RoomId).HasColumnName("room_id");

                entity.Property(e => e.SubjectId).HasColumnName("subject_id");

                entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.TimeTables)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK_TimeTable_Classes");

                entity.HasOne(d => d.LessonHour)
                    .WithMany(p => p.TimeTables)
                    .HasForeignKey(d => d.LessonHourId)
                    .HasConstraintName("FK_TimeTable_LessonHours");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.TimeTables)
                    .HasForeignKey(d => d.RoomId)
                    .HasConstraintName("FK_TimeTable_Rooms");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.TimeTables)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_TimeTable_Subjects");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.TimeTables)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK_TimeTable_Teachers");
            });

            modelBuilder.Entity<TimeTableDatum>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("TimeTableData");

                entity.Property(e => e.ClassId).HasColumnName("classId");

                entity.Property(e => e.ClassName)
                    .HasMaxLength(50)
                    .HasColumnName("className");

                entity.Property(e => e.DayOfWeek)
                    .HasMaxLength(20)
                    .HasColumnName("dayOfWeek");

                entity.Property(e => e.DayOfWeekId).HasColumnName("dayOfWeekId");

                entity.Property(e => e.LessonHourId).HasColumnName("lessonHourId");

                entity.Property(e => e.LessonHourName)
                    .HasMaxLength(20)
                    .HasColumnName("lessonHourName");

                entity.Property(e => e.Note)
                    .HasColumnType("text")
                    .HasColumnName("note")
                    .HasAnnotation("Relational:ColumnType", "text");

                entity.Property(e => e.RoomId).HasColumnName("roomId");

                entity.Property(e => e.RoomName)
                    .HasMaxLength(200)
                    .HasColumnName("roomName");

                entity.Property(e => e.SubjectId).HasColumnName("subjectId");

                entity.Property(e => e.SubjectName)
                    .HasMaxLength(25)
                    .HasColumnName("subjectName");

                entity.Property(e => e.TeacherId).HasColumnName("teacherId");

                entity.Property(e => e.TeacherName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("teacherName");

                entity.Property(e => e.TeacherSurname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("teacherSurname");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
