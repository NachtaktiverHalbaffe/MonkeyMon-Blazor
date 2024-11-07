namespace MonkeyMon_Blazor.Models
{
    /// <summary>
    /// Allows for automatic fetching of a resource via a url
    /// </summary>
    public abstract class PokeApiUrlNavigation<T> where T : PokeApiResourceBase
    {
        /// <summary>
        /// Url of the referenced resource
        /// </summary>
        public string Url { get; set; }
    }
}
