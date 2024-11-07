
using System.Text.Json.Serialization;

namespace MonkeyMon_Blazor.Models
{
    /// <summary>
    /// Moves are the skills of Pokémon in battle. In battle, a Pokémon
    /// uses one move each turn. Some moves (including those learned by
    /// Hidden Machine) can be used outside of battle as well, usually
    /// for the purpose of removing obstacles or exploring new areas.
    /// </summary>
    public class MoveResponse : PokeApiNamedApiResource
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public override int Id { get; set; }

        internal new static string ApiEndpoint { get; } = "move";

        /// <summary>
        /// The name for this resource.
        /// </summary>
        public override string Name { get; set; }

        /// <summary>
        /// The percent value of how likely this move is to be successful.
        /// </summary>
        public int? Accuracy { get; set; }

        /// <summary>
        /// The percent value of how likely it is this moves effect will happen.
        /// </summary>
        [JsonPropertyName("effect_chance")]
        public int? EffectChance { get; set; }

        /// <summary>
        /// Power points. The number of times this move can be used.
        /// </summary>
        public int? Pp { get; set; }

        /// <summary>
        /// A value between -8 and 8. Sets the order in which moves are executed
        /// during battle. See
        /// [Bulbapedia](http://bulbapedia.bulbagarden.net/wiki/Priority)
        /// for greater detail.
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// The base power of this move with a value of 0 if it does not have
        /// a base power.
        /// </summary>
        public int? Power { get; set; }

        /// <summary>
        /// The type of damage the move inflicts on the target, e.g. physical.
        /// </summary>
        [JsonPropertyName("damage_class")]
        public PokeApiNamedApiResource<MoveDamageClassResponse> DamageClass { get; set; }

        /// <summary>
        /// The effect of this move listed in different languages.
        /// </summary>
        [JsonPropertyName("effect_entries")]
        public List<VerboseEffectResponse> EffectEntries { get; set; }

        /// <summary>
        /// The list of previous effects this move has had across version
        /// groups of the games.
        /// </summary>
        [JsonPropertyName("effect_changes")]
        public List<AbilityEffectChangeResponse> EffectChanges { get; set; }

        /// <summary>
        /// The flavor text of this move listed in different languages.
        /// </summary>
        [JsonPropertyName("flavor_text_entries")]
        public List<MoveFlavorTextResponse> FlavorTextEntries { get; set; }
        
        /// <summary>The pokemon that learn this move.</summary>
        [JsonPropertyName("learned_by_pokemon")]
        public List<PokeApiNamedApiResource> LearnedByPokemon { get; set; }

        /// <summary>
        /// Metadata about this move
        /// </summary>
        public MoveMetaDataResponse Meta { get; set; }

        /// <summary>
        /// The name of this resource listed in different languages.
        /// </summary>
        public List<NamesResponse> Names { get; set; }

        /// <summary>
        /// The type of target that will receive the effects of the attack.
        /// </summary>
        public PokeApiNamedApiResource<MoveTargetResponse> Target { get; set; }

