using System.Text.Json.Serialization;

namespace BeerApp.Server.Controllers.ApiModels
{
    public record BeerApiModel
    {
        [JsonPropertyName("id")]
        public int Id { get; init; }

        [JsonPropertyName("name")]
        public string Name { get; init; }

        [JsonPropertyName("rating")]
        public string Rating { get; init; }

        [JsonPropertyName("description")]
        public string Description { get; init; }

        [JsonPropertyName("image")]
        public string ImageUrl { get; init; }
    }
}
