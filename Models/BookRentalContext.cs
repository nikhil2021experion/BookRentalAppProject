using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BookRentalAppProject.Models
{
    public partial class BookRentalContext : DbContext
    {
        public BookRentalContext()
        {
        }

        public BookRentalContext(DbContextOptions<BookRentalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Authors> Authors { get; set; }
        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<GenreDetails> GenreDetails { get; set; }
        public virtual DbSet<Members> Members { get; set; }
        public virtual DbSet<PublicationDetails> PublicationDetails { get; set; }
        public virtual DbSet<RentDetails> RentDetails { get; set; }
        public object MembersViewModel { get; internal set; }

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source= NIKHILNANDAGOPA\\SQLEXPRESS; Initial Catalog= BookRental; Integrated security=True");
            }
        }
        */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Authors>(entity =>
            {
                entity.HasKey(e => e.AuthorId)
                    .HasName("PK__Authors__70DAFC14B243D643");

                entity.Property(e => e.AuthorId).HasColumnName("AuthorID");

                entity.Property(e => e.AuthorName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Books>(entity =>
            {
                entity.HasKey(e => e.BookId)
                    .HasName("PK__Books__3DE0C2275AA956C7");

                entity.Property(e => e.BookId).HasColumnName("BookID");

                entity.Property(e => e.AuthorId).HasColumnName("AuthorID");

                entity.Property(e => e.BookName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.GenreId).HasColumnName("GenreID");

                entity.Property(e => e.PublicationId).HasColumnName("PublicationID");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK__Books__AuthorID__5CD6CB2B");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.GenreId)
                    .HasConstraintName("FK__Books__GenreID__5BE2A6F2");

                entity.HasOne(d => d.Publication)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.PublicationId)
                    .HasConstraintName("FK__Books__Publicati__5AEE82B9");
            });

            modelBuilder.Entity<GenreDetails>(entity =>
            {
                entity.HasKey(e => e.GenreId)
                    .HasName("PK__GenreDet__0385055EADC6A6F7");

                entity.Property(e => e.GenreId).HasColumnName("GenreID");

                entity.Property(e => e.GenreName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Members>(entity =>
            {
                entity.HasKey(e => e.MemberId)
                    .HasName("PK__Members__0CF04B3818938C68");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.Address)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.MemberName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Mobile)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PublicationDetails>(entity =>
            {
                entity.HasKey(e => e.PublicationId)
                    .HasName("PK__Publicat__05E6DC582376967C");

                entity.Property(e => e.PublicationId).HasColumnName("PublicationID");

                entity.Property(e => e.PublicationName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RentDetails>(entity =>
            {
                entity.HasKey(e => e.RentId)
                    .HasName("PK__RentDeta__783D4015467A6DC1");

                entity.Property(e => e.RentId).HasColumnName("RentID");

                entity.Property(e => e.BookId).HasColumnName("BookID");

                entity.Property(e => e.BookReturnedDate).HasColumnType("date");

                entity.Property(e => e.BookTakenDate).HasColumnType("date");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.RentDetails)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK__RentDetai__BookI__60A75C0F");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.RentDetails)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK__RentDetai__Membe__5FB337D6");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
