using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PSV2.Core;
using PSV2.Model;

namespace PSV2.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ModelContext context) : base(context) { }

        public User GetUserWithEmail(string email)
        {
            return ModelContext.Users.Include(x => x.ChoosenDoctor).Where(x => x.Email == email).FirstOrDefault();
        }

        public User GetUserWithEmailAndPassword(string email, string password)
        {
            return ModelContext.Users.Include(x => x.ChoosenDoctor).Where(x => x.Email == email && x.Password == password).FirstOrDefault();
        }

        public override PageResponse<User> GetPage(Pager pager)
        {
            var query = ModelContext.Users.Where(x => (x.Deleted == false)).OrderBy(x => x.Id);

            return new PageResponse<User>(query.Skip(pager.Page).Take(pager.PerPage).ToList(), query.Count());
        }

        public List<User> GetDoctors()
        {
            var query = ModelContext.Users.
                Where(x => x.Deleted == false && x.Role == "DOCTOR").OrderBy(x => x.Id);

            return query.ToList();
        }
    }
}
