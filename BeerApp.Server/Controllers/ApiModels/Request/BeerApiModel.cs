using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BeerApp.Server.Controllers.ApiModels.Request
{
    public record BeerApiModel
    {
        [JsonPropertyName("name")]
        public string Name { get; init; }

        [JsonPropertyName("description")]
        public string Description { get; init; }

        [JsonPropertyName("type")]
        public string Type { get; init; }

        [JsonPropertyName("image")]
        public string? ImageUrl { get; init; }
    }
}
