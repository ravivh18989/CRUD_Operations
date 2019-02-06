using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using CRUD_DEMO2.Model;

namespace CRUD_DEMO2
{
    public partial class DBContext : DbContext
    {
        public virtual DbSet<Entity> Entity { get; set; }
        public virtual DbSet<Intent> Intent { get; set; }
        public virtual DbSet<Utterences> Utterences { get; set; } 

        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entity>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("Entity");

                entity.Property(e => e.Id)
                    .HasColumnName("Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Utterences>(entity =>
            {
                entity.HasKey(u => u.Id);

                entity.ToTable("Utterences");

                entity.Property(u => u.Id)
                    .HasColumnName("Id")
                    .ValueGeneratedNever();

                entity.Property(u => u.Text)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(u => u.IntentId)
                  .HasMaxLength(50)
                  .IsUnicode(false);
            });

            modelBuilder.Entity<Intent>(entity =>
            {
                entity.HasKey(i => i.Id);

                entity.ToTable("Intent");

                entity.Property(i => i.Id)
                    .HasColumnName("Id")
                    .ValueGeneratedNever();

                entity.Property(i => i.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
