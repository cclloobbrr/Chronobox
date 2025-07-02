using Chronobox.Core.Models;
using Chronobox.DataAccess.Entities;
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

        public async Task<List<Container>> GetAll()
        {
            var containerEntities = await _dbContext.Containers
                .AsNoTracking()
                .ToListAsync();

            var containers = containerEntities
                .Select(c => Container.Create(c.Id, c.Name, c.DateOfCreation).Container)
                .ToList();

            return containers;
        }

        public async Task<Guid> Add(Container container)
        {
            var containerEntity = new ContainerEntity
            {
                Id = container.Id,
                Name = container.Name,
                DateOfCreation = container.DateOfCreation
            };

            await _dbContext.Containers.AddAsync(containerEntity);
            await _dbContext.SaveChangesAsync();

            return containerEntity.Id;
        }

        public async Task<Guid> Update(Guid id, string name, DateOnly dateOfCreation)
        {
            await _dbContext.Containers
                .Where(c => c.Id == id)
                .ExecuteUpdateAsync(c => c
                .SetProperty(c => c.Name, c => name)
                .SetProperty(c => c.DateOfCreation, c => dateOfCreation)
                );

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _dbContext.Containers
                .Where(c => c.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
