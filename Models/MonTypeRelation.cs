using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonkeyMon_Blazor.Models;

public class MonTypeRelation
{
    [Key] 
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// A list of types this type has no effect on.
    /// </summary>
    public ICollection<MonType> NoDamageTo { get; set; }

    /// <summary>
    /// A list of types this type is not very effect against.
    /// </summary>
    public ICollection<MonType> HalfDamageTo { get; set; }

    /// <summary>
    /// A list of types this type is very effect against.
    /// </summary>
    public ICollection<MonType> DoubleDamageTo { get; set; }

    /// <summary>
    /// A list of types that have no effect on this type.
    /// </summary>
    public ICollection<MonType> NoDamageFrom { get; set; }

    /// <summary>
    /// A list of types that are not very effective against this type.
    /// </summary>
    public ICollection<MonType> HalfDamageFrom { get; set; }

    /// <summary>
    /// A list of types that are very effective against this type.
    /// </summary>
    public ICollection<MonType> DoubleDamageFrom { get; set; }
    
    // Navigation properties
    public MonType MonType { get; set; } = null!;

    public int MonTypeId { get; set; }
}