using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MPE.Models;

public class AppDbContext : IdentityDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // Define your DbSets (tables) if needed

  //  public DbSet<RegisterModel> registerModel { get; set; }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<UserData>()
        .HasOne(ud => ud.User)
        .WithOne()
        .HasForeignKey<UserData>(ud => ud.UserId)
        .OnDelete(DeleteBehavior.Cascade);
   
        

        var readerRoleId = "a71a55d6-99d7-4123-b4e0-1218ecb90e3e";
        var writerRoleId = "c309fa92-2123-47be-b397-a1c77adb502c";

        var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = readerRoleId,
                    ConcurrencyStamp = readerRoleId,
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper()
                },
                new IdentityRole
                {
                    Id = writerRoleId,
                    ConcurrencyStamp = writerRoleId,
                    Name = "Writer",
                    NormalizedName = "Writer".ToUpper()
                }
            };

        modelBuilder.Entity<IdentityRole>().HasData(roles);
    }
}


