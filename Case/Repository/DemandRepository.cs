using Case.DatabaseContext;
using Case.Entity;
using Case.Repository.Interface;

namespace Case.Repository
{
    public class DemandRepository : Repository<Demand> , IDemandRepository
    {
        public DemandRepository(Context context) : base(context)
        {
        }
    }
}
