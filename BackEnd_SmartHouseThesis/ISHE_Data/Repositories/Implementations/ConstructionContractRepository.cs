using ISHE_Data.Entities;
using ISHE_Data.Repositories.Interfaces;

namespace ISHE_Data.Repositories.Implementations
{
    public class ConstructionContractRepository : Repository<ConstructionContract>, IConstructionContractRepository
    {
        public ConstructionContractRepository(SMART_HOME_DBContext context) : base(context)
        {
        }
    }
}
