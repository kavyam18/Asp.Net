using Microsoft.EntityFrameworkCore;
using RelationshipDatabase.API.Models;

namespace RelationshipDatabase.API.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<BookPublisher> BookPublishers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //put on our Configuration
            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Name)
                .IsRequired();
                //One To One Relation
                entity.HasOne(a => a.Publisher)
                .WithOne(p => p.Author)
                .HasForeignKey<Publisher>(p => p.AuthorId)
                .OnDelete(DeleteBehavior.NoAction);
            });
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Title)
                .IsRequired();
                //Many To One Relation
                entity.HasOne(a => a.Author)
                .WithMany(p => p.Books)
                .HasForeignKey(p => p.AuthorId)
                .OnDelete(DeleteBehavior.NoAction);
            });
            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Name)
                .IsRequired();
            });
            //Many To Many Relation
            modelBuilder.Entity<BookPublisher>(entity =>
            {
                entity.HasKey(bp => new {bp.PublisherId, bp.BookId});   

                entity.HasOne(bp => bp.Book)
                .WithMany(b => b.BookPublishers)
                .HasForeignKey(bp => bp.BookId)
                .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(bp => bp.Publisher)
                .WithMany(b => b.BookPublishers)
                .HasForeignKey(bp => bp.PublisherId)
                .OnDelete(DeleteBehavior.NoAction); 
            });
        }
    }
}
