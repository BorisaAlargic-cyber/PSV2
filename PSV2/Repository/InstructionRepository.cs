using System;
using PSV2.Core;
using PSV2.Model;

namespace PSV2.Repository
{
    public class InstructionRepository : Repository<Instruction>, IInstructionRepository
    {
        public InstructionRepository(ModelContext context) : base(context) { }
    }
}
