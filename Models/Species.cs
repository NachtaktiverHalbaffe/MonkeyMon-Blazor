using System.ComponentModel.DataAnnotations;

namespace MonkeyMon_Blazor.Models;

public class Species
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Required]
    [StringLength(50)]
    public string Name { get; set; } = String.Empty;

    public ICollection<string> Locations { get; set; } = [];

    public IDictionary<string, string> Taxonomy { get; set; } = new Dictionary<string, string>();

    public IDictionary<string, string> Characteristics { get; set; } = new Dictionary<string, string>();
    
    // Navigation Properties
    public ICollection<Monkey> Monkeys { get; set; } = [];
}