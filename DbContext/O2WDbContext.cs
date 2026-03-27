using O2W.Models.Event;
using O2W.Models.EventRegistrations;
using O2W.Models.Rating;
using O2W.Models.RiderProfile;
using O2W.Models.User;
using Route = O2W.Models.Route.Route;

namespace O2W.DbContext;

using Microsoft.EntityFrameworkCore;
using O2W.Models;

public class O2WDbContext : DbContext
{
    public O2WDbContext(DbContextOptions<O2WDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<RiderProfile> RiderProfiles { get; set; }
    public DbSet<Route> Routes { get; set; }
    public DbSet<Rating> Ratings { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<EventRegistration> EventRegistrations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // UNIQUE email
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        // 1-1 User - RiderProfile
        modelBuilder.Entity<User>()
            .HasOne(u => u.RiderProfile)
            .WithOne(rp => rp.User)
            .HasForeignKey<RiderProfile>(rp => rp.UserId);

        // Rating unique (User + Route)
        modelBuilder.Entity<Rating>()
            .HasIndex(r => new { r.UserId, r.RouteId })
            .IsUnique();

        // EventRegistration unique
        modelBuilder.Entity<EventRegistration>()
            .HasIndex(er => new { er.UserId, er.EventId })
            .IsUnique();
    }
}