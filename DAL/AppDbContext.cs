using DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public static DbContextOptions<AppDbContext> GetDbContextOptions()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>().Options;

            using (var context = new AppDbContext(options))
            {
                SeedData(context);
            }
            return options;
        }
        public static void SeedData(AppDbContext context)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserFile>()
                .HasKey(ub => new { ub.UserId, ub.FileId });

            modelBuilder.Entity<UserFile>()
                .HasOne(ub => ub.User)
                .WithMany(au => au.Files)
                .HasForeignKey(ub => ub.UserId);

            modelBuilder.Entity<UserFile>()
                .HasOne(ub => ub.File)
                .WithMany(b => b.UserFiles) // If you add `public ICollection<UserBook> UserBooks { get; set; }` navigation property to Book model class then replace `.WithMany()` with `.WithMany(b => b.UserBooks)`
                .HasForeignKey(ub => ub.FileId);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<FileEntity> Files { get; set; }
        public DbSet<UserEntity> ApplicationUsers { get; set; }
        public DbSet<UserFile> UserToFiles { get; set; }

    }
}
