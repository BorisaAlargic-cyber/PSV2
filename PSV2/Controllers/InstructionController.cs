using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PSV2.Model;
using PSV2.Repository;

namespace PSV2.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class InstructionController : DefaultController
    {
        [Authorize]
        [Route("/api/instructions/create")]
        [HttpPost]
        public async Task<IActionResult> CreateInstruction(Instruction input)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new ModelContext()))
                {
                    User patient = unitOfWork.Users.Get(input.Patient.Id);
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

        [Authorize]
        [Route("/api/instructions/get-all")]
        [HttpGet]
        public PageResponse<Instruction> GetAllInstructions([FromQuery(Name = "page")] int page, [FromQuery(Name = "perPage")] int perPage, [FromQuery(Name = "search")] string search)
        {
            try
            {
                using(UnitOfWork unitOfWork = new UnitOfWork(new ModelContext()))
                {
                    return unitOfWork.Instruction.GetPage(new Pager(page, perPage, search));
                }
            }catch(Exception ee)
            {
                return null;
            }
        }
    }
}
