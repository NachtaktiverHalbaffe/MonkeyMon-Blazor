
using System.Text.Json.Serialization;

namespace MonkeyMon_Blazor.Models;

/// <summary>
/// Abilities provide passive effects for Pokémon in battle or in
/// the overworld. Pokémon have multiple possible abilities but
/// can have only one ability at a time.
/// </summary>
public class AbilityResponse : PokeApiNamedApiResource
{
    /// <summary>
    /// The identifier for this resource.
    /// </summary>
    public override int Id { get; set; }

    internal new static string ApiEndpoint { get; } = "ability";

    /// <summary>
    /// The name for this resource.
    /// </summary>
    public override string Name { get; set; }

    /// <summary>
    /// Whether or not this ability originated in the main series of the video games.
    /// </summary>
    [JsonPropertyName("is_main_series")]
    public bool IsMainSeries { get; set; }

    /// <summary>
    /// The name of this resource listed in different languages.
    /// </summary>
    public List<NamesResponse> Names { get; set; }

    /// <summary>
    /// The effect of this ability listed in different languages.
    /// </summary>
    [JsonPropertyName("effect_entries")]
    public List<VerboseEffectResponse> EffectEntries { get; set; }

    /// <summary>
    /// The list of previous effects this ability has had across version groups.
    /// </summary>
    [JsonPropertyName("effect_changes")]
    public List<AbilityEffectChangeResponse> EffectChanges { get; set; }

    /// <summary>
    /// The flavor text of this ability listed in different languages.
    /// </summary>
    [JsonPropertyName("flavor_text_entries")]
    public List<AbilityFlavorTextResponse> FlavorTextEntries { get; set; }

    /// <summary>
    /// A list of Pokémon that could potentially have this ability.
    /// </summary>
    public List<AbilityPokemonResponse> Pokemon { get; set; }
}

/// <summary>
/// An ability and it's associated versions
/// </summary>
public class AbilityEffectChangeResponse
{
    /// <summary>
    /// The previous effect of this ability listed in different languages.
    /// </summary>
    [JsonPropertyName("effect_entries")]
    public List<EffectsResponse> EffectEntries { get; set; }
}

/// <summary>
/// The flavor text for an ability
/// </summary>
public class AbilityFlavorTextResponse
{
    /// <summary>
    /// The localized name for an API resource in a specific language.
    /// </summary>
    [JsonPropertyName("flavor_text")]
    public string FlavorText { get; set; }

    /// <summary>
    /// The language this text resource is in.
    /// </summary>
    public PokeApiNamedApiResource<PokeApiLanguage> Language { get; set; }
}

/// <summary>
/// A mapping of an ability to a possible Pokémon
/// </summary>
public class AbilityPokemonResponse
{
    /// <summary>
    /// Whether or not this a hidden ability for the referenced Pokémon.
    /// </summary>
    [JsonPropertyName("is_hidden")]
    public bool IsHidden { get; set; }

    /// <summary>
    /// Pokémon have 3 ability 'slots' which hold references to possible
    /// abilities they could have. This is the slot of this ability for the
    /// referenced pokemon.
    /// </summary>
    public int Slot { get; set; }

    /// <summary>
    /// The Pokémon this ability could belong to.
    /// </summary>
    public PokeApiNamedApiResource<PokemonResponse> Pokemon { get; set; }
}

/// <summary>
/// Characteristics indicate which stat contains a Pokémon's highest IV.
/// A Pokémon's Characteristic is determined by the remainder of its
/// highest IV divided by 5 (gene_modulo).
/// </summary>
public class CharacteristicResponse : PokeApiApiResource
{
    /// <summary>
    /// The identifier for this resource.
    /// </summary>
    public override int Id { get; set; }

    internal new static string ApiEndpoint { get; } = "characteristic";

    /// <summary>
    /// The remainder of the highest stat/IV divided by 5.
    /// </summary>
    [JsonPropertyName("gene_modulo")]
    public int GeneModulo { get; set; }

    /// <summary>
    /// The possible values of the highest stat that would result in
    /// a Pokémon recieving this characteristic when divided by 5.
    /// </summary>
    [JsonPropertyName("possible_values")]
    public List<int> PossibleValues { get; set; }

    /// <summary>
    /// The highest stat of this characteristic.
    /// </summary>
    [JsonPropertyName("highest_stat")]
    public PokeApiNamedApiResource<StatResponse> HighestStat { get; set; }

    /// <summary>
    /// The descriptions of this characteristic listed in different languages.
    /// </summary>
    public List<DescriptionsResponse> Descriptions { get; set; }
}

/// <summary>
/// Growth rates are the speed with which Pokémon gain levels through experience.
/// </summary>
public class GrowthRateResponse : PokeApiNamedApiResource
{
    /// <summary>
    /// The identifier for this resource.
    /// </summary>
    public override int Id { get; set; }

    internal new static string ApiEndpoint { get; } = "growth-rate";

    /// <summary>
    /// The name for this resource.
    /// </summary>
    public override string Name { get; set; }

    /// <summary>
    /// The formula used to calculate the rate at which the Pokémon species
    /// gains level.
    /// </summary>
    public string Formula { get; set; }

    /// <summary>
    /// The descriptions of this characteristic listed in different languages.
    /// </summary>
    public List<DescriptionsResponse> Descriptions { get; set; }

    /// <summary>
    /// A list of levels and the amount of experienced needed to atain them
    /// based on this growth rate.
    /// </summary>
    public List<GrowthRateExperienceLevelResponse> Levels { get; set; }

    /// <summary>
    /// A list of Pokémon species that gain levels at this growth rate.
    /// </summary>
    [JsonPropertyName("pokemon_species")]
    public List<PokeApiNamedApiResource<PokemonSpeciesResponse>> PokemonSpecies { get; set; }
}

/// <summary>
/// Information of a level and how much experience is needed to get to it
/// </summary>
public class GrowthRateExperienceLevelResponse
{
    /// <summary>
    /// The level gained.
    /// </summary>
    public int Level { get; set; }

    /// <summary>
    /// The amount of experience required to reach the referenced level.
    /// </summary>
    public int Experience { get; set; }
}

/// <summary>
/// Natures influence how a Pokémon's stats grow.
/// </summary>
public class NatureResponse : PokeApiNamedApiResource
{
    /// <summary>
    /// The identifier for this resource.
    /// </summary>
    public override int Id { get; set; }

    internal new static string ApiEndpoint { get; } = "nature";

    /// <summary>
    /// The name for this resource.
    /// </summary>
    public override string Name { get; set; }

    /// <summary>
    /// The stat decreased by 10% in Pokémon with this nature.
    /// </summary>
    [JsonPropertyName("decreased_stat")]
    public PokeApiNamedApiResource<StatResponse> DecreasedStat { get; set; }

    /// <summary>
    /// The stat increased by 10% in Pokémon with this nature.
    /// </summary>
    [JsonPropertyName("increased_stat")]
    public PokeApiNamedApiResource<StatResponse> IncreasedStat { get; set; }

    /// <summary>
    /// A list of Pokéathlon stats this nature effects and how much it
    /// effects them.
    /// </summary>
    [JsonPropertyName("pokeathlon_stat_changes")]
    public List<NatureStatChange> PokeathlonStatChanges { get; set; }

    /// <summary>
    /// A list of battle styles and how likely a Pokémon with this nature is
    /// to use them in the Battle Palace or Battle Tent.
    /// </summary>
    [JsonPropertyName("move_battle_style_preferences")]
    public List<MoveBattleStylePreferenceResponse> MoveBattleStylePreferences { get; set; }

