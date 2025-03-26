
public record ReviewDto
{
    public int Id { get; init; }
    public int BeerId { get; init; }
    public string Reviewer { get; init; } = string.Empty;
    public string Comment { get; init; } = string.Empty;
    public int BitternesScore { get; init; }
    public int FruitinessScore { get; init; }
    public int SweetnessScore { get; init; }    
    public int Rating { get; init; }
    public BeerDto Beer { get; init; } = null!;
}