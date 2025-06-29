using Chronobox.Core.Models;
using Chronobox.DataAccess.Repositories;


namespace Chronobox.Application.Services
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
            return await _containersRepository.GetAllContainers();
        }
    }
}
