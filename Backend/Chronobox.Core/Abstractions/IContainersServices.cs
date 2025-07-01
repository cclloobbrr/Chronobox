using Chronobox.Core.Models;

namespace Chronobox.Application.Services
{
    public interface IContainersServices
    {
        Task<List<Container>> GetAllContainer();

        Task<Guid> AddContainer(Container container);

        Task<Guid> UpdateContainer(Guid id, string name, DateOnly dateOfCreation);

        Task<Guid> DeleteContainer(Guid id);
    }
}