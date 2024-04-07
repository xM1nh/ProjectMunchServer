using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProjectMunch.Domain;
using ProjectMunch.DTO.PointOfInterestsApi;
using ProjectMunch.Models;

namespace ProjectMunch.Api.Controllers
{
    public class PointOfInterestsController : ApiController
    {
        private readonly IPointOfInterestService _service;

        public PointOfInterestsController(IPointOfInterestService service)
        {
            ArgumentNullException.ThrowIfNull(service, nameof(service));
            _service = service;
        }

        [HttpGet("public")]
        public async Task<Results<Ok<List<PointOfInterest>>, NoContent>> GetByDistanceFromCenter(
            [FromQuery] GetPublicPoiRequestDto request
        )
        {
            var results = await _service.GetByDistanceFromCenter(
                request.Longitude,
                request.Latitude,
                request.Distance
            );

            if (results.Count == 0)
            {
                return TypedResults.NoContent();
            }

            return TypedResults.Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<Results<Ok<PointOfInterest>, NotFound>> GetById(int id)
        {
            var result = await _service.GetById(id);

            if (result is null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Verified")]
        public async Task<Results<Created, Conflict>> Add(AddRequestDto request)
        {
            var affected = await _service.Add(
                request.Longitude,
                request.Latitude,
                request.Name,
                request.Description
            );

            if (!affected)
            {
                return TypedResults.Conflict();
            }

            return TypedResults.Created();
        }
    }
}
