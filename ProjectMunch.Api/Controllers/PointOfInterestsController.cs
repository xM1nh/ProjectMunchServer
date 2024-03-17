using Microsoft.AspNetCore.Mvc;
using ProjectMunch.Domain;

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

        [HttpGet("/public")]
        public async Task<IActionResult> Get()
        {
            var pointOfInterests = await _service.GetAll();
            return Ok(pointOfInterests);
        }
    }
}
