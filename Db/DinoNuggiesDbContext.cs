using Microsoft.EntityFrameworkCore;
using Domain.User;
using Domain.Values;
using Domain.Comment;
using Domain.Post;
using Domain.Follow;
using Domain.Message;

namespace Db
{
    public class DinoNuggiesDbContext : DbContext
    {
        public DinoNuggiesDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Database=localhost;Username=postgres;Password=password");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<Values>().HasKey(x => x.Id);
            modelBuilder.Entity<Post>().HasKey(x => x.Id);
            modelBuilder.Entity<Comment>().HasKey(x => x.Id);
            modelBuilder.Entity<Follow>().HasKey(x => x.Id);
            modelBuilder.Entity<Message>().HasKey(x => x.Id);

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Values> Values { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Follow> Follows { get; set; }
        public DbSet<Message> Messages { get; set; }


    }
}
