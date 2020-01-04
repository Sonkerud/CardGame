using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CardGameLibrary.Models.Entities
{
    public partial class CardGameHighScoreContext : DbContext
    {
        public CardGameHighScoreContext()
        {
        }

        public CardGameHighScoreContext(DbContextOptions<CardGameHighScoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CardGameHighScore> CardGameHighScore { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CardGameHighScoreDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CardGameHighScore>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UQ__CardGame__737584F638E1972E")
                    .IsUnique();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
