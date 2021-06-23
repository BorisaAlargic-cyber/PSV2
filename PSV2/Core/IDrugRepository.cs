using System;
using PSV2.Model;
using static PSV2.Core.IRepository;

namespace PSV2.Core
{
    public interface IDrugRepository : IRepository<Drugs>
    {
        public Drugs GetDrugById(int id);
    }
}
