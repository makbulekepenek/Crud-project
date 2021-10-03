using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Odev.Web.Models
{
    public partial class BlogContext : DbContext
    {
        public BlogContext()
        {
        }
        public BlogContext(DbContextOptions<BlogContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=Blog;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Adi).HasMaxLength(50);
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("Post");

                entity.Property(e => e.Aciklama).HasMaxLength(50);

                entity.Property(e => e.Adi).HasMaxLength(50);

                entity.Property(e => e.Baslik).HasMaxLength(50);

                entity.Property(e => e.Zaman).HasMaxLength(50);

                entity.HasOne(d => d.Kategori)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.KategoriId)
                    .HasConstraintName("FK_Post_Category");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
