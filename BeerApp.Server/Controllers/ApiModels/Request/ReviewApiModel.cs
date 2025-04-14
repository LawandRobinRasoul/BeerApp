using Azure.Core.Serialization;
using System.Text.Json.Serialization;

namespace BeerApp.Server.Controllers.ApiModels.Request
{
    public record ReviewApiModel
    {
        [JsonPropertyName("beerId")]
        public int BeerId { get; set; }

        [JsonPropertyName("comment")]
        public required string Comment { get; set; }

        [JsonPropertyName("bitternessScore")]
        public int BitternessScore { get; set; }

        [JsonPropertyName("fruitinessScore")]
        public int FruitinessScore { get; set; }

        [JsonPropertyName("sweetnessScore")]
        public int SweetnessScore { get; set; }

        [JsonPropertyName("rating")]
        public int Rating { get; set; }

        [JsonPropertyName("username")]
        public string? username { get; set; }
    }
}
