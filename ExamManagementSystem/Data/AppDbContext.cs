using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ExamManagementSystem.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Section> Sections { get; set; }

    public virtual DbSet<Session> Sessions { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-8BL3MIG\\SQLEXPRESS;Database=ExamManagementDb;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__Courses__C92D71A7592A274F");

            entity.Property(e => e.CourseName).HasMaxLength(100);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE1AF8F7E347");

            entity.Property(e => e.RoleName).HasMaxLength(100);

            // ✅ Seeding default roles
            entity.HasData(
                new Role { RoleId = 1, RoleName = "SuperAdmin" },
                new Role { RoleId = 2, RoleName = "Admin" },
                new Role { RoleId = 3, RoleName = "Clerk" }
            );
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.RoomId).HasName("PK__Rooms__32863939B7FE37B2");

            entity.Property(e => e.RoomNumber).HasMaxLength(50);
        });

        modelBuilder.Entity<Section>(entity =>
        {
            entity.HasKey(e => e.SectionId).HasName("PK__Sections__80EF0872BE6F1799");

            entity.Property(e => e.SectionName).HasMaxLength(100);
        });

        modelBuilder.Entity<Session>(entity =>
        {
            entity.HasKey(e => e.SessionId).HasName("PK__Sessions__C9F49290CB41E6E7");

            entity.Property(e => e.SessionName).HasMaxLength(100);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Students__32C52B9939CD168F");

            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.Cnic)
                .HasMaxLength(50)
                .HasColumnName("CNIC");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.RollNumber).HasMaxLength(100);

            entity.HasOne(d => d.Course).WithMany(p => p.Students)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__Students__Course__5535A963");

            entity.HasOne(d => d.Section).WithMany(p => p.Students)
                .HasForeignKey(d => d.SectionId)
                .HasConstraintName("FK__Students__Sectio__534D60F1");

            entity.HasOne(d => d.Session).WithMany(p => p.Students)
                .HasForeignKey(d => d.SessionId)
                .HasConstraintName("FK__Students__Sessio__5441852A");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C9EAC8A19");

            entity.Property(e => e.PasswordHash).HasMaxLength(500);
            entity.Property(e => e.Role).HasMaxLength(50);
            entity.Property(e => e.Username).HasMaxLength(100);

            entity.HasOne(d => d.RoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_Users_Roles");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
