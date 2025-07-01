using Chronobox.API.Contracts;
using Chronobox.Application.Services;
using Chronobox.Core.Models;
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

        [HttpPost]
        public async Task<ActionResult<Guid>> AddContainer([FromBody] ContainersRequest request)
        {
            var container = Container.Create(
                Guid.NewGuid(),
                request.Name,
                request.DateOfCreation);

            var containerId = await _containersServices.AddContainer(container);

            return Ok(containerId);
        }
    }
}
