using System.ComponentModel.DataAnnotations;

namespace MonkeyMon_Blazor.Models;

public class PokemonSprite
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// The default depiction of this Pokémon from the front in battle.
    /// </summary>
    public string? FrontDefault { get; set; } 

    /// <summary>
    /// The shiny depiction of this Pokémon from the front in battle.
    /// </summary>
    public string? FrontShiny { get; set; }

    /// <summary>
    /// The female depiction of this Pokémon from the front in battle.
    /// </summary>
    public string? FrontFemale { get; set; }

    /// <summary>
    /// The shiny female depiction of this Pokémon from the front in battle.
    /// </summary>
    public string? FrontShinyFemale { get; set; } 

    /// <summary>
    /// The default depiction of this Pokémon from the back in battle.
    /// </summary>
    public string? BackDefault { get; set; }

    /// <summary>
    /// The shiny depiction of this Pokémon from the back in battle.
    /// </summary>
    public string? BackShiny { get; set; }

    /// <summary>
    /// The female depiction of this Pokémon from the back in battle.
    /// </summary>
    public string? BackFemale { get; set; } 

    /// <summary>
    /// The shiny female depiction of this Pokémon from the back in battle.
    /// </summary>
    public string? BackShinyFemale { get; set; }

    // Navigation Properties
    public Pokemon Pokemon { get; set; } 
    
    public int PokemonId { get; set; }
}