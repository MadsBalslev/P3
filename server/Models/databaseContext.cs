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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=localhost;port=3306;database=database;user=root;password=123;");
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

                entity.Property(e => e.AdminName)
                    .IsRequired()
                    .HasMaxLength(999)
                    .HasColumnName("admin_name");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(999)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Poster>(entity =>
            {
                entity.ToTable("posters");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("end_date");

                entity.Property(e => e.ImageUrl)
                    .IsRequired()
                    .HasMaxLength(999)
                    .HasColumnName("image_url");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(999)
                    .HasColumnName("name");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("start_date");
            });

            modelBuilder.Entity<Screen>(entity =>
            {
                entity.ToTable("screens");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(999)
                    .HasColumnName("name");

                entity.Property(e => e.Zone)
                    .IsRequired()
                    .HasMaxLength(999)
                    .HasColumnName("zone");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(999)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(999)
                    .HasColumnName("first_name");

                entity.Property(e => e.Institution)
                    .IsRequired()
                    .HasMaxLength(999)
                    .HasColumnName("institution");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(999)
                    .HasColumnName("last_name");

                entity.Property(e => e.PhoneNumber)
                    .HasColumnType("int(255)")
                    .HasColumnName("phone_number");

                entity.Property(e => e.Role)
                    .HasColumnType("int(5)")
                    .HasColumnName("role");
            });

            modelBuilder.Entity<Zone>(entity =>
            {
                entity.ToTable("zones");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(999)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
