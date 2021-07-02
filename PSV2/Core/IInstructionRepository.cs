using System;
using System.Collections.Generic;
using PSV2.Model;
using static PSV2.Core.IRepository;

namespace PSV2.Core
{
    public interface IInstructionRepository : IRepository<Instruction>
    {
        public List<Instruction> GetAllInstructionsForUser(User user);
    }
}
