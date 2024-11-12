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

    public MonTypeRelation? MonTypeRelation { get; set; }

    // Navigation Properties

    /// <summary>
    /// A list of details of Pokémon that have this type.
    /// </summary>
    public ICollection<Pokemon> Pokemon { get; set; } = [];

    /// <summary>
    /// A list of moves that have this type.
    /// </summary>
    public ICollection<MonMove> Moves { get; set; } = [];
}