using Microsoft.EntityFrameworkCore;
using LibraryApp.Models;
using LibraryApp.Models.Enums;

namespace LibraryApp.Data;

public class LibraryContext : DbContext{

    public DbSet<Book> Books { get; set; } = null!;
    public DbSet<Comment> Comments { get; set; } = null!;


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(
            "Host=localhost;Database=library;Username=kabisa_03"
        );
    }

 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

   
        modelBuilder.Entity<Book>(entity =>
        {
            // column rules
            entity.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(b => b.Author)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(b => b.Genre)
                .HasConversion<string>();  // store as "Fiction" not 0

            // indexes
            entity.HasIndex(b => b.Author);
            entity.HasIndex(b => b.Title);

            // check constraints
            entity.HasCheckConstraint("CK_Books_Pages", "\"Pages\" > 0");
            entity.HasCheckConstraint(
                "CK_Books_Genre",
                "\"Genre\" IN ('Fiction','NonFiction','Mystery','Thriller',  'SciFi','Fantasy','Romance','Horror',  'Biography','History','SelfHelp','Technology')"
            );

            // relationship
            entity.HasMany(b => b.Comments)
                .WithOne(c => c.Book)
                .HasForeignKey(c => c.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            // seed data
            entity.HasData(
                new Book
                {
                    Id          = 1,
                    Title       = "Clean Code",
                    Author      = "Robert C. Martin",
                    Pages       = 431,
                    Genre       = BookGenre.Technology,
                    Description = "A handbook of agile software craftsmanship",
                    CreatedAt   = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Book
                {
                    Id          = 2,
                    Title       = "The Pragmatic Programmer",
                    Author      = "David Thomas",
                    Pages       = 352,
                    Genre       = BookGenre.Technology,
                    Description = "Your journey to mastery",
                    CreatedAt   = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Book
                {
                    Id          = 3,
                    Title       = "Dune",
                    Author      = "Frank Herbert",
                    Pages       = 688,
                    Genre       = BookGenre.SciFi,
                    Description = "A science fiction masterpiece",
                    CreatedAt   = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                }
            );
        });

    
        modelBuilder.Entity<Comment>(entity =>
        {
            entity.Property(c => c.Note)
                .IsRequired()
                .HasMaxLength(500);

            // seed some comments
            entity.HasData(
                new Comment
                {
                    Id        = 1,
                    Note      = "This book changed the way I write code completely",
                    BookId    = 1,
                    CreatedAt = new DateTime(2024, 1, 15, 0, 0, 0, DateTimeKind.Utc)
                },
                new Comment
                {
                    Id        = 2,
                    Note      = "Must read for every software developer out there",
                    BookId    = 1,
                    CreatedAt = new DateTime(2024, 1, 20, 0, 0, 0, DateTimeKind.Utc)
                },
                new Comment
                {
                    Id        = 3,
                    Note      = "Dune is an absolute masterpiece of world building",
                    BookId    = 3,
                    CreatedAt = new DateTime(2024, 2, 1, 0, 0, 0, DateTimeKind.Utc)
                }
            );
        });
    }}
