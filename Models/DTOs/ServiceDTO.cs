namespace HillaryHairCare.Models.DTOs;

public class ServiceDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; } 
    public List<AppointmentDTO> Appointments { get; set; }
}