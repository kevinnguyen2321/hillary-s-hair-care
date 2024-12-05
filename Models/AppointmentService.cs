using System.ComponentModel.DataAnnotations;

namespace HillaryHairCare.Models;

public class AppointmentService
{
    [Key]
    public int Id { get; set; } 
    public int AppointmentId { get; set; }
    public Appointment Appointment { get; set; }
    public int ServiceId { get; set; }
    public Service Service { get; set; }
}
