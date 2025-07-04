﻿using Chronobox.API.Contracts;
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
            var (container, error) = Container.Create(
                Guid.NewGuid(),
                request.Name,
                request.DateOfCreation);

            if(error != null)
            {
                return BadRequest(error);
            }

            var containerId = await _containersServices.AddContainer(container);

            return Ok(containerId);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateContainer(Guid id, [FromBody] ContainersRequest request)
        {
            if(await _containersServices.GetContainerById(id) == null)
            {
                return NotFound($"Container with ID {id} not found.");
            }
            if(string.IsNullOrEmpty(request.Name) || request.Name.Length > Container.MAX_NAME_LENGTH)
            {
                return BadRequest($"Name cannot be empty or exceed {Container.MAX_NAME_LENGTH} chars.");
            }

            var updContainerId = await _containersServices.UpdateContainer(id, request.Name, request.DateOfCreation);

            return Ok(updContainerId);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteContainer(Guid id)
        {
            if(await _containersServices.GetContainerById(id) == null)
            {
                return NotFound($"Container with ID {id} not found.");
            }

            var delContainerId = await _containersServices.DeleteContainer(id);

            return Ok(delContainerId);
        }
    }
}