    /// <summary>
    /// The name of this resource listed in different languages.
    /// </summary>
    public List<NamesResponse> Names { get; set; }
}

/// <summary>
/// The change information for a nature
/// </summary>
public class NatureStatChange
{
    /// <summary>
    /// The amount of change.
    /// </summary>
    [JsonPropertyName("max_changes")]
    public int MaxChange { get; set; }
}

/// <summary>
/// Move information for a battle style
/// </summary>
public class MoveBattleStylePreferenceResponse
{
    /// <summary>
    /// Chance of using the move, in percent, if HP is under one half.
    /// </summary>
    [JsonPropertyName("low_hp_preference")]
    public int LowHpPreference { get; set; }

    /// <summary>
    /// Chance of using the move, in percent, if HP is over one half.
    /// </summary>
    [JsonPropertyName("high_hp_preference")]
    public int HighHpPreference { get; set; }

    /// <summary>
    /// The move battle style.
    /// </summary>
    [JsonPropertyName("move_battle_style")]
    public PokeApiNamedApiResource<MoveBattleStyleResponse> MoveBattleStyle { get; set; }
}

/// <summary>
/// Pokémon are the creatures that inhabit the world of the Pokémon games.
/// They can be caught using Pokéballs and trained by battling with other Pokémon.
/// Each Pokémon belongs to a specific species but may take on a variant which
/// makes it differ from other Pokémon of the same species, such as base stats,
/// available abilities and typings.
/// </summary>
public class PokemonResponse : PokeApiNamedApiResource
{
    /// <summary>
    /// The identifier for this resource.
    /// </summary>
    public override int Id { get; set; }

    internal new static string ApiEndpoint { get; } = "pokemon";

    /// <summary>
    /// The name for this resource.
    /// </summary>
    public override string Name { get; set; }

    /// <summary>
    /// The base experience gained for defeating this Pokémon.
    /// </summary>
    [JsonPropertyName("base_experience")]
    public int? BaseExperience { get; set; }

    /// <summary>
    /// The height of this Pokémon in decimetres.
    /// </summary>
    public int Height { get; set; }

    /// <summary>
    /// Set for exactly one Pokémon used as the default for each species.
    /// </summary>
    [JsonPropertyName("is_default")]
    public bool IsDefault { get; set; }

    /// <summary>
    /// Order for sorting. Almost national order, except families
    /// are grouped together.
    /// </summary>
    public int Order { get; set; }

    /// <summary>
    /// The weight of this Pokémon in hectograms.
    /// </summary>
    public int Weight { get; set; }

    /// <summary>
    /// A list of abilities this Pokémon could potentially have.
    /// </summary>
    public List<PokemonAbilityResponse> Abilities { get; set; }

    /// <summary>
    /// A list of forms this Pokémon can take on.
    /// </summary>
    public List<PokeApiNamedApiResource<PokemonFormResponse>> Forms { get; set; }

    /// <summary>
    /// A set of sprites used to depict this Pokémon in the game.
    /// </summary>
    public PokemonSpritesResponse SpritesResponse { get; set; }

    /// <summary>
    /// The species this Pokémon belongs to.
    /// </summary>
    public PokeApiNamedApiResource<PokemonSpeciesResponse> Species { get; set; }

    /// <summary>
    /// A list of base stat values for this Pokémon.
    /// </summary>
    public List<PokemonStatResponse> Stats { get; set; }

    /// <summary>
    /// A list of details showing types this Pokémon has.
    /// </summary>
    public List<PokemonTypeResponse> Types { get; set; }
}

/// <summary>
/// A Pokémon ability
/// </summary>
public class PokemonAbilityResponse
{
    /// <summary>
    /// Whether or not this is a hidden ability.
    /// </summary>
    [JsonPropertyName("is_hidden")]
    public bool IsHidden { get; set; }

    /// <summary>
    /// The slot this ability occupies in this Pokémon species.
    /// </summary>
    public int Slot { get; set; }

    /// <summary>
    /// The ability the Pokémon may have.
    /// </summary>
    public PokeApiNamedApiResource<AbilityResponse> Ability { get; set; }
}

/// <summary>
/// A Pokémon type
/// </summary>
public class PokemonTypeResponse
{
    /// <summary>
    /// The order the Pokémon's types are listed in.
    /// </summary>
    public int Slot { get; set; }

    /// <summary>
    /// The type the referenced Pokémon has.
    /// </summary>
    public PokeApiNamedApiResource<TypeResponse> Type { get; set; }
}

/// <summary>
/// A Pokémon stat
/// </summary>
public class PokemonStatResponse
{
    /// <summary>
    /// The stat the Pokémon has.
    /// </summary>
    public PokeApiNamedApiResource<StatResponse> Stat { get; set; }

    /// <summary>
    /// The effort points (EV) the Pokémon has in the stat.
    /// </summary>
    public int Effort { get; set; }

    /// <summary>
    /// The base value of the stat.
    /// </summary>
    [JsonPropertyName("base_stat")]
    public int BaseStat { get; set; }
}

/// <summary>
/// Pokémon sprite information
/// </summary>
public class PokemonSpritesResponse
{
    /// <summary>
    /// The default depiction of this Pokémon from the front in battle.
    /// </summary>
    [JsonPropertyName("front_default")]
    public string FrontDefault { get; set; }

    /// <summary>
    /// The shiny depiction of this Pokémon from the front in battle.
    /// </summary>
    [JsonPropertyName("front_shiny")]
    public string FrontShiny { get; set; }

    /// <summary>
    /// The female depiction of this Pokémon from the front in battle.
    /// </summary>
    [JsonPropertyName("front_female")]
    public string FrontFemale { get; set; }

    /// <summary>
    /// The shiny female depiction of this Pokémon from the front in battle.
    /// </summary>
    [JsonPropertyName("front_shiny_female")]
    public string FrontShinyFemale { get; set; }

    /// <summary>
    /// The default depiction of this Pokémon from the back in battle.
    /// </summary>
    [JsonPropertyName("back_default")]
    public string BackDefault { get; set; }

    /// <summary>
    /// The shiny depiction of this Pokémon from the back in battle.
    /// </summary>
    [JsonPropertyName("back_shiny")]
    public string BackShiny { get; set; }

    /// <summary>
    /// The female depiction of this Pokémon from the back in battle.
    /// </summary>
    [JsonPropertyName("back_female")]
    public string BackFemale { get; set; }

    /// <summary>
    /// The shiny female depiction of this Pokémon from the back in battle.
    /// </summary>
    [JsonPropertyName("back_shiny_female")]
    public string BackShinyFemale { get; set; }

    /// <summary>
    /// Other sprites
    /// </summary>
    public OtherSpritesResponse Other { get; set; }

    /// <summary>
    /// Pókemon sprites versioned by game generation
    /// </summary>
    public VersionSpritesResponse Versions { get; set; }

    /// <summary>
    /// Other Pokémon sprites
    /// </summary>
    public class OtherSpritesResponse
    {
        /// <summary>
        /// DreamWorld sprites
        /// </summary>
        [JsonPropertyName("dream_world")]
        public DreamWorldSpritesResponse DreamWorld { get; set; }

        /// <summary>
        /// Home sprites
        /// </summary>
        public HomeSpritesResponse Home { get; set; }

        /// <summary>
        /// Official Artwork sprites
        /// </summary>
        [JsonPropertyName("official-artwork")]
        public OfficialArtworkSpritesResponse OfficialArtwork { get; set; }

