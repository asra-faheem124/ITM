﻿using System;
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

    public virtual DbSet<Admission> Admissions { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<CourseItm> CourseItms { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Facility> Facilities { get; set; }

    public virtual DbSet<Faculty> Faculties { get; set; }

    public virtual DbSet<MeritList> MeritLists { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

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

        modelBuilder.Entity<Admission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Admissio__3214EC0732875C2A");

            entity.ToTable("Admission");

            entity.Property(e => e.AdmCourseId).HasColumnName("adm_course_id");
            entity.Property(e => e.AdmissionStatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Pending");
            entity.Property(e => e.DateOfBirth)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.EnrollmentNumber)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ExamYear)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.FatherName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Field)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Grade)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.MotherName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PermanentAddress)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ResidentialAddress)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.SportsDetails)
                .HasColumnType("text")
                .HasColumnName("Sports_Details");
            entity.Property(e => e.University)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.AdmCourse).WithMany(p => p.Admissions)
                .HasForeignKey(d => d.AdmCourseId)
                .HasConstraintName("FK__Admission__adm_c__607251E5");
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Contact__3214EC0739B10076");

            entity.ToTable("Contact");

            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Message)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CourseItm>(entity =>
        {
            entity.HasKey(e => e.Courseid).HasName("PK__Course_I__2AAB4BC9A263B660");

            entity.ToTable("Course_ITM");

            entity.Property(e => e.Courseid).HasColumnName("courseid");
            entity.Property(e => e.CourseDepartId).HasColumnName("course_depart_id");
            entity.Property(e => e.Coursedesc)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("coursedesc");
            entity.Property(e => e.Courseduration).HasColumnName("courseduration");
            entity.Property(e => e.Coursefees).HasColumnName("coursefees");
            entity.Property(e => e.Courseimage)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("courseimage");
            entity.Property(e => e.Coursename)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("coursename");
            entity.Property(e => e.Courseteacher)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("courseteacher");

            entity.HasOne(d => d.CourseDepart).WithMany(p => p.CourseItms)
                .HasForeignKey(d => d.CourseDepartId)
                .HasConstraintName("FK__Course_IT__cours__4F47C5E3");
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
                .HasMaxLength(100)
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
                .HasMaxLength(255)
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
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Department).WithMany(p => p.Faculties)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Faculty_Department");
        });

        modelBuilder.Entity<MeritList>(entity =>
        {
            entity.HasKey(e => e.MeritId).HasName("PK__Merit_li__06847B65D570DEB7");

            entity.ToTable("Merit_list");

            entity.Property(e => e.MeritId).HasColumnName("merit_id");
            entity.Property(e => e.MeritName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("merit_name");
            entity.Property(e => e.MeritPer).HasColumnName("merit_per");
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

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__B9BE370FAC7A1101");

            entity.HasIndex(e => e.Useremail, "UQ__Users__870EAE618ED70DB4").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.UserRoleId)
                .HasDefaultValue(2)
                .HasColumnName("user_role_id");
            entity.Property(e => e.Useremail)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("useremail");
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("username");
            entity.Property(e => e.Userpassword)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("userpassword");

            entity.HasOne(d => d.UserRole).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserRoleId)
                .HasConstraintName("FK__Users__user_role__68487DD7");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
