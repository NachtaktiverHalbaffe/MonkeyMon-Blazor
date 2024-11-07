using System.ComponentModel.DataAnnotations;

namespace MonkeyMon_Blazor.Models;

public class Pokemon
{
    [Key]
    public int Id { get; set; }

    public int Weight { get; set; } = 0;
    
    public PokemonSpriteResponse? Sprite { get; set; }

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

    public ICollection<MonMoves> Moves { get; set; } = [];
    
    // Navigation Properties
    public Guid? SpriteId { get; set; } 
}