        /// <summary>
        /// DreamWorld Pókemon sprites
        /// </summary>
        public class DreamWorldSpritesResponse
        {
            /// <summary>
            /// The default depiction of this Pokémon from the front in battle.
            /// </summary>
            [JsonPropertyName("front_default")]
            public string FrontDefault { get; set; }

            /// <summary>
            /// The female depiction of this Pokémon from the front in battle.
            /// </summary>
            [JsonPropertyName("front_female")]
            public string FrontFemale { get; set; }
        }

        /// <summary>
        /// Home Pókemon sprites
        /// </summary>
        public class HomeSpritesResponse
        {
            /// <summary>
            /// The default depiction of this Pokémon from the front in battle.
            /// </summary>
            [JsonPropertyName("front_default")]
            public string FrontDefault { get; set; }

            /// <summary>
            /// The female depiction of this Pokémon from the front in battle.
            /// </summary>
            [JsonPropertyName("front_female")]
            public string FrontFemale { get; set; }

            /// <summary>
            /// The shiny depiction of this Pokémon from the front in battle.
            /// </summary>
            [JsonPropertyName("front_shiny")]
            public string FrontShiny { get; set; }

            /// <summary>
            /// The shiny female depiction of this Pokémon from the front in battle.
            /// </summary>
            [JsonPropertyName("front_shiny_female")]
            public string FrontShinyFemale { get; set; }
        }

        /// <summary>
        /// Official Artwork sprites
        /// </summary>
        public class OfficialArtworkSpritesResponse
        {
            /// <summary>
            /// The default depiction of this Pokémon from the front in battle.
            /// </summary>
            [JsonPropertyName("front_default")]
            public string FrontDefault { get; set; }
                
            /// <summary>
            /// The shiny depiction of this Pokémon from the front in battle.
            /// </summary>
            [JsonPropertyName("front_shiny")]
            public string FrontShiny { get; set; }
        }
    }

    /// <summary>
    /// Pókemon sprites versioned by game generation
    /// </summary>
    public class VersionSpritesResponse
    {
        /// <summary>
        /// Pókemon sprites for Generation I
        /// </summary>
        [JsonPropertyName("generation-i")]
        public GenerationISpritesResponse GenerationI { get; set; }

        /// <summary>
        /// Pókemon sprites for Generation II
        /// </summary>
        [JsonPropertyName("generation-ii")]
        public GenerationIISpritesResponse GenerationII { get; set; }

        /// <summary>
        /// Pókemon sprites for Generation III
        /// </summary>
        [JsonPropertyName("generation-iii")]
        public GenerationIIISpritesResponse GenerationIII { get; set; }

        /// <summary>
        /// Pókemon sprites for Generation IV
        /// </summary>
        [JsonPropertyName("generation-iv")]
        public GenerationIVSpritesResponse GenerationIV { get; set; }

        /// <summary>
        /// Pókemon sprites for Generation V
        /// </summary>
        [JsonPropertyName("generation-v")]
        public GenerationVSpritesResponse GenerationV { get; set; }

        /// <summary>
        /// Pókemon sprites for Generation VI
        /// </summary>
        [JsonPropertyName("generation-vi")]
        public GenerationVISpritesResponse GenerationVI { get; set; }

        /// <summary>
        /// Pókemon sprites for Generation VII
        /// </summary>
        [JsonPropertyName("generation-vii")]
        public GenerationVIISpritesResponse GenerationVII { get; set; }

        /// <summary>
        /// Pókemon sprites for Generation VIII
        /// </summary>
        [JsonPropertyName("generation-viii")]
        public GenerationVIIISpritesResponse GenerationVIII { get; set; }

        /// <summary>
        /// Pókemon sprites for Generation I
        /// </summary>
        public class GenerationISpritesResponse
        {
            /// <summary>
            /// Pókemon Red-Blue sprites
            /// </summary>
            [JsonPropertyName("red-blue")]
            public RedBlueSpritesResponse RedBlue { get; set; }

            /// <summary>
            /// Pókemon Yellow sprites
            /// </summary>
            public YellowSpritesResponse Yellow { get; set; }

            /// <summary>
            /// Pókemon Red-Blue sprites
            /// </summary>
            public class RedBlueSpritesResponse
            {
                /// <summary>
                /// The default depiction of this Pokémon from the back in battle.
                /// </summary>
                [JsonPropertyName("back_default")]
                public string BackDefault { get; set; }

                /// <summary>
                /// The default depiction of this Pokémon from the back in battle on gray background.
                /// </summary>
                [JsonPropertyName("back_gray")]
                public string BackGray { get; set; }

                /// <summary>
                /// The default depiction of this Pokémon from the back in battle on transparent background.
                /// </summary>
                [JsonPropertyName("back_transparent")]
                public string BackTransparent { get; set; }

                /// <summary>
                /// The default depiction of this Pokémon from the front in battle.
                /// </summary>
                [JsonPropertyName("front_default")]
                public string FrontDefault { get; set; }

                /// <summary>
                /// The default depiction of this Pokémon from the front in battle on gray background.
                /// </summary>
                [JsonPropertyName("front_gray")]
                public string FrontGray { get; set; }

                /// <summary>
                /// The default depiction of this Pokémon from the front in battle on transparent background.
                /// </summary>
                [JsonPropertyName("front_transparent")]
                public string FrontTransparent { get; set; }

            }

            /// <summary>
            /// Pókemon Yellow sprites
            /// </summary>
            public class YellowSpritesResponse
            {
                /// <summary>
                /// The default depiction of this Pokémon from the back in battle.
                /// </summary>
                [JsonPropertyName("back_default")]
                public string BackDefault { get; set; }

                /// <summary>
                /// The default depiction of this Pokémon from the back in battle on gray background.
                /// </summary>
                [JsonPropertyName("back_gray")]
                public string BackGray { get; set; }

                /// <summary>
                /// The default depiction of this Pokémon from the back in battle on transparent background.
                /// </summary>
                [JsonPropertyName("back_transparent")]
                public string BackTransparent { get; set; }

                /// <summary>
                /// The default depiction of this Pokémon from the front in battle.
                /// </summary>
                [JsonPropertyName("front_default")]
                public string FrontDefault { get; set; }

                /// <summary>
                /// The default depiction of this Pokémon from the front in battle on gray background.
                /// </summary>
                [JsonPropertyName("front_gray")]
                public string FrontGray { get; set; }

                /// <summary>
                /// The default depiction of this Pokémon from the front in battle on transparent background.
                /// </summary>
                [JsonPropertyName("front_transparent")]
                public string FrontTransparent { get; set; }
            }
        }

        /// <summary>
        /// Pókemon sprites for Generation II
        /// </summary>
        public class GenerationIISpritesResponse
        {
            /// <summary>
            /// Pókemon Crystal sprites
            /// </summary>
            public CrystalSprites Crystal { get; set; }

            /// <summary>
            /// Pókemon Gold sprites
            /// </summary>
            public GoldSpritesResponse Gold { get; set; }

            /// <summary>
            /// Pókemon Silver sprites
            /// </summary>
            public SilverSpritesResponse Silver { get; set; }

            /// <summary>
            /// Pókemon Crystal sprites
            /// </summary>
            public class CrystalSprites
            {
                /// <summary>
                /// The default depiction of this Pokémon from the back in battle.
                /// </summary>
                [JsonPropertyName("back_default")]
                public string BackDefault { get; set; }

                /// <summary>
                /// The default depiction of this Pokémon from the back shiny in battle.
                /// </summary>
                [JsonPropertyName("back_shiny")]
                public string BackShiny { get; set; }

