using Chronobox.Application.Services;
using Chronobox.Core.Models;
using Chronobox.DataAccess.Repositories;

namespace Chronobox.Application.Servicies
{
    public class ContainersServices : IContainersServices
    {
        private readonly IContainersRepository _containersRepository;
        public ContainersServices(IContainersRepository containersRepository)
        {
            _containersRepository = containersRepository;
        }

        public async Task<List<Container>> GetAllContainer()
        {
            return await _containersRepository.GetAll();
        }

        public async Task<Container> GetContainerById(Guid id)
        {
            return await _containersRepository.GetById(id);
        }

        public async Task<Guid> AddContainer(Container container)
        {
            return await _containersRepository.Add(container);
        }

        public async Task<Guid> UpdateContainer(Guid id, string name, DateOnly dateOfCreation)
        {
            return await _containersRepository.Update(id, name, dateOfCreation);
        }

        public async Task<Guid> DeleteContainer(Guid id)
        {
            return await _containersRepository.Delete(id);
        }
    }
}
