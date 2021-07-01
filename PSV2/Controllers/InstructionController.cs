using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PSV2.Model;
using PSV2.Repository;

namespace PSV2.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class InstructionController : DefaultController
    {
        public async Task<IActionResult> CreateInstruction(Instruction input)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new ModelContext()))
                {
                    User patient = unitOfWork.Users.Get(input.Id);
                    Instruction instruction = new Instruction();

                    instruction.Patient = patient;
                    instruction.Speciality = input.Speciality;
                    instruction.Taken = false;

                    unitOfWork.Instruction.Add(instruction);
                    unitOfWork.Complete();

                    return Ok(instruction);
                }
            }
            catch (Exception ee)
            {
                return null;
            }
        }
    }
}