                /// <summary>
                /// The default depiction of this Pokémon from the back shiny in battle on transparent background.
                /// </summary>
                [JsonPropertyName("back_shiny_transparent")]
                public string BackShinyTransparent { get; set; }

                /// <summary>
                /// The default depiction of this Pokémon from the back in battle on transparent background.
                /// </summary>
                [JsonPropertyName("back_transparent")]
                public string BackTransparent { get; set; }

                /// <summary>
                /// The default depiction of this Pokémon from the front in battle.
                /// </summary>
                [JsonPropertyName("front_default")]
                public string FrontDefault { get; set; }

                /// <summary>
                /// The default depiction of this Pokémon from the front shiny in battle.
                /// </summary>
                [JsonPropertyName("front_shiny")]
                public string FrontShiny { get; set; }

                /// <summary>
                /// The default depiction of this Pokémon from the front shiny in battle on transparent background.
                /// </summary>
                [JsonPropertyName("front_shiny_transparent")]
                public string FrontShinyTransparent { get; set; }

                /// <summary>
                /// The default depiction of this Pokémon from the front in battle on transparent background.
                /// </summary>
                [JsonPropertyName("front_transparent")]
                public string FrontTransparent { get; set; }

            }

            /// <summary>
            /// Pókemon Gold sprites
            /// </summary>
            public class GoldSpritesResponse
            {
                /// <summary>
                /// The default depiction of this Pokémon from the back in battle.
                /// </summary>
                [JsonPropertyName("back_default")]
                public string BackDefault { get; set; }

                /// <summary>
                /// The default depiction of this Pokémon from the back shiny in battle.
                /// </summary>
                [JsonPropertyName("back_shiny")]
                public string BackShiny { get; set; }

                /// <summary>
                /// The default depiction of this Pokémon from the front in battle.
                /// </summary>
                [JsonPropertyName("front_default")]
                public string FrontDefault { get; set; }

                /// <summary>
                /// The default depiction of this Pokémon from the front shiny in battle.
                /// </summary>
                [JsonPropertyName("front_shiny")]
                public string FrontShiny { get; set; }

                /// <summary>
                /// The default depiction of this Pokémon from the front in battle on transparent background.
                /// </summary>
                [JsonPropertyName("front_transparent")]
                public string FrontTransparent { get; set; }
            }

            /// <summary>
            /// Pókemon Silver sprites
            /// </summary>
            public class SilverSpritesResponse
            {
                /// <summary>
                /// The default depiction of this Pokémon from the back in battle.
                /// </summary>
                [JsonPropertyName("back_default")]
                public string BackDefault { get; set; }

                /// <summary>
                /// The default depiction of this Pokémon from the back shiny in battle.
                /// </summary>
                [JsonPropertyName("back_shiny")]
                public string BackShiny { get; set; }

                /// <summary>
                /// The default depiction of this Pokémon from the front in battle.
                /// </summary>
                [JsonPropertyName("front_default")]
                public string FrontDefault { get; set; }

                /// <summary>
                /// The default depiction of this Pokémon from the front shiny in battle.
                /// </summary>
                [JsonPropertyName("front_shiny")]
                public string FrontShiny { get; set; }

                /// <summary>
                /// The default depiction of this Pokémon from the front in battle on transparent background.
                /// </summary>
                [JsonPropertyName("front_transparent")]
                public string FrontTransparent { get; set; }
            }
        }

        /// <summary>
        /// Pókemon sprites for Generation III
        /// </summary>
        public class GenerationIIISpritesResponse
        {
            /// <summary>
            /// Pókemon Emerald sprites
            /// </summary>
            [JsonPropertyName("emerald")]
            public EmeraldSpritesResponse Emerald { get; set; }

            /// <summary>
            /// Pókemon Firered/Leafgreen sprites
            /// </summary>
            [JsonPropertyName("firered-leafgreen")]
            public FireredLeafgreenSpritesResponse FireredLeafgreen { get; set; }

            /// <summary>
            /// Pókemon Ruby/Sapphire sprites
            /// </summary>
            [JsonPropertyName("ruby-sapphire")]
            public RubySapphireSpritesResponse RubySapphire { get; set; }

            /// <summary>
            /// Pókemon Emerald sprites
            /// </summary>
            public class EmeraldSpritesResponse
            {
                /// <summary>
                /// The default depiction of this Pokémon from the front in battle.
                /// </summary>
                [JsonPropertyName("front_default")]
                public string FrontDefault { get; set; }

                /// <summary>
                /// The default depiction of this Pokémon from the front shiny in battle.
                /// </summary>
                [JsonPropertyName("front_shiny")]
                public string FrontShiny { get; set; }
            }

            /// <summary>
            /// Pókemon Firered/Leafgreen sprites
            /// </summary>
            public class FireredLeafgreenSpritesResponse
            {
                /// <summary>
                /// The default depiction of this Pokémon from the back in battle.
                /// </summary>
                [JsonPropertyName("back_default")]
                public string BackDefault { get; set; }

                /// <summary>
                /// The default depiction of this Pokémon from the back shiny in battle.
                /// </summary>
                [JsonPropertyName("back_shiny")]
                public string BackShiny { get; set; }

                /// <summary>
                /// The default depiction of this Pokémon from the front in battle.
                /// </summary>
                [JsonPropertyName("front_default")]
                public string FrontDefault { get; set; }

                /// <summary>
                /// The default depiction of this Pokémon from the front shiny in battle.
                /// </summary>
                [JsonPropertyName("front_shiny")]
                public string FrontShiny { get; set; }
            }

            /// <summary>
            /// Pókemon Ruby/Sapphire sprites
            /// </summary>
            public class RubySapphireSpritesResponse
            {
                /// <summary>
                /// The default depiction of this Pokémon from the back in battle.
                /// </summary>
                [JsonPropertyName("back_default")]
                public string BackDefault { get; set; }

                /// <summary>
                /// The default depiction of this Pokémon from the back shiny in battle.
                /// </summary>
                [JsonPropertyName("back_shiny")]
                public string BackShiny { get; set; }

                /// <summary>
                /// The default depiction of this Pokémon from the front in battle.
                /// </summary>
                [JsonPropertyName("front_default")]
                public string FrontDefault { get; set; }

                /// <summary>
                /// The default depiction of this Pokémon from the front shiny in battle.
                /// </summary>
                [JsonPropertyName("front_shiny")]
                public string FrontShiny { get; set; }
            }
        }

        /// <summary>
        /// Pókemon sprites for Generation IV
        /// </summary>
        public class GenerationIVSpritesResponse
        {
            /// <summary>
            /// Pókemon Diamond/Pearl sprites
            /// </summary>
            [JsonPropertyName("diamond-pearl")]
            public DiamondPearlSpritesResponse DiamondPearl { get; set; }

            /// <summary>
            /// Pókemon Heartgold/Soulsilver sprites
            /// </summary>
            [JsonPropertyName("heartgold-soulsilver")]
            public HeartGoldSoulSilverSpritesResponse HeartGoldSoulSilver { get; set; }

            /// <summary>
            /// Pókemon Platinum sprites
            /// </summary>
            public PlatinumSpritesResponse Platinum { get; set; }

            /// <summary>
            /// Pókemon Diamond/Pearl sprites
            /// </summary>
            public class DiamondPearlSpritesResponse
            {
                /// <summary>
                /// The default depiction of this Pokémon from the back in battle.
                /// </summary>
                [JsonPropertyName("back_default")]
                public string BackDefault { get; set; }

