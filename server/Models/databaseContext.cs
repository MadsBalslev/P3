using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace server.Models
{
    public partial class databaseContext : DbContext
    {
        public databaseContext()
        {
        }

        public databaseContext(DbContextOptions<databaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Institution> Institutions { get; set; }
        public virtual DbSet<Poster> Posters { get; set; }
        public virtual DbSet<Screen> Screens { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Zone> Zones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("Name=ConnectionStrings:MySQL");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Institution>(entity =>
            {
                entity.ToTable("institutions");

                entity.HasIndex(e => e.Admin, "admin");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Admin)
                    .HasColumnType("int(11)")
                    .HasColumnName("admin");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("name");

                entity.HasOne(d => d.AdminNavigation)
                    .WithMany(p => p.Institutions)
                    .HasForeignKey(d => d.Admin)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("admin");
            });

            modelBuilder.Entity<Poster>(entity =>
            {
                entity.ToTable("posters");

                entity.HasIndex(e => e.CreatedBy, "created_by");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.CreatedBy)
                    .HasColumnType("int(11)")
                    .HasColumnName("created_by");

                entity.Property(e => e.EndDate).HasColumnName("end_date");

                entity.Property(e => e.ImageUrl)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("image_url");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("name");

                entity.Property(e => e.StartDate).HasColumnName("start_date");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Posters)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("created_by");
            });

            modelBuilder.Entity<Screen>(entity =>
            {
                entity.ToTable("screens");

                entity.HasIndex(e => e.Zone, "zone");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Zone)
                    .HasColumnType("int(11)")
                    .HasColumnName("zone");

                entity.HasOne(d => d.ZoneNavigation)
                    .WithMany(p => p.Screens)
                    .HasForeignKey(d => d.Zone)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("zone");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Institution, "institution");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("first_name");

                entity.Property(e => e.Institution)
                    .HasColumnType("int(11)")
                    .HasColumnName("institution");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("last_name");

                entity.Property(e => e.PhoneNumber)
                    .HasColumnType("int(11)")
                    .HasColumnName("phone_number");

                entity.Property(e => e.Role)
                    .HasColumnType("int(11)")
                    .HasColumnName("role");

                entity.HasOne(d => d.InstitutionNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Institution)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("institution");
            });

            modelBuilder.Entity<Zone>(entity =>
            {
                entity.ToTable("zones");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}