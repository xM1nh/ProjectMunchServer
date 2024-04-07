using System.Text.Json.Serialization;

namespace ProjectMunch.Bff.Dto
{
    public class MapBoxGeocodingResponseDto
    {
        [JsonPropertyName("type")]
        public string Type { get; set; } = null!;

        [JsonPropertyName("query")]
        public float[] Query { get; set; } = null!;

        [JsonPropertyName("features")]
        public IList<MapBoxGeocodingResponseFeature> Features { get; set; } = null!;

        [JsonPropertyName("attribution")]
        public string Attribution { get; set; } = null!;
    }

    public class MapBoxGeocodingResponseFeature
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = null!;

        [JsonPropertyName("type")]
        public string Type { get; set; } = null!;

        [JsonPropertyName("place_type")]
        public IList<string> PlaceType { get; set; } = null!;

        [JsonPropertyName("relevance")]
        public float? Relevance { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; } = null!;

        [JsonPropertyName("properties")]
        public MapBoxGeocodingResponseFeatureProperty Properties { get; set; } = null!;

        [JsonPropertyName("place_name")]
        public string PlaceName { get; set; } = null!;

        [JsonPropertyName("matching_text")]
        public string? MatchingText { get; set; }

        [JsonPropertyName("matching_place_name")]
        public string? MatchingPlaceName { get; set; }

        [JsonPropertyName("language")]
        public string? Language { get; set; }

        [JsonPropertyName("bbox")]
        public float[] BoundingBox { get; set; } = null!;

        [JsonPropertyName("center")]
        public float[] Center { get; set; } = null!;

        [JsonPropertyName("geometry")]
        public MapBoxGeocodingResponseFeatureGeometry Geometry { get; set; } = null!;

        [JsonPropertyName("context")]
        public IList<MapBoxGeocodingResponseFeatureContext> Context { get; set; } = null!;
    }

    public class MapBoxGeocodingResponseFeatureProperty
    {
        [JsonPropertyName("accuracy")]
        public string? Accuracy { get; set; }

        [JsonPropertyName("address")]
        public string? Address { get; set; }

        [JsonPropertyName("category")]
        public string? Category { get; set; }

        [JsonPropertyName("maki")]
        public string? Maki { get; set; }

        [JsonPropertyName("wikidata")]
        public string? Wikidata { get; set; }

        [JsonPropertyName("short_code")]
        public string? ShortCode { get; set; }
    }

    public class MapBoxGeocodingResponseFeatureGeometry
    {
        [JsonPropertyName("type")]
        public string Type { get; set; } = null!;

        [JsonPropertyName("coordinates")]
        public float[] Coordinate { get; set; } = null!;

        [JsonPropertyName("interpolated")]
        public bool? Interpolated { get; set; }

        [JsonPropertyName("omitted")]
        public bool? Omitted { get; set; }
    }

    public class MapBoxGeocodingResponseFeatureContext
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = null!;

        [JsonPropertyName("wikidata")]
        public string Wikidata { get; set; } = null!;

        [JsonPropertyName("short_code")]
        public string ShortCode { get; set; } = null!;
    }
}
