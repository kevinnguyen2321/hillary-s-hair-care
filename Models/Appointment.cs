using System.ComponentModel.DataAnnotations;

namespace HillaryHairCare.Models;

public class Appointment
{
    public int Id { get; set; }
    [Required]
    public int CustomerId { get; set; }
    [Required]
    public int StylistId { get; set; }
    public decimal TotalPrice { get; set; }
    public bool Canceled { get; set; }
    public DateTime ScheduledTime { get; set; }
    public List<Service> Services { get; set; } 
}