                /// <summary>
                /// The default depiction of this Pokémon from the back female in battle.
                /// </summary>
                [JsonPropertyName("back_female")]
                public string BackFemale { get; set; }

                /// <summary>
                /// The default depiction of this Pokémon from the back shiny in battle.
                /// </summary>
                [JsonPropertyName("back_shiny")]
                public string BackShiny { get; set; }

                /// <summary>
                /// The default depiction of this Pokémon from the back female shiny in battle.
                /// </summary>
                [JsonPropertyName("back_shiny_female")]
                public string BackShinyFemale { get; set; }

                /// <summary>
                /// The default depiction of this Pokémon from the front in battle.
                /// </summary>
                [JsonPropertyName("front_default")]
                public string FrontDefault { get; set; }

                /// <summary>
                /// The default depiction of this Pokémon from the front female in battle.
                /// </summary>
                [JsonPropertyName("front_female")]
                public string FrontFemale { get; set; }

                /// <summary>
                /// The default depiction of this Pokémon from the front shiny in battle.
                /// </summary>
                [JsonPropertyName("front_shiny")]
                public string FrontShiny { get; set; }

                // <summary>
                /// The default depiction of this Pokémon from the front female shiny in battle.
                /// </summary>
                [JsonPropertyName("front_shiny_female")]
                public string FrontShinyFemale { get; set; }
            }

            /// <summary>
            /// Pókemon Heartgold/Soulsilver sprites
            /// </summary>
            public class HeartGoldSoulSilverSpritesResponse
            {
                /// <summary>
                /// The default depiction of this Pokémon from the back in battle.
                /// </summary>
                [JsonPropertyName("back_default")]
                public string BackDefault { get; set; }

                /// <summary>
                /// The default depiction of this Pokémon from the back female in battle.
                /// </summary>
                [JsonPropertyName("back_female")]
                public string BackFemale { get; set; }

                /// <summary>
                /// The default depiction of this Pokémon from the back shiny in battle.
                /// </summary>
                [JsonPropertyName("back_shiny")]
                public string BackShiny { get; set; }

                /// <summary>
                /// The default depiction of this Pokémon from the back female shiny in battle.
                /// </summary>
                [JsonPropertyName("back_shiny_female")]
                public string BackShinyFemale { get; set; }

                /// <summary>
                /// The default depiction of this Pokémon from the front in battle.
                /// </summary>
                [JsonPropertyName("front_default")]
                public string FrontDefault { get; set; }

                /// <summary>
                /// The default depiction of this Pokémon from the front female in battle.
                /// </summary>
                [JsonPropertyName("front_female")]
                public string FrontFemale { get; set; }

                /// <summary>
                /// The default depiction of this Pokémon from the front shiny in battle.
                /// </summary>
                [JsonPropertyName("front_shiny")]
                public string FrontShiny { get; set; }

                // <summary>
                /// The default depiction of this Pokémon from the front female shiny in battle.
                /// </summary>
                [JsonPropertyName("front_shiny_female")]
                public string FrontShinyFemale { get; set; }
            }

            /// <summary>
            /// Pókemon Platinum sprites
            /// </summary>
            public class PlatinumSpritesResponse
            {
                /// <summary>
                /// The default depiction of this Pokémon from the back in battle.
                /// </summary>
                [JsonPropertyName("back_default")]
                public string BackDefault { get; set; }

                /// <summary>
                /// The default depiction of this Pokémon from the back female in battle.
                /// </summary>
                [JsonPropertyName("back_female")]
                public string BackFemale { get; set; }

                /// <summary>
                /// The default depiction of this Pokémon from the back shiny in battle.
                /// </summary>
                [JsonPropertyName("back_shiny")]
                public string BackShiny { get; set; }

                /// <summary>
                /// The default depiction of this Pokémon from the back female shiny in battle.
                /// </summary>
                [JsonPropertyName("back_shiny_female")]
                public string BackShinyFemale { get; set; }

                /// <summary>
                /// The default depiction of this Pokémon from the front in battle.
                /// </summary>
                [JsonPropertyName("front_default")]
                public string FrontDefault { get; set; }

                /// <summary>
                /// The default depiction of this Pokémon from the front female in battle.
                /// </summary>
                [JsonPropertyName("front_female")]
                public string FrontFemale { get; set; }

                /// <summary>
                /// The default depiction of this Pokémon from the front shiny in battle.
                /// </summary>
                [JsonPropertyName("front_shiny")]
                public string FrontShiny { get; set; }

                // <summary>
                /// The default depiction of this Pokémon from the front female shiny in battle.
                /// </summary>
                [JsonPropertyName("front_shiny_female")]
                public string FrontShinyFemale { get; set; }
            }
        }

        /// <summary>
        /// Pókemon sprites for Generation V
        /// </summary>
        public class GenerationVSpritesResponse
        {
            /// <summary>
            /// Pókemon Black/White sprites
            /// </summary>
            [JsonPropertyName("black-white")]
            public BlackWhiteSpritesResponse BlackWhite { get; set; }

            /// <summary>
            /// Pókemon Black/White sprites
            /// </summary>
            public class BlackWhiteSpritesResponse
            {
                /// <summary>
                /// The animated depiction of this Pokémon from the back in battle.
                /// </summary>
                public AnimatedSpritesResponse Animated { get; set; }

                /// <summary>
                /// The default depiction of this Pokémon from the back in battle.
                /// </summary>
                [JsonPropertyName("back_default")]
                public string BackDefault { get; set; }

                /// <summary>
                /// The default depiction of this Pokémon from the back female in battle.
                /// </summary>
                [JsonPropertyName("back_female")]
                public string BackFemale { get; set; }

                /// <summary>
                /// The default depiction of this Pokémon from the back shiny in battle.
                /// </summary>
                [JsonPropertyName("back_shiny")]
                public string BackShiny { get; set; }

                /// <summary>
                /// The default depiction of this Pokémon from the back female shiny in battle.
                /// </summary>
                [JsonPropertyName("back_shiny_female")]
                public string BackShinyFemale { get; set; }

                /// <summary>
                /// The default depiction of this Pokémon from the front in battle.
                /// </summary>
                [JsonPropertyName("front_default")]
                public string FrontDefault { get; set; }

                /// <summary>
                /// The default depiction of this Pokémon from the front female in battle.
                /// </summary>
                [JsonPropertyName("front_female")]
                public string FrontFemale { get; set; }

                /// <summary>
                /// The default depiction of this Pokémon from the front shiny in battle.
                /// </summary>
                [JsonPropertyName("front_shiny")]
                public string FrontShiny { get; set; }

                // <summary>
                /// The default depiction of this Pokémon from the front female shiny in battle.
                /// </summary>
                [JsonPropertyName("front_shiny_female")]
                public string FrontShinyFemale { get; set; }

