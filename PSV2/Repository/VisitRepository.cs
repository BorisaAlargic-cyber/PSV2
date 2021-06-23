using System;
using System.Data.Entity;
using System.Linq;
using PSV2.Core;
using PSV2.Model;

namespace PSV2.Repository
{
    public class VisitRepository : Repository<Visit>, IVisitRepository
    {
        public VisitRepository(ModelContext context) : base(context) { }

        public Visit GetVisitById(int id)
        {
            return ModelContext.Visits.Where(x => x.Id == id).FirstOrDefault();
        }

        public override PageResponse<Visit> GetPage(Pager pager)
        {
            var query = ModelContext.Visits.Include("Apointment")
                .Include("Apointment.Patient")
                .Include("Apointment.Termin").Where(x => (x.Deleted == false)).OrderBy(x => x.Id);

            return new PageResponse<Visit>(query.Skip(pager.Page).Take(pager.PerPage).ToList(), query.Count());
        }
    }
}
