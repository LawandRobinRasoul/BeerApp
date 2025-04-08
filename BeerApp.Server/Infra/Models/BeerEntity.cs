using System.ComponentModel.DataAnnotations;

public record BeerEntity
{
    [Key]        
    public int Id { get; init; }

    [Required]
    public required string Name { get; init; }

    [Required]
    public string Type { get; init; } = string.Empty;

    [Required]
    public string Description { get; init; } = string.Empty;

    public  string? imageUrl { get; init; }

    [Required]
    public  DateTimeOffset CreatedAt { get; init; }

    public List<ReviewEntity> Reviews { get; set; } = new();
}