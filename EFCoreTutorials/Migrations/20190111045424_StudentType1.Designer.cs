﻿// <auto-generated />
using System;
using EFCoreTutorials;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFCoreTutorials.Migrations
{
    [DbContext(typeof(SchoolContext))]
    [Migration("20190111045424_StudentType1")]
    partial class StudentType1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFCoreTutorials.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CourseName");

                    b.Property<string>("Description");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("EFCoreTutorials.Grade", b =>
                {
                    b.Property<int>("GradeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GradeName");

                    b.Property<string>("Section");

                    b.HasKey("GradeId");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("EFCoreTutorials.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GradeId");

                    b.Property<string>("Name");

                    b.Property<int>("StudentType")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.HasKey("StudentId");

                    b.HasIndex("GradeId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("EFCoreTutorials.StudentAddress", b =>
                {
                    b.Property<int>("StudentAddressId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<int>("AddressOfStudentId");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("State");

                    b.HasKey("StudentAddressId");

                    b.HasIndex("AddressOfStudentId")
                        .IsUnique();

                    b.ToTable("StudentAddresses");
                });

            modelBuilder.Entity("EFCoreTutorials.StudentCourse", b =>
                {
                    b.Property<int>("StudentId");

                    b.Property<int>("CourseId");

                    b.HasKey("StudentId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("StudentCourse");
                });

            modelBuilder.Entity("EFCoreTutorials.Student", b =>
                {
                    b.HasOne("EFCoreTutorials.Grade", "Grade")
                        .WithMany("Students")
                        .HasForeignKey("GradeId");
                });

            modelBuilder.Entity("EFCoreTutorials.StudentAddress", b =>
                {
                    b.HasOne("EFCoreTutorials.Student", "Student")
                        .WithOne("StudentAddress")
                        .HasForeignKey("EFCoreTutorials.StudentAddress", "AddressOfStudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EFCoreTutorials.StudentCourse", b =>
                {
                    b.HasOne("EFCoreTutorials.Course", "Course")
                        .WithMany("StudentCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EFCoreTutorials.Student", "Student")
                        .WithMany("StudentCourses")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
