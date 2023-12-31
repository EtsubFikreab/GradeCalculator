﻿using GradeCalculator.Models;
using Microsoft.EntityFrameworkCore;
namespace GradeCalculator.Repository
{
	public class GradeCalculatorContext : DbContext
	{
		public GradeCalculatorContext(DbContextOptions<GradeCalculatorContext> options) : base(options) { }
		public DbSet<Profile> Profiles { get; set; }
		public DbSet<Semester> Semesters { get; set; }
		public DbSet<Course> Courses { get; set; }
	}
}
