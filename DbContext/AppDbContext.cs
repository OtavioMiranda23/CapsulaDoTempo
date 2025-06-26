using CapsulaDoTempo.Entities;
using Microsoft.EntityFrameworkCore;

namespace CapsulaDoTempo.DbContext;

public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options){}
    public DbSet<CapsulaModel> Capsula { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<CapsulaModel>().HasKey(m => m.Uuid);
        builder.Entity<CapsulaModel>().Property(m => m.CreatedAt)
            .HasDefaultValueSql("GETDATE()");
        builder.Entity<CapsulaModel>().OwnsOne(m => m.Email);
        base.OnModelCreating(builder);
    }
}