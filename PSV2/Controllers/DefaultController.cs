using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PSV2.Model;
using PSV2.Repository;

namespace PSV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {

        protected User GetCurrentUser()
        {
            string email = HttpContext.User.Claims.FirstOrDefault(u => u.Type == "Email")?.Value;

            User user = null;

            try
            {
                using (var unitOfWork = new UnitOfWork(new ModelContext()))
                {
                    user = unitOfWork.Users.GetUserWithEmail(email);
                }
            }
            catch (Exception e)
            {

            }

            return user;
        }
    }
}
