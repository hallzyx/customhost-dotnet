
using customhost_backend.crm.Domain.Models.Aggregates;
using customhost_backend.Shared.Infrastructure.Interfaces.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;

namespace customhost_backend.Shared.Infrastructure.Persistence.EFC.Configuration;

/// <summary>
///     Application database context
/// </summary>
public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        // Add the created and updated interceptor
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Room>().HasKey(f => f.Id);
        builder.Entity<Room>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Room>().Property(f => f.HotelId).IsRequired();
        builder.Entity<Room>().Property(f => f.RoomNumber).IsRequired();
        builder.Entity<Room>().Property(f => f.Type).IsRequired();
        builder.Entity<Room>().Property(f => f.Status).IsRequired();
        

        builder.UseSnakeCaseNamingConvention();
    }
}