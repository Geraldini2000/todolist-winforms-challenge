using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace TodoApp.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<TaskItem> Tasks => Set<TaskItem>();

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Username).IsRequired();
                entity.Property(x => x.PasswordHash).IsRequired();
            });

            modelBuilder.Entity<TaskItem>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Title).IsRequired();
                entity.Property(x => x.Category).IsRequired();

                entity.HasOne(x => x.User)
                      .WithMany()
                      .HasForeignKey(x => x.UserId);
            });
        }
    }
}