        /// <summary>
        /// The elemental type of this move.
        /// </summary>
        public PokeApiNamedApiResource<TypeResponse> Type { get; set; }
    }
    

    /// <summary>
    /// The flavor text for a move
    /// </summary>
    public class MoveFlavorTextResponse
    {
        /// <summary>
        /// The localized flavor text for an api resource in a
        /// specific language.
        /// </summary>
        [JsonPropertyName("flavor_text")]
        public string FlavorText { get; set; }

        /// <summary>
        /// The language this name is in.
        /// </summary>
        public PokeApiNamedApiResource<PokeApiLanguage> Language { get; set; }
    }

    /// <summary>
    /// The additional data for a move
    /// </summary>
    public class MoveMetaDataResponse
    {
        /// <summary>
        /// The status ailment this move inflicts on its target.
        /// </summary>
        public PokeApiNamedApiResource<MoveAilmentResponse> Ailment { get; set; }

        /// <summary>
        /// The category of move this move falls under, e.g. damage or
        /// ailment.
        /// </summary>
        public PokeApiNamedApiResource<MoveCategoryResponse> Category { get; set; }

        /// <summary>
        /// The minimum number of times this move hits. Null if it always
        /// only hits once.
        /// </summary>
        [JsonPropertyName("min_hits")]
        public int? MinHits { get; set; }

        /// <summary>
        /// The maximum number of times this move hits. Null if it always
        /// only hits once.
        /// </summary>
        [JsonPropertyName("max_hits")]
        public int? MaxHits { get; set; }

        /// <summary>
        /// The minimum number of turns this move continues to take effect.
        /// Null if it always only lasts one turn.
        /// </summary>
        [JsonPropertyName("min_turns")]
        public int? MinTurns { get; set; }

        /// <summary>
        /// The maximum number of turns this move continues to take effect.
        /// Null if it always only lasts one turn.
        /// </summary>
        [JsonPropertyName("max_turns")]
        public int? MaxTurns { get; set; }

        /// <summary>
        /// HP drain (if positive) or Recoil damage (if negative), in percent
        /// of damage done.
        /// </summary>
        public int Drain { get; set; }

        /// <summary>
        /// The amount of hp gained by the attacking Pokemon, in percent of
        /// it's maximum HP.
        /// </summary>
        public int Healing { get; set; }

        /// <summary>
        /// Critical hit rate bonus.
        /// </summary>
        [JsonPropertyName("crit_rate")]
        public int CritRate { get; set; }

        /// <summary>
        /// The likelihood this attack will cause an ailment.
        /// </summary>
        [JsonPropertyName("ailment_chance")]
        public int AilmentChance { get; set; }

        /// <summary>
        /// The likelihood this attack will cause the target Pokémon to flinch.
        /// </summary>
        [JsonPropertyName("flinch_chance")]
        public int FlinchChance { get; set; }

        /// <summary>
        /// The likelihood this attack will cause a stat change in the target
        /// Pokémon.
        /// </summary>
        [JsonPropertyName("stat_chance")]
        public int StatChance { get; set; }
    }

    /// <summary>
    /// Move Ailments are status conditions caused by moves used during battle.
    /// </summary>
    public class MoveAilmentResponse : PokeApiNamedApiResource
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public override int Id { get; set; }

        internal new static string ApiEndpoint { get; } = "move-ailment";

        /// <summary>
        /// The name for this resource.
        /// </summary>
        public override string Name { get; set; }

        /// <summary>
        /// A list of moves that cause this ailment.
        /// </summary>
        public List<PokeApiNamedApiResource> Moves { get; set; }

        /// <summary>
        /// The name of this resource listed in different languages.
        /// </summary>
        public List<NamesResponse> Names { get; set; }
    }

    /// <summary>
    /// Styles of moves when used in the Battle Palace.
    /// </summary>
    public class MoveBattleStyleResponse : PokeApiNamedApiResource
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public override int Id { get; set; }

        internal new static string ApiEndpoint { get; } = "move-battle-style";

        /// <summary>
        /// The name for this resource.
        /// </summary>
        public override string Name { get; set; }

        /// <summary>
        /// The name of this resource listed in different languages.
        /// </summary>
        public List<NamesResponse> Names { get; set; }
    }

    /// <summary>
    /// Very general categories that loosely group move effects.
    /// </summary>
    public class MoveCategoryResponse : PokeApiNamedApiResource
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public override int Id { get; set; }

        internal new static string ApiEndpoint { get; } = "move-category";

        /// <summary>
        /// The name for this resource.
        /// </summary>
        public override string Name { get; set; }

        /// <summary>
        /// A list of moves that fall into this category.
        /// </summary>
        public List<PokeApiNamedApiResource> Moves { get; set; }

        /// <summary>
        /// The description of this resource listed in different languages.
        /// </summary>
        public List<DescriptionsResponse> Descriptions { get; set; }
    }

    /// <summary>
    /// Damage classes moves can have, e.g. physical, special, or non-damaging.
    /// </summary>
    public class MoveDamageClassResponse : PokeApiNamedApiResource
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public override int Id { get; set; }

        internal new static string ApiEndpoint { get; } = "move-damage-class";

        /// <summary>
        /// The name for this resource.
        /// </summary>
        public override string Name { get; set; }

        /// <summary>
        /// A list of moves that fall into this damage public class.
        /// </summary>
        public List<PokeApiNamedApiResource> Moves { get; set; }

        /// <summary>
        /// The description of this resource listed in different languages.
        /// </summary>
        public List<DescriptionsResponse> Descriptions { get; set; }

        /// <summary>
        /// The name of this resource listed in different languages.
        /// </summary>
        public List<NamesResponse> Names { get; set; }
    }

    /// <summary>
    /// Methods by which Pokémon can learn moves.
    /// </summary>
    public class MoveLearnMethodResponse : PokeApiNamedApiResource
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public override int Id { get; set; }

        internal new static string ApiEndpoint { get; } = "move-learn-method";

        /// <summary>
        /// The name for this resource.
        /// </summary>
        public override string Name { get; set; }

        /// <summary>
        /// The description of this resource listed in different languages.
        /// </summary>
        public List<DescriptionsResponse> Descriptions { get; set; }

        /// <summary>
        /// The name of this resource listed in different languages.
        /// </summary>
        public List<NamesResponse> Names { get; set; }

        /// <summary>
        /// A list of version groups where moves can be learned through this method.
        /// </summary>
        [JsonPropertyName("version_groups")]
        public List<PokeApiNamedApiResource> VersionGroups { get; set; }
    }

    /// <summary>
    /// Targets moves can be directed at during battle. Targets can be Pokémon,
    /// environments or even other moves.
    /// </summary>
    public class MoveTargetResponse : PokeApiNamedApiResource
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public override int Id { get; set; }

        internal new static string ApiEndpoint { get; } = "move-target";

        /// <summary>
        /// The name for this resource.
        /// </summary>
        public override string Name { get; set; }

        /// <summary>
        /// The description of this resource listed in different languages.
        /// </summary>
        public List<DescriptionsResponse> Descriptions { get; set; }

        /// <summary>
        /// A list of moves that that are directed at this target.
        /// </summary>
        public List<PokeApiNamedApiResource> Moves { get; set; }

        /// <summary>
        /// The name of this resource listed in different languages.
        /// </summary>
        public List<NamesResponse> Names { get; set; }
    }
}
