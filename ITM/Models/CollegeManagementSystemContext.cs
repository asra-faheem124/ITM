using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ITM.Models;

public partial class CollegeManagementSystemContext : DbContext
{
    public CollegeManagementSystemContext()
    {
    }

    public CollegeManagementSystemContext(DbContextOptions<CollegeManagementSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Facility> Facilities { get; set; }

    public virtual DbSet<Faculty> Faculties { get; set; }

    public virtual DbSet<PreviousExam> PreviousExams { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source=DESKTOP-U1B54QB\\MSSQLSERVER01;initial catalog=College_Management_System;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__Admin__43AA41414511C970");

            entity.ToTable("Admin");

            entity.HasIndex(e => e.AdminEmail, "UQ__Admin__C2C731F07D5BC8B9").IsUnique();

            entity.Property(e => e.AdminId).HasColumnName("admin_id");
            entity.Property(e => e.AdminEmail)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("admin_email");
            entity.Property(e => e.AdminName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("admin_name");
            entity.Property(e => e.AdminPassword)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("admin_password");
            entity.Property(e => e.RoleId).HasColumnName("role_id");

            entity.HasOne(d => d.Role).WithMany(p => p.Admins)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Admin__role_id__3D5E1FD2");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__Course__8F1EF7AE32D11F48");

            entity.ToTable("Course");

            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.CourseDesc)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("course_desc");
            entity.Property(e => e.CourseDuration)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("course_duration");
            entity.Property(e => e.CourseFees)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("course_fees");
            entity.Property(e => e.CourseImg)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("course_img");
            entity.Property(e => e.CourseName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("course_name");
            entity.Property(e => e.CourseTeacher)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("course_teacher");
            entity.Property(e => e.DepartmentId).HasColumnName("department_id");

            entity.HasOne(d => d.Department).WithMany(p => p.Courses)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Course__departme__5CD6CB2B");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__C2232422A4140755");

            entity.ToTable("Department");

            entity.Property(e => e.DepartmentId).HasColumnName("department_id");
            entity.Property(e => e.DepartmentDesc)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("department_desc");
            entity.Property(e => e.DepartmentImg)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("department_img");
            entity.Property(e => e.DepartmentName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("department_name");
            entity.Property(e => e.DepartmentTeacher)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("department_teacher");
        });

        modelBuilder.Entity<Facility>(entity =>
        {
            entity.HasKey(e => e.FacilityId).HasName("PK__Faciliti__B2E8EAAE226AAC79");

            entity.Property(e => e.FacilityId).HasColumnName("facility_id");
            entity.Property(e => e.FacilityDesc)
                .HasColumnType("text")
                .HasColumnName("facility_desc");
            entity.Property(e => e.FacilityImg)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("facility_img");
            entity.Property(e => e.FacilityName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("facility_name");
        });

        modelBuilder.Entity<Faculty>(entity =>
        {
            entity.HasKey(e => e.FacultyId).HasName("PK__Faculty__7B00413CDC704087");

            entity.ToTable("Faculty");

            entity.Property(e => e.FacultyId).HasColumnName("faculty_id");
            entity.Property(e => e.DepartmentId).HasColumnName("department_id");
            entity.Property(e => e.Designation)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Experience)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FacultyImg)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("faculty_img");
            entity.Property(e => e.FacultyName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("faculty_name");
            entity.Property(e => e.Qualification)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Department).WithMany(p => p.Faculties)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK__Faculty__departm__4CA06362");
        });

        modelBuilder.Entity<PreviousExam>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Previous_Exam");

            entity.Property(e => e.Center)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EnrollNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Enroll_Number");
            entity.Property(e => e.Field)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MarksSecured).HasColumnName("Marks_Secured");
            entity.Property(e => e.OutOf).HasColumnName("Out_Of");
            entity.Property(e => e.StudentId).HasColumnName("student_id");
            entity.Property(e => e.University)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Student).WithMany()
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__Previous___stude__44FF419A");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__760965CCD22A8154");

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Students__2A33069ADF9D5CDE");

            entity.Property(e => e.StudentId).HasColumnName("student_id");
            entity.Property(e => e.AdmissionFor)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Admission_for");
            entity.Property(e => e.DateOfBirth).HasColumnName("date_of_birth");
            entity.Property(e => e.FatherName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("father_name");
            entity.Property(e => e.Gender)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MotherName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("mother_name");
            entity.Property(e => e.PermanentAddress)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Permanent_Address");
            entity.Property(e => e.ResidentialAddress)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Residential_Address");
            entity.Property(e => e.SportsDetails)
                .HasColumnType("text")
                .HasColumnName("Sports_details");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__B9BE370F18026481");

            entity.HasIndex(e => e.UserEmail, "UQ__Users__B0FBA2120F17C8A9").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.UserEmail)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("user_email");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("user_name");
            entity.Property(e => e.UserPassword)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("user_password");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Users__role_id__412EB0B6");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
