using System.ComponentModel.DataAnnotations;

namespace MonkeyMon_Blazor.Models;

public class Pokemon
{
    [Key]
    public int Id { get; set; }

    public double Height { get; set; } = 0;

    public double Weight { get; set; } = 0;

    public bool IsMale { get; set; } = false;

    public bool IsFemale { get; set; } = false;

    [StringLength(50)]
    public string Species { get; set; } = string.Empty;
    
    public PokemonSprite? Sprite { get; set; }

    [Required] 
    [StringLength(100)] 
    public string Name { get; set; } = null!;
    
    [StringLength(500)]
    public string? Description { get; set; }
    
    [Range(0, 2000)] 
    public ushort? Attack { get; set; }

    [Range(0, 2000)]
    public ushort? Defense { get; set; }

    [Range(0, 2000)]
    public ushort? SpecialAttack { get; set; }

    [Range(0, 2000)]
    public ushort? SpecialDefense { get; set; }

    [Range(0, 2000)]
    public ushort? Speed { get; set; }

    [Range(0, 2000)]
    public ushort? HealthPoints { get; set; }

    public ICollection<MonMove> Moves { get; set; } = [];
    
    public ICollection<MonType> Types { get; set; }
}