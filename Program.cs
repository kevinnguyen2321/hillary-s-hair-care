using HillaryHairCare.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using HillaryHairCare.Models.DTOs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<HillaryHairCareDbContext>(builder.Configuration["HillaryHairCareDbConnectionString"]);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/stylists", (HillaryHairCareDbContext db) => {
  return db.Stylists
  .Where(s => s.IsActive)
  .Select(s => new StylistDTO
  {
    Id = s.Id,
    Name = s.Name,
    IsActive = s.IsActive
   }).ToList();
});

app.MapPost("/api/stylists", (HillaryHairCareDbContext db, Stylist stylist) => {
  stylist.IsActive = true;
  db.Stylists.Add(stylist);
  db.SaveChanges();
  return Results.Created($"/api/stylists/{stylist.Id}", stylist);

});

app.MapPut("/api/stylists/{id}/deactivate", (HillaryHairCareDbContext db, int id)=> {
  Stylist foundStylist = db.Stylists.FirstOrDefault(s => s.Id == id);

  if (foundStylist == null)
  {
    return Results.NotFound();
  }

 foundStylist.IsActive = false;
  db.SaveChanges();
  return Results.NoContent();

});

app.MapGet("/api/appointments", (HillaryHairCareDbContext db) => {
  return db.Appointments
  .Include(a => a.Customer)
  .Include(a => a.Stylist)
  .Include(a => a.AppointmentServices)
  .Where(a => !a.Canceled)
  .Select(a => new AppointmentDTO
  {
    Id = a.Id,
    CustomerId = a.CustomerId,
    Customer = new CustomerDTO
    {
      Id = a.Customer.Id,
      Name = a.Customer.Name
    },
    StylistId = a.StylistId,
    Stylist = new StylistDTO
    {
      Id = a.Stylist.Id,
      Name = a.Stylist.Name,
      IsActive = a.Stylist.IsActive
    },
    Canceled = a.Canceled,
    ScheduledTime = a.ScheduledTime,
    AppointmentServices = a.AppointmentServices.Select(aps => new AppointmentServiceDTO
    {
      Service = new ServiceDTO
      {
        Id = aps.Service.Id,
        Name = aps.Service.Name,
        Price = aps.Service.Price
      }

    }
    ).ToList()
  }
  ).ToList();

});


app.MapGet("/api/appointments/{id}", (HillaryHairCareDbContext db, int id)=> {
  Appointment foundAppt = db.Appointments
      .Include(a => a.Customer)
      .Include(a => a.Stylist)
      .Include(a => a.AppointmentServices)
      .ThenInclude(aps => aps.Service)
      .FirstOrDefault(a => a.Id == id);

  if (foundAppt == null)
  {
    return Results.NotFound();
  }

  return Results.Ok(new AppointmentDTO
  {
    Id = foundAppt.Id,
    CustomerId = foundAppt.CustomerId,
    Customer = new CustomerDTO
    {
      Id = foundAppt.Customer.Id,
      Name = foundAppt.Customer.Name,

    },
    StylistId = foundAppt.StylistId,
    Stylist = new StylistDTO
    {
      Id = foundAppt.Stylist.Id,
      Name = foundAppt.Stylist.Name,
      IsActive = foundAppt.Stylist.IsActive,
    },
    Canceled = foundAppt.Canceled,
    ScheduledTime = foundAppt.ScheduledTime,
    AppointmentServices = foundAppt.AppointmentServices.Select(aps => new AppointmentServiceDTO
    {
      ServiceId = aps.ServiceId,
      Service = new ServiceDTO
      {
        Id = aps.Service.Id,
        Name = aps.Service.Name,
        Price = aps.Service.Price
      }

    }).ToList()

  }
  );





});







app.Run();


