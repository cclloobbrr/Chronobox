using Chronobox.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Chronobox.DataAccess.Repositories
{
    public class ContainersRepository : IContainersRepository
    {
        private readonly ChronoboxDbContext _dbContext;

        public ContainersRepository(ChronoboxDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Container>> GetAllContainers()
        {
            var containerEntities = await _dbContext.Containers
                .AsNoTracking()
                .ToListAsync();

            var containers = containerEntities
                .Select(c => Container.Create(c.Id, c.Name, c.DateOfCreation).Container)
                .ToList();

            return containers;
        }


    }
}