                /// <summary>
                /// The animated depiction of this Pokémon from the back in battle.
                /// </summary>
                public class AnimatedSpritesResponse
                {
                    /// <summary>
                    /// The default depiction of this Pokémon from the back in battle.
                    /// </summary>
                    [JsonPropertyName("back_default")]
                    public string BackDefault { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the back female in battle.
                    /// </summary>
                    [JsonPropertyName("back_female")]
                    public string BackFemale { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the back shiny in battle.
                    /// </summary>
                    [JsonPropertyName("back_shiny")]
                    public string BackShiny { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the back female shiny in battle.
                    /// </summary>
                    [JsonPropertyName("back_shiny_female")]
                    public string BackShinyFemale { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the front in battle.
                    /// </summary>
                    [JsonPropertyName("front_default")]
                    public string FrontDefault { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the front female in battle.
                    /// </summary>
                    [JsonPropertyName("front_female")]
                    public string FrontFemale { get; set; }

                    /// <summary>
                    /// The default depiction of this Pokémon from the front shiny in battle.
                    /// </summary>
                    [JsonPropertyName("front_shiny")]
                    public string FrontShiny { get; set; }

                    // <summary>
                    /// The default depiction of this Pokémon from the front female shiny in battle.
                    /// </summary>
                    [JsonPropertyName("front_shiny_female")]
                    public string FrontShinyFemale { get; set; }
                }
            }
        }

        /// <summary>
        /// Pókemon sprites for Generation VI
        /// </summary>
        public class GenerationVISpritesResponse
        {
            /// <summary>
            /// Pókemon OmegaRuby/AlphaSapphire sprites
            /// </summary>
            [JsonPropertyName("omegaruby-alphasapphire")]
            public OmegaRubyAlphaSapphireSpritesResponse OmegaRubyAlphaSapphire { get; set; }

            /// <summary>
            /// Pókemon X/Y sprites
            /// </summary>
            [JsonPropertyName("x-y")]
            public XYSpritesResponse XY { get; set; }

            /// <summary>
            /// Pókemon OmegaRuby/AlphaSapphire sprites
            /// </summary>
            public class OmegaRubyAlphaSapphireSpritesResponse
            {
                /// <summary>
                /// The default depiction of this Pokémon from the front in battle.
                /// </summary>
                [JsonPropertyName("front_default")]
                public string FrontDefault { get; set; }

                /// <summary>
                /// The default depiction of this Pokémon from the front female in battle.
                /// </summary>
                [JsonPropertyName("front_female")]
                public string FrontFemale { get; set; }

                /// <summary>
                /// The default depiction of this Pokémon from the front shiny in battle.
                /// </summary>
                [JsonPropertyName("front_shiny")]
                public string FrontShiny { get; set; }

                // <summary>
                /// The default depiction of this Pokémon from the front female shiny in battle.
                /// </summary>
                [JsonPropertyName("front_shiny_female")]
                public string FrontShinyFemale { get; set; }
            }

            /// <summary>
            /// Pókemon X/Y sprites
            /// </summary>
            public class XYSpritesResponse
            {
                /// <summary>
                /// The default depiction of this Pokémon from the front in battle.
                /// </summary>
                [JsonPropertyName("front_default")]
                public string FrontDefault { get; set; }

                /// <summary>
                /// The default depiction of this Pokémon from the front female in battle.
                /// </summary>
                [JsonPropertyName("front_female")]
                public string FrontFemale { get; set; }

                /// <summary>
                /// The default depiction of this Pokémon from the front shiny in battle.
                /// </summary>
                [JsonPropertyName("front_shiny")]
                public string FrontShiny { get; set; }

                // <summary>
                /// The default depiction of this Pokémon from the front female shiny in battle.
                /// </summary>
                [JsonPropertyName("front_shiny_female")]
                public string FrontShinyFemale { get; set; }
            }

        }

        /// <summary>
        /// Pókemon sprites for Generation VII
        /// </summary>
        public class GenerationVIISpritesResponse
        {
            /// <summary>
            /// Pókemon Icons sprites
            /// </summary>
            public IconsSpritesResponse Icons { get; set; }

            /// <summary>
            /// Pókemon UltraSun/UltraMoon sprites
            /// </summary>
            [JsonPropertyName("ultra-sun-ultra-moon")]
            public UltraSunUltraMoonSpritesResponse UltraSunUltraMoon { get; set; }

            /// <summary>
            /// Pókemon Icons sprites
            /// </summary>
            public class IconsSpritesResponse
            {
                /// <summary>
                /// The default depiction of this Pokémon from the front in battle.
                /// </summary>
                [JsonPropertyName("front_default")]
                public string FrontDefault { get; set; }

                /// <summary>
                /// The default depiction of this Pokémon from the front female in battle.
                /// </summary>
                [JsonPropertyName("front_female")]
                public string FrontFemale { get; set; }
            }

            /// <summary>
            /// Pókemon UltraSun/UltraMoon sprites
            /// </summary>
            public class UltraSunUltraMoonSpritesResponse
            {
                /// <summary>
                /// The default depiction of this Pokémon from the front in battle.
                /// </summary>
                [JsonPropertyName("front_default")]
                public string FrontDefault { get; set; }

                /// <summary>
                /// The default depiction of this Pokémon from the front female in battle.
                /// </summary>
                [JsonPropertyName("front_female")]
                public string FrontFemale { get; set; }

                /// <summary>
                /// The default depiction of this Pokémon from the front shiny in battle.
                /// </summary>
                [JsonPropertyName("front_shiny")]
                public string FrontShiny { get; set; }

                // <summary>
                /// The default depiction of this Pokémon from the front female shiny in battle.
                /// </summary>
                [JsonPropertyName("front_shiny_female")]
                public string FrontShinyFemale { get; set; }
            }
        }

        /// <summary>
        /// Pókemon sprites for Generation VIII
        /// </summary>
        public class GenerationVIIISpritesResponse
        {
            /// <summary>
            /// Pókemon Icons sprites
            /// </summary>
            public IconsSpritesResponse Icons { get; set; }

            /// <summary>
            /// Pókemon Icons sprites
            /// </summary>
            public class IconsSpritesResponse
            {
                /// <summary>
                /// The default depiction of this Pokémon from the front in battle.
                /// </summary>
                [JsonPropertyName("front_default")]
                public string FrontDefault { get; set; }

                /// <summary>
                /// The default depiction of this Pokémon from the front female in battle.
                /// </summary>
                [JsonPropertyName("front_female")]
                public string FrontFemale { get; set; }
            }
        }
    }
}

/// <summary>
/// Colors used for sorting Pokémon in a Pokédex. The color listed in the
/// Pokédex is usually the color most apparent or covering each Pokémon's
/// body. No orange category exists; Pokémon that are primarily orange are
/// listed as red or brown.
/// </summary>
public class PokemonColorResponse : PokeApiNamedApiResource
{
    /// <summary>
    /// The identifier for this resource.
    /// </summary>
    public override int Id { get; set; }

    internal new static string ApiEndpoint { get; } = "pokemon-color";

    /// <summary>
    /// The name for this resource.
    /// </summary>
    public override string Name { get; set; }

    /// <summary>
    /// The name of this resource listed in different languages.
    /// </summary>
    public List<NamesResponse> Names { get; set; }

    /// <summary>
    /// A list of the Pokémon species that have this color.
    /// </summary>
    [JsonPropertyName("pokemon_species")]
    public List<PokeApiNamedApiResource<PokemonSpeciesResponse>> PokemonSpecies { get; set; }
}

/// <summary>
/// Some Pokémon may appear in one of multiple, visually different
/// forms. These differences are purely cosmetic. For variations
/// within a Pokémon species, which do differ in more than just visuals,
/// the 'Pokémon' entity is used to represent such a variety.
/// </summary>
public class PokemonFormResponse : PokeApiNamedApiResource
{
    /// <summary>
    /// The identifier for this resource.
    /// </summary>
    public override int Id { get; set; }

    internal new static string ApiEndpoint { get; } = "pokemon-form";

    /// <summary>
    /// The name for this resource.
    /// </summary>
    public override string Name { get; set; }

    /// <summary>
    /// The order in which forms should be sorted within all forms.
    /// Multiple forms may have equal order, in which case they should
    /// fall back on sorting by name.
    /// </summary>
    public int Order { get; set; }

