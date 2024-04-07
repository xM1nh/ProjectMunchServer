using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace ProjectMunch.Bff.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ApiController : ControllerBase { }
}
