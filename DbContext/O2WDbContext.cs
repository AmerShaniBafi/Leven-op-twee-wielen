using O2W.Models.Event;
using O2W.Models.EventRegistrations;
using O2W.Models.Rating;
using O2W.Models.RiderProfile;
using O2W.Models.MotorRoute;
using O2W.Models.User;
namespace O2W.DbContext;

using Microsoft.EntityFrameworkCore;
using O2W.Models;

public class O2WDbContext : DbContext
{
    public O2WDbContext(DbContextOptions<O2WDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<RiderProfile> RiderProfiles { get; set; }
    public DbSet<MotorRoute> MotorRoutes { get; set; }
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

        // Decimal precisie
        modelBuilder.Entity<MotorRoute>()
            .Property(r => r.AfstandKm)
            .HasPrecision(9, 2);

        modelBuilder.Entity<RiderProfile>()
            .Property(rp => rp.FavorieteRitafstand)
            .HasPrecision(9, 2);

        // Event → User (geen cascade)
        modelBuilder.Entity<Event>()
            .HasOne(e => e.CreatedByUser)
            .WithMany(u => u.CreatedEvents)
            .HasForeignKey(e => e.CreatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        // EventRegistration → User (geen cascade)
        modelBuilder.Entity<EventRegistration>()
            .HasOne(er => er.User)
            .WithMany(u => u.EventRegistrations)
            .HasForeignKey(er => er.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        // EventRegistration → Event (wel cascade)
        modelBuilder.Entity<EventRegistration>()
            .HasOne(er => er.Event)
            .WithMany(e => e.Registrations)
            .HasForeignKey(er => er.EventId)
            .OnDelete(DeleteBehavior.Cascade);

        // Rating → User (geen cascade)
        modelBuilder.Entity<Rating>()
            .HasOne(r => r.User)
            .WithMany(u => u.Ratings)
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        // Rating → MotorRoute (wel cascade)
        modelBuilder.Entity<Rating>()
            .HasOne(r => r.MotorRoute)
            .WithMany(mr => mr.Ratings)
            .HasForeignKey(r => r.RouteId)
            .OnDelete(DeleteBehavior.Cascade);
        
    }
}