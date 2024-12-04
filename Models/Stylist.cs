using System.ComponentModel.DataAnnotations;

namespace HillaryHairCare.Models;

public class Stylist
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public bool IsActive { get; set; }
}