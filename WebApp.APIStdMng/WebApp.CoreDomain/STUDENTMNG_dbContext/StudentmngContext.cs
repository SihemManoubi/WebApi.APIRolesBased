using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApp.CoreDomain.Entities;

namespace WebApp.CoreDomain.STUDENTMNG_dbContext;

public partial class StudentmngContext : DbContext
{
    public StudentmngContext()
    {
    }

    public StudentmngContext(DbContextOptions<StudentmngContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Depprf> Depprves { get; set; }

    public virtual DbSet<Facprf> Facprves { get; set; }

    public virtual DbSet<Faculty> Faculties { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<Matiere> Matieres { get; set; }

    public virtual DbSet<Professor> Professors { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=127.0.0.1;Database=STUDENTMNG;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Iddep).IsClustered(false);

            entity.ToTable("DEPARTMENT");

            entity.Property(e => e.Iddep)
                .ValueGeneratedNever()
                .HasColumnName("IDDEP");
            entity.Property(e => e.Faculty)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("FACULTY");
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("NAME");
        });

        modelBuilder.Entity<Depprf>(entity =>
        {
            entity.HasKey(e => e.Iddep);

            entity.ToTable("DEPPRF");

            entity.HasIndex(e => e.Idprf, "DEPPRF_FK");

            entity.Property(e => e.Iddep)
                .ValueGeneratedNever()
                .HasColumnName("IDDEP");
            entity.Property(e => e.Idprf).HasColumnName("IDPRF");
        });

        modelBuilder.Entity<Facprf>(entity =>
        {
            entity.HasKey(e => e.Idfac);

            entity.ToTable("FACPRF");

            entity.HasIndex(e => e.Idprf, "FACPRF_FK");

            entity.Property(e => e.Idfac)
                .ValueGeneratedNever()
                .HasColumnName("IDFAC");
            entity.Property(e => e.Idprf).HasColumnName("IDPRF");
        });

        modelBuilder.Entity<Faculty>(entity =>
        {
            entity.HasKey(e => e.Idfac).IsClustered(false);

            entity.ToTable("FACULTY");

            entity.HasIndex(e => e.Iddep, "FACDEP_FK");

            entity.HasIndex(e => e.Matricule, "FACSTD_FK");

            entity.Property(e => e.Idfac)
                .ValueGeneratedNever()
                .HasColumnName("IDFAC");
            entity.Property(e => e.Address)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ADDRESS");
            entity.Property(e => e.Department)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("DEPARTMENT");
            entity.Property(e => e.Iddep).HasColumnName("IDDEP");
            entity.Property(e => e.Matricule)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MATRICULE");
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("NAME");
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.Idnote);

            entity.ToTable("GRADES");

            entity.HasIndex(e => e.Idnote, "PK_GRD").IsUnique();

            entity.Property(e => e.Idnote).HasColumnName("IDNOTE");
            entity.Property(e => e.Matiere)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MATIERE");
            entity.Property(e => e.Note)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("NOTE");
        });

        modelBuilder.Entity<Matiere>(entity =>
        {
            entity.HasKey(e => e.Idmat);

            entity.ToTable("MATIERE", tb => tb.HasComment("Table des matières"));

            entity.HasIndex(e => e.Idmat, "PK_MAT").IsUnique();

            entity.Property(e => e.Idmat)
                .ValueGeneratedNever()
                .HasColumnName("IDMAT");
            entity.Property(e => e.Designation)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DESIGNATION");
        });

        modelBuilder.Entity<Professor>(entity =>
        {
            entity.HasKey(e => e.Idprf);

            entity.ToTable("PROFESSOR");

            entity.HasIndex(e => e.Idprf, "PK_PRF").IsUnique();

            entity.Property(e => e.Idprf)
                .ValueGeneratedNever()
                .HasColumnName("IDPRF");
            entity.Property(e => e.Designation)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DESIGNATION");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Matricule).IsClustered(false);

            entity.ToTable("STUDENT", tb => tb.HasComment("Table contient la liste des étudiants"));

            entity.Property(e => e.Matricule)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MATRICULE");
            entity.Property(e => e.Average)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("AVERAGE");
            entity.Property(e => e.Faculty)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("FACULTY");
            entity.Property(e => e.Firstname)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("FIRSTNAME");
            entity.Property(e => e.Lastname)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("LASTNAME");
            entity.Property(e => e.Registerdate)
                .HasColumnType("datetime")
                .HasColumnName("REGISTERDATE");
            entity.Property(e => e.Section)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("SECTION");
            entity.Property(e => e.Status)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("STATUS");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Idusr).IsClustered(false);

            entity.ToTable("USER", tb => tb.HasComment("Table contient la liste des utilisateurs"));

            entity.HasIndex(e => e.Matricule, "USRSTD_FK");

            entity.Property(e => e.Idusr).HasColumnName("IDUSR");
            entity.Property(e => e.Accesstoken).HasColumnName("ACCESSTOKEN");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Firstname)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("FIRSTNAME");
            entity.Property(e => e.Lastname)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("LASTNAME");
            entity.Property(e => e.Matricule)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MATRICULE");
            entity.Property(e => e.Password)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.Refreshtoken).HasColumnName("REFRESHTOKEN");
            entity.Property(e => e.Refreshtokenexpirytime).HasColumnName("REFRESHTOKENEXPIRYTIME");
            entity.Property(e => e.Role).HasColumnName("ROLE");
            entity.Property(e => e.Token).HasColumnName("TOKEN");
            entity.Property(e => e.Username)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("USERNAME");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
