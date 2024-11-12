using System.ComponentModel.DataAnnotations;

namespace MonkeyMon_Blazor.Models;

public class MonMove
{
    /// <summary>
    /// The identifier for this resource.
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// The name for this resource.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The percent value of how likely this move is to be successful.
    /// </summary>
    [Range(0, 100)]
    public int? Accuracy { get; set; }

    /// <summary>
    /// The percent value of how likely it is this moves effect will happen.
    /// </summary>
    [Range(0, 100)]
    public int? EffectChance { get; set; }

    /// <summary>
    /// Power points. The number of times this move can be used.
    /// </summary>
    [Range(0, 100)]
    public int? Pp { get; set; }

    /// <summary>
    /// A value between -8 and 8. Sets the order in which moves are executed
    /// during battle. See
    /// [Bulbapedia](http://bulbapedia.bulbagarden.net/wiki/Priority)
    /// for greater detail.
    /// </summary>
    [Range(-8, 8)]
    public int Priority { get; set; }

    /// <summary>
    /// The base power of this move with a value of 0 if it does not have
    /// a base power.
    /// </summary>
    [Range(0, 300)]
    public int? Power { get; set; }

    /// <summary>
    /// The type of damage the move inflicts on the target, e.g. physical.
    /// </summary>
    public string DamageClass { get; set; } = string.Empty;

    /// <summary>
    /// The effect of this move listed in different languages.
    /// </summary>
    public ICollection<string> EffectEntries { get; set; } = [];

    /// <summary>
    /// The flavor text of this move listed in different languages.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// The elemental type of this move.
    /// </summary>
    public MonType Type { get; set; }
    
    // Navigation Properties
    public int TypeId { get; set; }
}