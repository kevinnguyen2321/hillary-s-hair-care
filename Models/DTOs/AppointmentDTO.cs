namespace HillaryHairCare.Models.DTOs;

public class AppointmentDTO
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public CustomerDTO Customer { get; set; }
    public int StylistId { get; set; }
    public StylistDTO Stylist { get; set; }
    public decimal TotalPrice { get; set; }
    public bool Canceled { get; set; }
    public DateTime ScheduledTime { get; set; }
    public List<ServiceDTO> Services { get; set; } 
}