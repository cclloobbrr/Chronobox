using Chronobox.Core.Models;

namespace Chronobox.DataAccess.Repositories
{
    public interface IContainersRepository
    {
        Task<List<Container>> GetAll();

        Task<Container> GetById(Guid id);

        Task<Guid> Add(Container container);

        Task<Guid> Update(Guid id, string name, DateOnly dateOfCreation);

        Task<Guid> Delete(Guid id);
    }
}