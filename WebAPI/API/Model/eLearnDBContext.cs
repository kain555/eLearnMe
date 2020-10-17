using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace API.Model
{
    public partial class eLearnDBContext : DbContext
    {
        public eLearnDBContext()
        {
        }

        public eLearnDBContext(DbContextOptions<eLearnDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TestTable> TestTables { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=elearnapp.database.windows.net;Database=eLearnDB;user id=elearnAdmin;password=ADlearn123!;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TestTable>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TestTable");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .HasColumnName("name")
                    .IsFixedLength(true);

                entity.Property(e => e.Surname)
                    .HasMaxLength(10)
                    .HasColumnName("surname")
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
