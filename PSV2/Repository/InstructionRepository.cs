using System;
using System.Collections.Generic;
using System.Linq;
using PSV2.Core;
using PSV2.Model;

namespace PSV2.Repository
{
    public class InstructionRepository : Repository<Instruction>, IInstructionRepository
    {
        public InstructionRepository(ModelContext context) : base(context) { }

        public List<Instruction> GetAllInstructionsForUser(User user)
        {
            return ModelContext.Instructions.Where(x => x.Patient == user).ToList();
        }
    }
}
