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

    [Range(0, 723)] 
    public ushort? Attack { get; set; }

    [Range(0, 654)]
    public ushort? Defense { get; set; }

    [Range(0, 624)]
    public ushort? SpecialAttack { get; set; }

    [Range(0, 654)]
    public ushort? SpecialDefense { get; set; }

    [Range(0, 854)]
    public ushort? Speed { get; set; }

    [Range(0, 714)]
    public ushort? HealthPoints { get; set; }

    public Species? Species { get; set; }
    // TODO Image and Species

    // Navigation Properties
    public Guid? SpeciesId { get; set; }
}