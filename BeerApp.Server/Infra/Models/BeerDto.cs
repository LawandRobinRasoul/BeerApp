using System.ComponentModel.DataAnnotations;

public record BeerDto
{
    [Key]        
    public int Id { get; init; }

    [Required]
    public required string Name { get; init; }

    [Required]
    public string Description { get; init; } = string.Empty;

    public  string? imageUrl { get; init; }

    [Required]
    public  DateTimeOffset CreatedAt { get; init; }

    public List<ReviewDto> Reviews { get; set; } = new();
}