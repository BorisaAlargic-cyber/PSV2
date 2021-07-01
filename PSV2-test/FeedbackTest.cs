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
    public class FeedbackTest
    {
        [TestMethod]
        public async Task Publish()
        {
            FeedbackController controller = new FeedbackController();

            Feedback feedback = new Feedback();

            feedback.Published = true;

            var result = await controller.Publish(feedback.Id);

            Assert.IsNotNull(result);


        }

        [TestMethod]
        public async Task DontPublish()
        {
            FeedbackController controller = new FeedbackController();

            Feedback feedback = new Feedback();

            feedback.Published = false;

            var result = await controller.DontPublish(feedback.Id);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task CreateFeedback()
        {
            FeedbackController controller = new FeedbackController();

            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] {
                                        new Claim(ClaimTypes.NameIdentifier, "SomeValueHere"),
                                        new Claim(ClaimTypes.Email, "patient@gmail.com"),

                                   }, "TestAuthentication"));

            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = new DefaultHttpContext { User = user };

            Feedback feedback = new Feedback();

            User patient = new User();

            patient.Id = 1;

            feedback.Comment = "Superiska";
            feedback.Deleted = false;
            feedback.Patient = patient;
            feedback.Published = false;

            var result = await controller.CreateFeedback(feedback);

            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void  GetAll()
        {
            FeedbackController controller = new FeedbackController();

            PageResponse<Feedback> result =  controller.GetAll(0, 30, "");

            Assert.AreEqual(result.Total, 0);
        }

        [TestMethod]
        public void GetAllPublished()
        {
            FeedbackController controller = new FeedbackController();

            PageResponse<Feedback> result = controller.GetAllPublished(0, 30, "");

            Assert.AreEqual(result.Total, 0);
        }
    }
}
