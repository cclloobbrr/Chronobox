using Chronobox.Core.Models;

namespace Chronobox.DataAccess.Repositories
{
    public interface IContainersRepository
    {
        Task<List<Container>> GetAllContainers();
    }
}