    /// <summary>
    /// The order in which forms should be sorted within a species' forms.
    /// </summary>
    [JsonPropertyName("form_order")]
    public int FormOrder { get; set; }

    /// <summary>
    /// True for exactly one form used as the default for each Pokémon.
    /// </summary>
    [JsonPropertyName("is_default")]
    public bool IsDefault { get; set; }

    /// <summary>
    /// Whether or not this form can only happen during battle.
    /// </summary>
    [JsonPropertyName("is_battle_only")]
    public bool IsBattleOnly { get; set; }

    /// <summary>
    /// Whether or not this form requires mega evolution.
    /// </summary>
    [JsonPropertyName("is_mega")]
    public bool IsMega { get; set; }

    /// <summary>
    /// The name of this form.
    /// </summary>
    [JsonPropertyName("form_name")]
    public string FormName { get; set; }

    /// <summary>
    /// The Pokémon that can take on this form.
    /// </summary>
    public PokeApiNamedApiResource<PokemonResponse> Pokemon { get; set; }

    /// <summary>
    /// A set of sprites used to depict this Pokémon form in the game.
    /// </summary>
    public PokemonFormSpritesResponse SpritesResponse { get; set; }

    /// <summary>
    /// List of types belonging to this Pokémon form.
    /// </summary>
    public List<PokemonTypeResponse> Types { get; set; }

    /// <summary>
    /// The form specific full name of this Pokémon form, or empty if
    /// the form does not have a specific name.
    /// </summary>
    public List<NamesResponse> Names { get; set; }

    /// <summary>
    /// The form specific form name of this Pokémon form, or empty if the
    /// form does not have a specific name.
    /// </summary>
    [JsonPropertyName("form_names")]
    public List<NamesResponse> FormNames { get; set; }
}

/// <summary>
/// Pokémon sprite information with relation to a form
/// </summary>
public class PokemonFormSpritesResponse
{
    /// <summary>
    /// The default depiction of this Pokémon form from the front in battle.
    /// </summary>
    [JsonPropertyName("front_default")]
    public string FrontDefault { get; set; }

    /// <summary>
    /// The shiny depiction of this Pokémon form from the front in battle.
    /// </summary>
    [JsonPropertyName("front_shiny")]
    public string FrontShiny { get; set; }

    /// <summary>
    /// The default depiction of this Pokémon form from the back in battle.
    /// </summary>
    [JsonPropertyName("back_default")]
    public string BackDefault { get; set; }

    /// <summary>
    /// The shiny depiction of this Pokémon form from the back in battle.
    /// </summary>
    [JsonPropertyName("back_shiny")]
    public string BackShiny { get; set; }
}

/// <summary>
/// A Pokémon Species forms the basis for at least one Pokémon. Attributes
/// of a Pokémon species are shared across all varieties of Pokémon within
/// the species. A good example is Wormadam; Wormadam is the species which
/// can be found in three different varieties, Wormadam-Trash,
/// Wormadam-Sandy and Wormadam-Plant.
/// </summary>
public class PokemonSpeciesResponse : PokeApiNamedApiResource
{
    /// <summary>
    /// The identifier for this resource.
    /// </summary>
    public override int Id { get; set; }

    internal new static string ApiEndpoint { get; } = "pokemon-species";

    /// <summary>
    /// The name for this resource.
    /// </summary>
    public override string Name { get; set; }

    /// <summary>
    /// The order in which species should be sorted. Based on National Dex
    /// order, except families are grouped together and sorted by stage.
    /// </summary>
    public int Order { get; set; }

    /// <summary>
    /// The chance of this Pokémon being female, in eighths; or -1 for
    /// genderless.
    /// </summary>
    [JsonPropertyName("gender_rate")]
    public int GenderRate { get; set; }

    /// <summary>
    /// The base capture rate; up to 255. The higher the number, the easier
    /// the catch.
    /// </summary>
    [JsonPropertyName("capture_rate")]
    public int? CaptureRate { get; set; }

    /// <summary>
    /// The happiness when caught by a normal Pokéball; up to 255. The higher
    /// the number, the happier the Pokémon.
    /// </summary>
    [JsonPropertyName("base_happiness")]
    public int? BaseHappiness { get; set; }

    /// <summary>
    /// Whether or not this is a baby Pokémon.
    /// </summary>
    [JsonPropertyName("is_baby")]
    public bool IsBaby { get; set; }

    /// <summary>
    /// Whether or not this is a legendary Pokémon.
    /// </summary>
    [JsonPropertyName("is_legendary")]
    public bool IsLegendary { get; set; }

    /// <summary>
    /// Whether or not this is a mythical Pokémon.
    /// </summary>
    [JsonPropertyName("is_mythical")]
    public bool IsMythical { get; set; }

    /// <summary>
    /// Initial hatch counter: one must walk 255 × (hatch_counter + 1) steps
    /// before this Pokémon's egg hatches, unless utilizing bonuses like
    /// Flame Body's.
    /// </summary>
    [JsonPropertyName("hatch_counter")]
    public int? HatchCounter { get; set; }

    /// <summary>
    /// Whether or not this Pokémon has visual gender differences.
    /// </summary>
    [JsonPropertyName("has_gender_differences")]
    public bool HasGenderDifferences { get; set; }

    /// <summary>
    /// Whether or not this Pokémon has multiple forms and can switch between
    /// them.
    /// </summary>
    [JsonPropertyName("forms_switchable")]
    public bool FormsSwitchable { get; set; }

    /// <summary>
    /// The rate at which this Pokémon species gains levels.
    /// </summary>
    [JsonPropertyName("growth_rate")]
    public PokeApiNamedApiResource<GrowthRateResponse> GrowthRate { get; set; }
    
    /// <summary>
    /// The color of this Pokémon for Pokédex search.
    /// </summary>
    public PokeApiNamedApiResource<PokemonColorResponse> Color { get; set; }
    
    /// <summary>
    /// The Pokémon species that evolves into this Pokemon_species.
    /// </summary>
    [JsonPropertyName("evolves_from_species")]
    public PokeApiNamedApiResource<PokemonSpeciesResponse> EvolvesFromSpecies { get; set; }
    
    /// <summary>
    /// The name of this resource listed in different languages.
    /// </summary>
    public List<NamesResponse> Names { get; set; }

    /// <summary>
    /// A list of flavor text entries for this Pokémon species.
    /// </summary>
    [JsonPropertyName("flavor_text_entries")]
    public List<PokemonSpeciesFlavorTextsResponse> FlavorTextEntries { get; set; }

    /// <summary>
    /// Descriptions of different forms Pokémon take on within the Pokémon
    /// species.
    /// </summary>
    [JsonPropertyName("form_descriptions")]
    public List<DescriptionsResponse> FormDescriptions { get; set; }

    /// <summary>
    /// The genus of this Pokémon species listed in multiple languages.
    /// </summary>
    public List<GenusesResponse> Genera { get; set; }

    /// <summary>
    /// A list of the Pokémon that exist within this Pokémon species.
    /// </summary>
    public List<PokemonSpeciesVarietyResponse> Varieties { get; set; }
}

/// <summary>
/// The flavor text for a Pokémon species
/// </summary>
public class PokemonSpeciesFlavorTextsResponse
{
    /// <summary>
    /// The localized flavor text for an api resource in a specific language
    /// </summary>
    [JsonPropertyName("flavor_text")]
    public string FlavorText { get; set; }

