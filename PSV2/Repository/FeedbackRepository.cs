using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PSV2.Core;
using PSV2.Model;

namespace PSV2.Repository
{
    public class FeedbackRepository : Repository<Feedback>, IFeedbackRepository
    {
        public FeedbackRepository(ModelContext context) : base(context) { }

        public override PageResponse<Feedback> GetPage(Pager pager)
        {
            var query = ModelContext.Feedbacks.Include("Patient").Where(x => (x.Deleted == false)).OrderBy(x => x.Id);

            return new PageResponse<Feedback>(query.Skip(pager.Page).Take(pager.PerPage).ToList(), query.Count());
        }

        public PageResponse<Feedback> GetPagePublished(Pager pager)
        {
            var query = ModelContext.Feedbacks.Where(x => (x.Deleted == false && (x.Published == true))).OrderBy(x => x.Id);

            return new PageResponse<Feedback>(query.Skip(pager.Page).Take(pager.PerPage).ToList(), query.Count());
        }
    }
}
