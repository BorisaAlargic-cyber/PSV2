using System;
using System.Collections.Generic;
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

        public List<Apointment> SearchApointmens(PriorityRequest priorityReq)
        {
            if (priorityReq.Priority == "DOCTOR")
            {
                return ModelContext.Apointments.Where(x => x.Doctor.Id == priorityReq.Doctor.Id && x.Date >= priorityReq.From.AddDays(-7) && x.Date <= priorityReq.To.AddDays(7) && x.Taken == false).Include(x => x.Doctor).ToList();
            }
            else
            {
                return ModelContext.Apointments.Where(x => x.Date > priorityReq.From && x.Date < priorityReq.To && x.Taken == false).Include(x => x.Doctor).ToList();
            }

        }
        public List<Apointment> FirstTimeApointments(User patient)
        {
            return ModelContext.Apointments.Where(x => x.Doctor.Id == patient.ChoosenDoctor.Id).Include(x => x.Doctor).ToList();
        }
    }
}
