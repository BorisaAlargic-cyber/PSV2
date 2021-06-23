using System;

using System.Linq;
using Microsoft.EntityFrameworkCore;
using PSV2.Core;
using PSV2.Model;

namespace PSV2.Repository
{
    public class ApointmentRepository : Repository<Apointment>, IApointmentRepository
    {
        public ApointmentRepository(ModelContext context) : base(context) { }

        public override PageResponse<Apointment> GetPage(Pager pager)
        {
            var query = ModelContext.Apointments.Include("Patient").Include("Doctor").Where(x => (x.Deleted == false)).OrderBy(x => x.Id);

            return new PageResponse<Apointment>(query.Skip(pager.Page).Take(pager.PerPage).ToList(), query.Count());
        }
    }
}
