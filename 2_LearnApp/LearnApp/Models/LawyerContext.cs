using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LearnApp.Models
{
    public partial class LawyerContext : DbContext
    {
        public LawyerContext()
        {
        }

        public LawyerContext(DbContextOptions<LawyerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Advokate> Advokate { get; set; }
        public virtual DbSet<Case> Case { get; set; }
        public virtual DbSet<Note> Note { get; set; }
        public virtual DbSet<NotesByCases> NotesByCases { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-IDFEOG1; Database = Lawyer; Trusted_connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<NotesByCases>(entity =>
            //    {
            //        entity.HasKey();
            //    });
            modelBuilder.Entity<Advokate>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(250);
            });

            modelBuilder.Entity<Case>(entity =>
            {
                entity.Property(e => e.AdvokateId).HasColumnName("Advokate_ID");

                entity.Property(e => e.Info).HasColumnType("text");

                entity.HasOne(d => d.Advokate)
                    .WithMany(p => p.Case)
                    .HasForeignKey(d => d.AdvokateId)
                    .HasConstraintName("FK_Case_Advokate");
            });

            modelBuilder.Entity<Note>(entity =>
            {
                entity.Property(e => e.CaseId).HasColumnName("Case_Id");

                entity.HasOne(d => d.Case)
                    .WithMany(p => p.Note)
                    .HasForeignKey(d => d.CaseId)
                    .HasConstraintName("FK_Note_Case");
            });
        }
    }
}
