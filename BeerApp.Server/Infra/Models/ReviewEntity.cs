
using System.ComponentModel.DataAnnotations;

public record ReviewEntity
{
    [Key]
    public int Id { get; init; }

    [Required]
    public int BeerId { get; init; }

    [Required]
    public string Reviewer { get; init; } = string.Empty;

    public string Comment { get; init; } = string.Empty;

    [Required]
    public int BitternesScore { get; init; }

    [Required]
    public int FruitinessScore { get; init; }

    [Required]
    public int SweetnessScore { get; init; }

    [Required]
    public int Rating { get; init; }

    public DateTimeOffset CreatedAt { get; init; }

    public DateTimeOffset UpdatedAt { get; init; }

    public BeerEntity Beer { get; init; } = null!;
}