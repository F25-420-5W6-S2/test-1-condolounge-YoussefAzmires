using CondoLounge.Data.Interfaces;
using CondoLounge.Data;
using Microsoft.EntityFrameworkCore;

namespace CondoLounge.Data.Repositories
{
    public class CondoLoungeGenericGenericRepository<T> : ICondoLoungeGenericRepository<T> where T : class
    {
        internal readonly ILogger<CondoLoungeGenericGenericRepository<T>> _logger;
        internal readonly ApplicationDbContext _context;
        internal readonly DbSet<T> _dbSet;
        private ApplicationDbContext db;

      

        public CondoLoungeGenericGenericRepository(ApplicationDbContext db) 
        {
            _context = db;
            _dbSet = _context.Set<T>();
        }
        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                _logger.LogInformation("GetAll was called...");

                return _dbSet.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get: {ex}");
                return null;
            }
        }

        public T GetById(object id)
        {
            throw new NotImplementedException();
        }

        public void SaveAll()
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
