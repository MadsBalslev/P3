using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace server.Entities
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
        public virtual DbSet<Metadata> Metadatas { get; set; }
        public virtual DbSet<Poster> Posters { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
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

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Metadata>(entity =>
            {
                entity.ToTable("metadata");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Timer)
                    .HasColumnType("int(11)")
                    .HasColumnName("timer");
            });

            modelBuilder.Entity<Poster>(entity =>
            {
                entity.ToTable("posters");

                entity.HasIndex(e => e.Institution, "institution_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.ImageUrl)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("image_url");

                entity.Property(e => e.Institution)
                    .HasColumnType("int(11)")
                    .HasColumnName("institution");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("name");

                entity.HasOne(d => d.InstitutionNavigation)
                    .WithMany(p => p.Posters)
                    .HasForeignKey(d => d.Institution)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("institution_id");
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.ToTable("schedules");

                entity.HasIndex(e => e.PosterId, "poster_id");

                entity.HasIndex(e => e.Zone, "zone");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.EndDate).HasColumnName("end_date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.PosterId)
                    .HasColumnType("int(11)")
                    .HasColumnName("poster_id");

                entity.Property(e => e.StartDate).HasColumnName("start_date");

                entity.Property(e => e.Zone)
                    .HasColumnType("int(11)")
                    .HasColumnName("zone");

                entity.HasOne(d => d.Poster)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.PosterId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("poster_id");

                entity.HasOne(d => d.ZoneNavigation)
                    .WithMany(p => p.Schedules)
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

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("password");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("phone_number");

                entity.Property(e => e.Role)
                    .HasColumnType("int(11)")
                    .HasColumnName("role");

                entity.HasOne(d => d.InstitutionNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Institution)
                    .OnDelete(DeleteBehavior.Cascade)
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