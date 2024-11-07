using System.ComponentModel.DataAnnotations;

namespace MonkeyMon_Blazor.Models;

public class MonType
{
    /// <summary>
    /// The identifier for this resource.
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// The name for this resource.
    /// </summary>
    [StringLength(100)]
    public string Name { get; set; }

    /// <summary>
    /// A list of types this type has no effect on.
    /// </summary>
    public ICollection<MonType> NoDamageTo { get; set; } = [];

    /// <summary>
    /// A list of types this type is not very effect against.
    /// </summary>
    public ICollection<MonType> HalfDamageTo { get; set; } = [];

    /// <summary>
    /// A list of types this type is very effect against.
    /// </summary>
    public ICollection<MonType> DoubleDamageTo { get; set; } = [];

    /// <summary>
    /// A list of types that have no effect on this type.
    /// </summary>
    public ICollection<MonType> NoDamageFrom { get; set; } = [];

    /// <summary>
    /// A list of types that are not very effective against this type.
    /// </summary>
    public ICollection<MonType> HalfDamageFrom { get; set; } = [];

    /// <summary>
    /// A list of types that are very effective against this type.
    /// </summary>
    public ICollection<MonType> DoubleDamageFrom { get; set; } = [];

    // Navigation Properties
    
    /// <summary>
    /// A list of details of Pokémon that have this type.
    /// </summary>
    public ICollection<Pokemon> Pokemon { get; set; }

    /// <summary>
    /// A list of moves that have this type.
    /// </summary>
    public ICollection<MonMoves> Moves { get; set; } 
}