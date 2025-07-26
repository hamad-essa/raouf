using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity; // Needed for IdentityUser, IdentityRole
using Microsoft.AspNetCore.Identity.EntityFrameworkCore; // Needed for IdentityDbContext
using Microsoft.EntityFrameworkCore;
using Tasheel.DAL.Entities;
using Tasheel.DAL.Extend;

namespace Tasheel.DAL.Database
{
    // Change this line: Inherit from IdentityDbContext<IdentityUser>
    // If you plan to use Identity Roles, you'd typically use IdentityDbContext<IdentityUser, IdentityRole, string>
    // For now, let's use the simplest form that will get Identity tables in.
    public class MyContext : IdentityDbContext<ApplicationUser>
    {
        public MyContext(DbContextOptions<MyContext> opt) : base(opt)
        {
        }

        public DbSet<Nationality> nationalities { get; set; }
        public DbSet<AcademicYear> academicYears { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<Card> cards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // IMPORTANT: You MUST call the base method for OnModelCreating
            // This is where IdentityDbContext sets up all the Identity tables (AspNetUsers, AspNetRoles, etc.)
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Card>()
            .HasKey(sc => new { sc.Id, sc.StudentId, sc.AcademicYearId });

            modelBuilder.Entity<Card>()
            .HasOne(bc => bc.student)
            .WithMany(b => b.Cards)
            .HasForeignKey(bc => bc.StudentId);

            modelBuilder.Entity<Card>()
            .HasOne(bc => bc.academicYear)
            .WithMany(c => c.Cards)
            .HasForeignKey(bc => bc.AcademicYearId);

            // Any custom Identity table renaming or configurations would go here,
            // but after base.OnModelCreating(modelBuilder);
        }
    }
}