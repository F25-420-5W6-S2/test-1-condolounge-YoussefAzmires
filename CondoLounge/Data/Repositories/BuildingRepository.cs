
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

        public IEnumerable<ApplicationUser> GetAllUsersForBuilding(int building)
        {
            throw new NotImplementedException();
        }
    }
}
