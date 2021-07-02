using System;
using System.Collections.Generic;
using PSV2.Model;
using static PSV2.Core.IRepository;

namespace PSV2.Core
{
    public interface IUserRepository : IRepository<User>
    {

        public User GetUserWithEmail(string email);

        public User GetUserWithEmailAndPassword(string email, string password);

        public List<User> GetDoctors();

        public List<User> GetDoctorForSpeciality(Instruction instruction);
    }
}