    /// <summary>
    /// The language this flavor text is in.
    /// </summary>
    public PokeApiNamedApiResource<PokeApiLanguage> Language { get; set; }
}

/// <summary>
/// The genus information for a Pokémon and the associated language
/// </summary>
public class GenusesResponse
{
    /// <summary>
    /// The localized genus for the referenced Pokémon species
    /// </summary>
    public string Genus { get; set; }

    /// <summary>
    /// The language this genus is in.
    /// </summary>
    public PokeApiNamedApiResource<PokeApiLanguage> Language { get; set; }
}

/// <summary>
/// A variety of a Pokémon species
/// </summary>
public class PokemonSpeciesVarietyResponse
{
    /// <summary>
    /// Whether this variety is the default variety.
    /// </summary>
    [JsonPropertyName("is_default")]
    public bool IsDefault { get; set; }

    /// <summary>
    /// The Pokémon variety.
    /// </summary>
    public PokeApiNamedApiResource<PokemonResponse> Pokemon { get; set; }
}

/// <summary>
/// Stats determine certain aspects of battles. Each Pokémon has a value
/// for each stat which grows as they gain levels and can be altered
/// momentarily by effects in battles.
/// </summary>
public class StatResponse : PokeApiNamedApiResource
{
    /// <summary>
    /// The identifier for this resource.
    /// </summary>
    public override int Id { get; set; }

    internal new static string ApiEndpoint { get; } = "stat";

    /// <summary>
    /// The name for this resource.
    /// </summary>
    public override string Name { get; set; }

    /// <summary>
    /// ID the games use for this stat.
    /// </summary>
    [JsonPropertyName("game_index")]
    public int GameIndex { get; set; }

    /// <summary>
    /// Whether this stat only exists within a battle.
    /// </summary>
    [JsonPropertyName("is_battle_only")]
    public bool IsBattleOnly { get; set; }

    /// <summary>
    /// A detail of moves which affect this stat positively or negatively.
    /// </summary>
    [JsonPropertyName("affecting_moves")]
    public MoveStatAffectSetsResponse AffectingMoves { get; set; }

    /// <summary>
    /// A detail of natures which affect this stat positively or negatively.
    /// </summary>
    [JsonPropertyName("affecting_natures")]
    public NatureStatAffectSetsResponse AffectingNatures { get; set; }

    /// <summary>
    /// A list of characteristics that are set on a Pokémon when its highest
    /// base stat is this stat.
    /// </summary>
    public List<PokeApiApiResource<CharacteristicResponse>> Characteristics { get; set; }

    /// <summary>
    /// The public class of damage this stat is directly related to.
    /// </summary>
    [JsonPropertyName("move_damage_class")]
    public PokeApiNamedApiResource<MoveDamageClassResponse> MoveDamageClass { get; set; }

    /// <summary>
    /// The name of this resource listed in different languages.
    /// </summary>
    public List<NamesResponse> Names { get; set; }
}

/// <summary>
/// A list of moves and how they change statuses
/// </summary>
public class MoveStatAffectSetsResponse
{
    /// <summary>
    /// A list of moves and how they change the referenced stat.
    /// </summary>
    public List<MoveStatAffectResponse> Increase { get; set; }

    /// <summary>
    /// A list of moves and how they change the referenced stat.
    /// </summary>
    public List<MoveStatAffectResponse> Decrease { get; set; }
}

/// <summary>
/// A reference to a move and the change to a status
/// </summary>
public class MoveStatAffectResponse
{
    /// <summary>
    /// The maximum amount of change to the referenced stat.
    /// </summary>
    public int Change { get; set; }

    /// <summary>
    /// The move causing the change.
    /// </summary>
    public PokeApiNamedApiResource<MoveResponse> Move { get; set; }
}

/// <summary>
/// A reference to a nature and the change to a status
/// </summary>
public class NatureStatAffectSetsResponse
{
    /// <summary>
    /// A list of natures and how they change the referenced stat.
    /// </summary>
    public List<PokeApiNamedApiResource<NatureResponse>> Increase { get; set; }

    /// <summary>
    /// A list of natures and how they change the referenced stat.
    /// </summary>
    public List<PokeApiNamedApiResource<NatureResponse>> Decrease { get; set; }
}

/// <summary>
/// Types are properties for Pokémon and their moves. Each type has three
/// properties: which types of Pokémon it is super effective against,
/// which types of Pokémon it is not very effective against, and which types
/// of Pokémon it is completely ineffective against.
/// </summary>
public class TypeResponse : PokeApiNamedApiResource
{
    /// <summary>
    /// The identifier for this resource.
    /// </summary>
    public override int Id { get; set; }

    internal new static string ApiEndpoint { get; } = "type";

    /// <summary>
    /// The name for this resource.
    /// </summary>
    public override string Name { get; set; }

    /// <summary>
    /// A detail of how effective this type is toward others and vice versa.
    /// </summary>
    [JsonPropertyName("damage_relations")]
    public TypeRelationsResponse DamageRelationsResponse { get; set; }

    /// <summary>
    /// The public class of damage inflicted by this type.
    /// </summary>
    [JsonPropertyName("move_damage_class")]
    public PokeApiNamedApiResource<MoveDamageClassResponse> MoveDamageClass { get; set; }

    /// <summary>
    /// The name of this resource listed in different languages.
    /// </summary>
    public List<NamesResponse> Names { get; set; }

    /// <summary>
    /// A list of details of Pokémon that have this type.
    /// </summary>
    public List<TypePokemonResponse> Pokemon { get; set; }

    /// <summary>
    /// A list of moves that have this type.
    /// </summary>
    public List<PokeApiNamedApiResource<MoveResponse>> Moves { get; set; }
}

/// <summary>
/// A Pokémon type information
/// </summary>
public class TypePokemonResponse
{
    /// <summary>
    /// The order the Pokémon's types are listed in.
    /// </summary>
    public int Slot { get; set; }

    /// <summary>
    /// The Pokémon that has the referenced type.
    /// </summary>
    public PokeApiNamedApiResource<PokemonResponse> Pokemon { get; set; }
}

/// <summary>
/// The information for how a type interacts with other types
/// </summary>
public class TypeRelationsResponse
{
    /// <summary>
    /// A list of types this type has no effect on.
    /// </summary>
    [JsonPropertyName("no_damage_to")]
    public List<PokeApiNamedApiResource<TypeResponse>> NoDamageTo { get; set; }

    /// <summary>
    /// A list of types this type is not very effect against.
    /// </summary>
    [JsonPropertyName("half_damage_to")]
    public List<PokeApiNamedApiResource<TypeResponse>> HalfDamageTo { get; set; }

    /// <summary>
    /// A list of types this type is very effect against.
    /// </summary>
    [JsonPropertyName("double_damage_to")]
    public List<PokeApiNamedApiResource<TypeResponse>> DoubleDamageTo { get; set; }

    /// <summary>
    /// A list of types that have no effect on this type.
    /// </summary>
    [JsonPropertyName("no_damage_from")]
    public List<PokeApiNamedApiResource<TypeResponse>> NoDamageFrom { get; set; }

    /// <summary>
    /// A list of types that are not very effective against this type.
    /// </summary>
    [JsonPropertyName("half_damage_from")]
    public List<PokeApiNamedApiResource<TypeResponse>> HalfDamageFrom { get; set; }

    /// <summary>
    /// A list of types that are very effective against this type.
    /// </summary>
    [JsonPropertyName("double_damage_from")]
    public List<PokeApiNamedApiResource<TypeResponse>> DoubleDamageFrom { get; set; }
}