using System.ComponentModel.DataAnnotations;

namespace MonkeyMon_Blazor.Models;

public class Monkey
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required] 
    public string Name { get; set; } = null!;
    
    [Required]
    public string KnownFrom { get; set; }
    
    public string? Description { get; set; }
    
    public string? Weaknesses { get; set; }
    
    public ushort? Attack { get; set; }
    
    public ushort? Defense { get; set; }
    
    public ushort? SpecialAttack { get; set; }
    
    public ushort? SpecialDefense { get; set; }

    public ushort? Speed;
    
    public ushort? HealthPoints { get; set; }
    
    // TODO Image and Species
}