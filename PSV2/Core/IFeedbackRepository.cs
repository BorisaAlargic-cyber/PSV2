using System;
using PSV2.Model;
using static PSV2.Core.IRepository;

namespace PSV2.Core
{
    public interface IFeedbackRepository : IRepository<Feedback>
    {
        public PageResponse<Feedback> GetPagePublished(Pager pager);
    }
}
