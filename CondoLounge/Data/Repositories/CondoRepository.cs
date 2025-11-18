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
            throw new NotImplementedException();
        }
    }
}
//using DutchTreat.Data.Entities;
//using DutchTreat.Data.Interfaces;

//namespace DutchTreat.Data.Repositories
//{
//    public class DutchOrderRepository : DutchGenericRepository<Order>, IDutchOrderRepository
//    {
//        public DutchOrderRepository(ApplicationDbContext db, ILogger<DutchOrderRepository> logger) : base(db, logger)
//        {
//        }

//        public IEnumerable<Order> GetByArtist(string artist)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
