using ImageUpload.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ImageUpload.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
             public DbSet<ApplicationUser> ApplicationUsers { get; set; }
             public DbSet<UserImage> UserImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.UploadedImages)// A ser can have many UserImages
             .WithOne(ui => ui.User)     // A UserImage belongs to one CustomUser
        .HasForeignKey(ui => ui.UserId); // Define the foreign key relationship
}
        }
    }



 
        