using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSV2.Controllers;
using PSV2.Model;

namespace PSV2_test
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public async Task Block()
        {
            UserController controller = new UserController();

            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] {
                                        new Claim(ClaimTypes.NameIdentifier, "SomeValueHere"),
                                        new Claim(ClaimTypes.Email, "patient@gmail.com"),

                                   }, "TestAuthentication"));

            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = new DefaultHttpContext { User = user };

            User patient = new User();

            patient.Id = 1;
            patient.Blocked = true;

            var result = await controller.Block(patient.Id);

            Assert.IsNotNull(result);


        }

        [TestMethod]
        public async Task UnBlock()
        {
            UserController controller = new UserController();

            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] {
                                        new Claim(ClaimTypes.NameIdentifier, "SomeValueHere"),
                                        new Claim(ClaimTypes.Email, "patient@gmail.com"),

                                   }, "TestAuthentication"));

            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = new DefaultHttpContext { User = user };

            User patient = new User();

            patient.Id = 1;
            patient.Blocked = true;

            var result = await controller.UnBlock(patient.Email);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetAllUsers()
        {
            UserController controller = new UserController();

            PageResponse<User> result = controller.GetAllUsers(0, 30, "");

            Assert.AreEqual(result.Total, 0);
        }

        [TestMethod]
        public async Task GetDoctors()
        {
            UserController controller = new UserController();

            var result = await controller.GetDoctors();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetCurretUser()
        {
            UserController controller = new UserController();

            var user =  new ClaimsPrincipal(new ClaimsIdentity(new Claim[] {
                                        new Claim(ClaimTypes.NameIdentifier, "SomeValueHere"),
                                        new Claim(ClaimTypes.Email, "patient@gmail.com"),

                                   }, "TestAuthentication"));

            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = new DefaultHttpContext { User = user };

            
            Assert.IsNotNull(user);


        }

        [TestMethod]
        public async Task RegisterUser()
        {
            UserController controller = new UserController();

            User user = new User();

            user.Email = "borko@gmail.com";
            user.FirstName = "Borisa";
            user.LastName = "Alargic";
            user.Password = "borko";
            user.Role = "PATIENT";
            user.FirstTime = true;
            user.Deleted = false;

            var result = await controller.RegisterUser(user);

            Assert.IsNotNull(result);
        }
    }
}
