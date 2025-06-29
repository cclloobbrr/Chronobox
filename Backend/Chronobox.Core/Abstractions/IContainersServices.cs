using Chronobox.Core.Models;

namespace Chronobox.Application.Services
{
    public interface IContainersServices
    {
        Task<List<Container>> GetAllContainer();
    }
}