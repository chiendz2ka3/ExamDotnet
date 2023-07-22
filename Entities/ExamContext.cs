using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Exam2.Entities;

public partial class ExamContext : DbContext
{
    public ExamContext()
    {
    }

    public ExamContext(DbContextOptions<ExamContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ClassRoom> ClassRooms { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Faculty> Faculties { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<ProjectEmployee> ProjectEmployees { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<SubjectExam> SubjectExams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost,1433; Database=Exam;User Id=sa;Password=anhchien2003;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ClassRoom>(entity =>
        {
            entity.ToTable("ClassRoom");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04F11395D5F93");

            entity.ToTable("Employee");

            entity.Property(e => e.EmployeeDepartment)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.EmployeeDob)
                .HasColumnType("date")
                .HasColumnName("EmployeeDOB");
            entity.Property(e => e.EmployeeName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Faculty>(entity =>
        {
            entity.ToTable("Faculty");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Projectid).HasName("PK__Project__7611CEA87FA7515F");

            entity.ToTable("Project");

            entity.Property(e => e.ProjectEndDate).HasColumnType("date");
            entity.Property(e => e.ProjectName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ProjectStartDate).HasColumnType("date");
        });

        modelBuilder.Entity<ProjectEmployee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProjectE__3213E83FA8070DD3");

            entity.ToTable("ProjectEmployee");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Tasks)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Employee).WithMany(p => p.ProjectEmployees)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK__ProjectEm__Emplo__60A75C0F");

            entity.HasOne(d => d.Project).WithMany(p => p.ProjectEmployees)
                .HasForeignKey(d => d.Projectid)
                .HasConstraintName("FK__ProjectEm__Proje__619B8048");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.ToTable("Subject");
        });

        modelBuilder.Entity<SubjectExam>(entity =>
        {
            entity.ToTable("SubjectExam");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Classroom)
                .HasMaxLength(50)
                .HasDefaultValueSql("(N'')")
                .HasColumnName("classroom");
            entity.Property(e => e.Faculty)
                .HasMaxLength(50)
                .HasDefaultValueSql("(N'')");
            entity.Property(e => e.SubJectName)
                .HasMaxLength(100)
                .HasDefaultValueSql("(N'')");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
