using System.ComponentModel.DataAnnotations;

namespace HillaryHairCare.Models;

public class Appointment
{
    public int Id { get; set; }
    [Required]
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    [Required]
    public int StylistId { get; set; }
    public Stylist Stylist { get; set; }
    public decimal TotalPrice { get; set; }
    public bool Canceled { get; set; }
    public DateTime ScheduledTime { get; set; }
    public List<Service> Services { get; set; } 
}