using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PSV2.Model;
using PSV2.Repository;

namespace PSV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : DefaultController
    {
        [Authorize]
        [Route("/api/users/set-doctor")]
        [HttpPost]
        public async Task<IActionResult> SetChosenDoctor(User doctor)
        {
            try
            {
                using(UnitOfWork unitOfWork = new UnitOfWork(new ModelContext()))
                {
                    User user = unitOfWork.Users.Get(GetCurrentUser().Id);
                    User doc = unitOfWork.Users.Get(doctor.Id);
                    unitOfWork.Users.Update(user);
                    user.ChoosenDoctor = doc;
                    unitOfWork.Complete();

                    return Ok(user);

                }
            }catch(Exception ee)
            {
                return null;
            }

            
        }




        [Authorize]
        [Route("/api/users/unblock/{id}")]
        [HttpPost]
        public async Task<IActionResult> UnBlock(string id)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new ModelContext()))
                {
                    User user = unitOfWork.Users.GetUserWithEmail(id);

                    if (user == null)
                    {
                        return BadRequest();
                    }

                    user.Blocked = false;
                    unitOfWork.Users.Update(user);
                    unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
                return null;
            }


            return Ok();


        }





        [Authorize]
        [Route("/api/users/block/{id}")]
        [HttpPost]
        public async Task<IActionResult> Block(int id)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new ModelContext()))
                {
                    User user = unitOfWork.Users.Get(id);

                    if (user == null)
                    {
                        return BadRequest();
                    }

                    user.Blocked = true;
                    unitOfWork.Users.Update(user);
                    unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
                return null;
            }


            return Ok();
        }



        [Authorize]
        [Route("/api/users/get-all")]
        [HttpGet]
        public PageResponse<User> GetAllUsers([FromQuery(Name = "page")] int page, [FromQuery(Name = "perPage")] int perPage, [FromQuery(Name = "search")] string search)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new ModelContext()))
                {
                    return unitOfWork.Users.GetPage(new Pager(page, perPage, search));
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [Authorize]
        [Route("/api/users/get-doctors")]
        [HttpGet]
        public async Task<IActionResult> GetDoctors()
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new ModelContext()))
                {
                    return Ok(unitOfWork.Users.GetDoctors());
                }
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }


        [Authorize]
        [Route("/api/users/get-current")]
        [HttpGet]
        public async Task<IActionResult> GetCurretUser()
        {
            return Ok(GetCurrentUser());
        }

        [Route("/api/users")]
        [HttpPost]
        public async Task<IActionResult> RegisterUser(User inputData)
        {

            User user = null;

            if (inputData.Email == null || inputData.LastName == null || inputData.FirstName == null || inputData.Password == null)
            {
                return BadRequest();
            }

            user = new User();
            user.Email = inputData.Email;
            user.FirstName = inputData.FirstName;
            user.LastName = inputData.LastName;
            user.Password = inputData.Password;
            user.Role = "PATIENT";
            user.FirstTime = true;
            user.Deleted = false;

            try
            {
                using (var unitOfWork = new UnitOfWork(new ModelContext()))
                {
                    unitOfWork.Users.Add(user);
                    unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
                return BadRequest();
            }

            return Ok(user);
        }
    }
}
