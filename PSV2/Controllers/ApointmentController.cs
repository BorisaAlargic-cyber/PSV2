using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PSV2.Model;
using PSV2.Repository;

namespace PSV2.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class ApointmentController : DefaultController
    {
        [Authorize]
        [Route("/api/apointment/search-apointment-priorty")]
        [HttpPost]
        public List<Apointment> SearchApointmentsWithPriorty(PriorityRequest priority)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new ModelContext()))
                {
                    List<Apointment> apointmentsList = unitOfWork.Apointment.SearchApointmens(priority);

                    return apointmentsList;

                }
            }
            catch (Exception ee)
            {
                return null;
            }
        }




        [Authorize]
        [Route("/api/apointment/pointment-all")]
        [HttpGet]
        public PageResponse<Apointment> GetAll([FromQuery(Name = "page")] int page, [FromQuery(Name = "perPage")] int perPage, [FromQuery(Name = "search")] string search)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new ModelContext()))
                {
                    User current = GetCurrentUser();
                    if(current.FirstTime == true)
                    {
                        List<Apointment> result = unitOfWork.Apointment.FirstTimeApointments(current);


                        return new PageResponse<Apointment>(result, result.Count);
                    }

                    return unitOfWork.Apointment.GetPage(new Pager(page, perPage, search));
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        [Route("/api/apointment/add")]
        [HttpPost]
        public async Task<IActionResult> CreateApointment(Apointment input)
        {
            Apointment apointment = null;

            apointment = new Apointment();
            apointment.Date = input.Date;
            

            try
            {
                using (var unitOfWork = new UnitOfWork(new ModelContext()))
                {
                    apointment.Doctor = unitOfWork.Users.Get(input.Doctor.Id);

                    unitOfWork.Apointment.Add(apointment);
                    unitOfWork.Complete();

                    return Ok(apointment);
                }
            }
            catch (Exception e)
            {
                return BadRequest();
            }
            
        }

        [Route("/api/apointment/leave/{id}")]
        [HttpPut]

        public async Task<IActionResult> leaveApointment(int id)
        {
            Apointment apointment = null;
            try
            {
                using (var unitOfWork = new UnitOfWork(new ModelContext()))
                {
                    apointment = unitOfWork.Apointment.Get(id);
                    apointment.Taken = false;
                    apointment.Patient = null;
                    unitOfWork.Apointment.Update(apointment);
                    unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
                return BadRequest();
            }

            return Ok(apointment);
        }

        [Route("/api/apointment/take/{id}")]
        [HttpPut]
        public async Task<IActionResult> takeApointment(int id)
        {
            Apointment apointment = null;
            User user = GetCurrentUser();
            try
            {
                using (var unitOfWork = new UnitOfWork(new ModelContext()))
                {
                    user.FirstTime = false;
                    apointment = unitOfWork.Apointment.Get(id);
                    apointment.Patient = unitOfWork.Users.Get(user.Id);
                    apointment.Taken = true;
                    unitOfWork.Apointment.Update(apointment);
                    unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
                return BadRequest();
            }

            return Ok(apointment);
        }
    }
}
