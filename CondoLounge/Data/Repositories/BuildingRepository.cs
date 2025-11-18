
using CondoLounge.Data.Entities;
using CondoLounge.Data.Interfaces;
using CondoLounge.Data.Repositories;
namespace CondoLounge.Data.Repositories
{
    public class BuildingRepository : CondoLoungeGenericGenericRepository<Building>, ICondoLoungeGenericRepository<Building>
    {
        public BuildingRepository(ApplicationDbContext db) : base(db)
        {
        }

        public IEnumerable<ApplicationUser> GetAllUsersForBuilding(int buildingId)
        {
            return _dbSet
                .Where(b => b.Id == buildingId)
                .SelectMany(b => b.Condos)
                .Where(c => c.User != null)
                .Select(c => c.User)
                .Distinct() // user can appear in multiple buildings so important to only select few.
                .ToList();
        }

    }
}
