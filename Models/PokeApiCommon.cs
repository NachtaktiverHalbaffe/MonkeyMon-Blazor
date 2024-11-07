using System.Text.Json.Serialization;

namespace MonkeyMon_Blazor.Models
{
       /// <summary>
    /// Languages for translations of API resource information.
    /// </summary>
    public class PokeApiLanguage : PokeApiNamedApiResource
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public override int Id { get; set; }

        internal new static string ApiEndpoint { get; } = "language";

        /// <summary>
        /// The name for this resource.
        /// </summary>
        public override string Name { get; set; }

        /// <summary>
        /// Whether or not the games are published in this language.
        /// </summary>
        public bool Official { get; set; }

        /// <summary>
        /// The two-letter code of the country where this language
        /// is spoken. Note that it is not unique.
        /// </summary>
        public string Iso639 { get; set; }

        /// <summary>
        /// The two-letter code of the language. Note that it is not
        /// unique.
        /// </summary>
        public string Iso3166 { get; set; }

        /// <summary>
        /// The name of this resource listed in different languages.
        /// </summary>
        public List<NamesResponse> Names { get; set; }

        /// <summary>
        /// Is endpoint case sensitive
        /// </summary>
        internal new static bool IsApiEndpointCaseSensitive { get; } = true;
    }

    /// <summary>
    /// A reference to an API object that does not have a `Name` property
    /// </summary>
    /// <typeparam name="T">The type of resource</typeparam>
    public class PokeApiApiResource<T> : PokeApiUrlNavigation<T> where T : PokeApiResourceBase { }

    /// <summary>
    /// The description for an API resource
    /// </summary>
    public class DescriptionsResponse
    {
        /// <summary>
        /// The localized description for an API resource in a
        /// specific language.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The language this name is in.
        /// </summary>
        public PokeApiNamedApiResource<PokeApiLanguage> Language { get; set; }
    }

    /// <summary>
    /// The effect of an API resource
    /// </summary>
    public class EffectsResponse
    {
        /// <summary>
        /// The localized effect text for an API resource in a
        /// specific language.
        /// </summary>
        public string Effect { get; set; }

        /// <summary>
        /// The language this effect is in.
        /// </summary>
        public PokeApiNamedApiResource<PokeApiLanguage> Language { get; set; }
    }
    
    
    /// <summary>
    /// A name with language information
    /// </summary>
    public class NamesResponse
    {
        /// <summary>
        /// The localized name for an API resource in a specific language.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The language this name is in.
        /// </summary>
        public PokeApiNamedApiResource<PokeApiLanguage> Language { get; set; }
    }

    /// <summary>
    /// A reference to an API resource that has a `Name` property
    /// </summary>
    /// <typeparam name="T">The type of reference</typeparam>
    public class PokeApiNamedApiResource<T> : PokeApiUrlNavigation<T> where T : PokeApiResourceBase
    {
        /// <summary>
        /// The name of the referenced resource.
        /// </summary>
        public string Name { get; set; }
    }
    
    /// <summary>
    /// The long text for effect text entries
    /// </summary>
    public class VerboseEffectResponse
    {
        /// <summary>
        /// The localized effect text for an API resource in a
        /// specific language.
        /// </summary>
        public string Effect { get; set; }

        /// <summary>
        /// The localized effect text in brief.
        /// </summary>
        [JsonPropertyName("short_effect")]
        public string ShortEffect { get; set; }

        /// <summary>
        /// The language this effect is in.
        /// </summary>
        public PokeApiNamedApiResource<PokeApiLanguage> Language { get; set; }
    }
}
