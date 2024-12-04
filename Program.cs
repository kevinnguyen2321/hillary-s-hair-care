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





app.Run();


