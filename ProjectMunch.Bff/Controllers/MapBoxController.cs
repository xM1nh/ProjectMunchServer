using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProjectMunch.Bff.Dto;

namespace ProjectMunch.Bff.Controllers
{
    public class MapBoxController(ApiClient client) : ApiController
    {
        private readonly ApiClient _client = client;

        [HttpGet("reverse-geocoding")]
        public async Task<Results<Ok<MapBoxGeocodingResponseDto>, BadRequest>> GetReverseGeocoding(
            [FromQuery] float longitude,
            [FromQuery] float latitude
        )
        {
            var response = await _client.GetReverseGeocoding(longitude, latitude);

            if (response is null)
            {
                return TypedResults.BadRequest();
            }

            return TypedResults.Ok(response);
        }
    }
}
