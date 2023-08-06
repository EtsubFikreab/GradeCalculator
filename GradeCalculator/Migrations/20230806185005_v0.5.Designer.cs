﻿// <auto-generated />
using System;
using GradeCalculator.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GradeCalculator.Migrations
{
    [DbContext(typeof(GradeCalculatorContext))]
    [Migration("20230806185005_v0.5")]
    partial class v05
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GradeCalculator.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CourseCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourseTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("CreditHour")
                        .HasColumnType("float");

                    b.Property<string>("Grade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("GradePoint")
                        .HasColumnType("float");

                    b.Property<int?>("SemesterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SemesterId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("GradeCalculator.Models.Profile", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("GradeCalculator.Models.Semester", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double?>("Average")
                        .HasColumnType("float");

                    b.Property<double?>("CGPA")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProfileID")
                        .HasColumnType("int");

                    b.Property<int>("SemesterOrder")
                        .HasColumnType("int");

                    b.Property<double?>("TotalCreditHour")
                        .HasColumnType("float");

                    b.Property<double?>("TotalGradePoint")
                        .HasColumnType("float");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProfileID");

                    b.ToTable("Semesters");
                });

            modelBuilder.Entity("GradeCalculator.Models.Course", b =>
                {
                    b.HasOne("GradeCalculator.Models.Semester", null)
                        .WithMany("Courses")
                        .HasForeignKey("SemesterId");
                });

            modelBuilder.Entity("GradeCalculator.Models.Semester", b =>
                {
                    b.HasOne("GradeCalculator.Models.Profile", null)
                        .WithMany("Semesters")
                        .HasForeignKey("ProfileID");
                });

            modelBuilder.Entity("GradeCalculator.Models.Profile", b =>
                {
                    b.Navigation("Semesters");
                });

            modelBuilder.Entity("GradeCalculator.Models.Semester", b =>
                {
                    b.Navigation("Courses");
                });
#pragma warning restore 612, 618
        }
    }
}
