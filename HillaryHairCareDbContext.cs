using Microsoft.EntityFrameworkCore;
namespace HillaryHairCare.Models;

public class HillaryHairCareDbContext : DbContext
{

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Stylist> Stylists { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Service> Services { get; set; }

    public HillaryHairCareDbContext(DbContextOptions<HillaryHairCareDbContext> context) : base(context)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Appointment>()
        .HasMany(a => a.Services)
        .WithMany(s => s.Appointments)
        .UsingEntity<Dictionary<string, object>>(
            "AppointmentService", // Implicit join table
            j => j.HasOne<Service>().WithMany().HasForeignKey("ServiceId"),
            j => j.HasOne<Appointment>().WithMany().HasForeignKey("AppointmentId")
        );
   
        modelBuilder.Entity<Customer>().HasData(new Customer[]
        {
            new Customer { Id = 1, Name = "Alice Johnson" },
            new Customer { Id = 2, Name = "Bob Smith" },
            new Customer { Id = 3, Name = "Charlie Davis" },
            new Customer { Id = 4, Name = "Diana Roberts" },
            new Customer { Id = 5, Name = "Edward Martinez" }
        });


        modelBuilder.Entity<Stylist>().HasData(new Stylist[]
        {
            new Stylist { Id = 1, Name = "Sophia Anderson", IsActive = true },
            new Stylist { Id = 2, Name = "Liam Thompson", IsActive = true },
            new Stylist { Id = 3, Name = "Olivia Brown", IsActive = true },
            new Stylist { Id = 4, Name = "Noah Wilson", IsActive = false },
            new Stylist { Id = 5, Name = "Emma Taylor", IsActive = true }
        });

        modelBuilder.Entity<Service>().HasData(new Service[]
        {
            new Service { Id = 1, Name = "Haircut", Price = 25.00m },
            new Service { Id = 2, Name = "Hair Coloring", Price = 75.00m },
            new Service { Id = 3, Name = "Beard Trim", Price = 15.00m },
            new Service { Id = 4, Name = "Blow Dry and Style", Price = 40.00m }
        });

        modelBuilder.Entity<Appointment>().HasData(new Appointment[]
        {
            new Appointment { Id = 1, CustomerId = 1, StylistId = 2, TotalPrice = 40.00m, Canceled = false, ScheduledTime = new DateTime(2024, 12, 5, 10, 0, 0) },
            new Appointment { Id = 2, CustomerId = 2, StylistId = 3, TotalPrice = 75.00m, Canceled = false, ScheduledTime = new DateTime(2024, 12, 5, 11, 0, 0) },
            new Appointment { Id = 3, CustomerId = 3, StylistId = 1, TotalPrice = 25.00m, Canceled = true, ScheduledTime = new DateTime(2024, 12, 6, 9, 0, 0) },
            new Appointment { Id = 4, CustomerId = 4, StylistId = 5, TotalPrice = 55.00m, Canceled = false, ScheduledTime = new DateTime(2024, 12, 7, 13, 0, 0) },
            new Appointment { Id = 5, CustomerId = 5, StylistId = 4, TotalPrice = 100.00m, Canceled = true, ScheduledTime = new DateTime(2024, 12, 8, 15, 0, 0) }
        });



    



    }
}