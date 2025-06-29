using Chronobox.API.Contracts;
using Chronobox.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Chronobox.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContainerController : ControllerBase
    {
        private readonly IContainersServices _containersServices;

        public ContainerController(IContainersServices containersServices)
        {
            _containersServices = containersServices;
        }

        [HttpGet]
        public async Task<ActionResult<List<ContainersResponse>>> GetAllContainers()
        {
            var containers = await _containersServices.GetAllContainer();

            var response = containers.Select(c => new ContainersResponse(c.Id, c.Name, c.DateOfCreation));

            return Ok(response);
        }
    }
}
