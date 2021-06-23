using System;
using PSV2.Model;
using static PSV2.Core.IRepository;

namespace PSV2.Core
{
    public interface IVisitRepository : IRepository<Visit>
    {
        public Visit GetVisitById(int id);
    }
}
