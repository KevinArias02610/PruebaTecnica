using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PruebaTecnicaDataAccess.ModelsDB;

namespace PruebaTecnicaDataAccess.DBContext
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<Inventory> Inventories { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("User Id=julian;Password=12345;Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=orcl)));");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("JULIAN")
                .UseCollation("USING_NLS_COMP");

            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("AUTHORS");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ID")
                    .HasDefaultValueSql("\"JULIAN\".\"AUTHORS_SEQ\".\"NEXTVAL\"");

                entity.Property(e => e.CityOfOrigin)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CITY_OF_ORIGIN");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("DATE")
                    .HasColumnName("DATE_OF_BIRTH");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.FullName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FULL_NAME");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("BOOKS");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ID")
                    .HasDefaultValueSql("\"JULIAN\".\"BOOKS_SEQ\".\"NEXTVAL\"");

                entity.Property(e => e.AuthorId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AUTHOR_ID");

                entity.Property(e => e.Genre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("GENRE");

                entity.Property(e => e.NumberOfPages)
                    .HasColumnType("NUMBER")
                    .HasColumnName("NUMBER_OF_PAGES");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TITLE");

                entity.Property(e => e.Year)
                    .HasColumnType("NUMBER")
                    .HasColumnName("YEAR");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK_AUTHORS");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("INVENTORY");

                entity.Property(e => e.NumberOfRecords)
                    .HasColumnType("NUMBER")
                    .HasColumnName("NUMBER_OF_RECORDS");
            });

            modelBuilder.HasSequence("AUTHORS_SEQ");

            modelBuilder.HasSequence("BOOKS_SEQ");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
