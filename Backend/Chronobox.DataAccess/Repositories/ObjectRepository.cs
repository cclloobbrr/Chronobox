namespace Chronobox.DataAccess.Repositories
{
    public class ObjectRepository
    {
        private readonly ChronoboxDbContext _dbContext;

        public ObjectRepository(ChronoboxDbContext dbContext)
        {
            _dbContext = dbContext;
        }


    }
}
