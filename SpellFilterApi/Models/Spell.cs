using System.ComponentModel.DataAnnotations;

namespace SpellFilter.Models;

public class Spell
{
    [Required]
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; } = "";

    [Required]
    public int Level { get; set; }

    [Required]
    public string Description { get; set; } = "";

    [Required]
    public string Classes { get; set; } = "";

    public string? Tags { get; set; }
}