using CondoLounge.Data.Entities;
using CondoLounge.Data.Interfaces;
using CondoLounge.Data.Repositories;
namespace CondoLounge.Data.Repositories
{
    public class CondoRepository : CondoLoungeGenericGenericRepository<Condo>, ICondoLoungeGenericRepository<Condo>
    {
        public CondoRepository(ApplicationDbContext db) : base(db)
        {
        }

        public IEnumerable<Condo> GetAllCondosByBuilding(int buildingId) 
        {
           return _dbSet.Where(c => c.BuildingId == buildingId).
                ToList();
        }
    }
}

