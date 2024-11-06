using System.ComponentModel.DataAnnotations;

namespace MonkeyMon_Blazor.Models;

public class Monkey
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required] 
    [StringLength(50)]
    public string Name { get; set; } = null!;

    [Required] 
    [StringLength(100)] 
    public string KnownFrom { get; set; } = null!;
    
    [StringLength(500)]
    public string? Description { get; set; }
    
    public ushort? Attack { get; set; }
    
    public ushort? Defense { get; set; }
    
    public ushort? SpecialAttack { get; set; }
    
    public ushort? SpecialDefense { get; set; }

    public ushort? Speed { get; set; }
    
    public ushort? HealthPoints { get; set; }
    
    public Species? Species { get; set; }
    // TODO Image and Species
    
    // Navigation Properties
    public Guid? SpeciesId { get; set; }
}