using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SpaceApp.Entity;

namespace SpaceApp.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-MHQNVUV;Database=SpaceAppDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                    .Property(s => s.Address)
                    .HasMaxLength(50)
                    .IsRequired();

            modelBuilder.Entity<User>()
                    .Property(s => s.Username)
                    .HasMaxLength(50)
                    .IsRequired();

            modelBuilder.Entity<User>()
                    .Property(u => u.IdNumber)
                    .HasMaxLength(11)
                    .IsFixedLength(true)
                    .IsRequired();

            modelBuilder.Entity<Worker>()
                     .Property(u => u.IdNumber)
                     .HasMaxLength(11)
                     .IsFixedLength(true)
                     .IsRequired();

            modelBuilder.Entity<User>()
            .HasKey(u => u.Id);

            modelBuilder.Entity<Worker>()
            .HasKey(w => w.Id);

            modelBuilder.Entity<User>()
            .HasIndex(u => u.IdNumber)
            .IsUnique();

            modelBuilder.Entity<Worker>()
            .HasIndex(u => u.IdNumber)
            .IsUnique();

            modelBuilder.Entity<User>()
            .Property(u => u.PasswordHash)
            .IsRequired();

            modelBuilder.Entity<User>()
            .Property(u => u.PasswordSalt)
            .IsRequired();

            modelBuilder.Entity<User>()
            .HasOne<Worker>(u => u.UserWorker)
            .WithOne(w => w.WorkerUser)
            .HasForeignKey<Worker>(w => w.IdNumber)
            .HasPrincipalKey<User>(u => u.IdNumber);

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Worker> Workers { get; set; }
    }
}



