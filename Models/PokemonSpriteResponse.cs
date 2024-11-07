using System.ComponentModel.DataAnnotations;

namespace MonkeyMon_Blazor.Models;

public class PokemonSpriteResponse
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// The default depiction of this Pokémon from the front in battle.
    /// </summary>
    public string FrontDefault { get; set; } = string.Empty;

    /// <summary>
    /// The shiny depiction of this Pokémon from the front in battle.
    /// </summary>
    public string FrontShiny { get; set; } = string.Empty;

    /// <summary>
    /// The female depiction of this Pokémon from the front in battle.
    /// </summary>
    public string FrontFemale { get; set; } = string.Empty;

    /// <summary>
    /// The shiny female depiction of this Pokémon from the front in battle.
    /// </summary>
    public string FrontShinyFemale { get; set; } = string.Empty;

    /// <summary>
    /// The default depiction of this Pokémon from the back in battle.
    /// </summary>
    public string BackDefault { get; set; } = string.Empty;

    /// <summary>
    /// The shiny depiction of this Pokémon from the back in battle.
    /// </summary>
    public string BackShiny { get; set; } = string.Empty;

    /// <summary>
    /// The female depiction of this Pokémon from the back in battle.
    /// </summary>
    public string BackFemale { get; set; } = string.Empty;

    /// <summary>
    /// The shiny female depiction of this Pokémon from the back in battle.
    /// </summary>
    public string BackShinyFemale { get; set; } = string.Empty;

    // Navigation Properties
    public Pokemon Pokemon { get; set; } 
    
    public int PokedexEntryId { get; set; }
}