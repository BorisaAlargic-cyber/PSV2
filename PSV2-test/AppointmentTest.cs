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
    public class AppointmentTest
    {
        [TestMethod]
        public async Task CreateApointment()
        {
            ApointmentController controller = new ApointmentController();
            Apointment apointment = new Apointment();

            User doctor = new User();
           

            doctor.Email = "doctor@gmail.com";
            doctor.FirstName = "Nikola";
            doctor.LastName = "Nikolic";
            doctor.Password = "nidza";
            doctor.Role = "Doctor";
            doctor.Speciality = "Hirurg";

            apointment.Doctor = doctor;
     
            

            var result = await controller.CreateApointment(apointment);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task LeaveAppointment()
        {
            ApointmentController controller = new ApointmentController();

            User patient = new User();

            patient.Email = "patient@gmail.com";
            patient.FirstName = "Petar";
            patient.LastName = "Petrovic";
            patient.Role = "Patient";
            patient.Password = "pero";

            Apointment apointment = new Apointment();

            User doctor = new User();


            doctor.Email = "doctor@gmail.com";
            doctor.FirstName = "Nikola";
            doctor.LastName = "Nikolic";
            doctor.Password = "nidza";
            doctor.Role = "Doctor";
            doctor.Speciality = "Hirurg";

            apointment.Doctor = doctor;
            apointment.Taken = false;
            apointment.Patient = null;

            var result = await controller.leaveApointment(apointment.Id);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task TakeAppointment()
        {
            ApointmentController controller = new ApointmentController();

            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] {
                                        new Claim(ClaimTypes.NameIdentifier, "SomeValueHere"),
                                        new Claim(ClaimTypes.Email, "patient@gmail.com"),
                                        
                                   }, "TestAuthentication"));

            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = new DefaultHttpContext { User = user };

            User doctor = new User();


            doctor.Email = "doctor@gmail.com";
            doctor.FirstName = "Nikola";
            doctor.LastName = "Nikolic";
            doctor.Password = "nidza";
            doctor.Role = "Doctor";
            doctor.Speciality = "Hirurg";

            Apointment apointment = new Apointment();

            User patient = new User();

            patient.Id = 1;

            apointment.Doctor = doctor;
            apointment.Taken = true;
            apointment.Patient = patient;

            var result = await controller.takeApointment(apointment.Id);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetAll()
        {
            ApointmentController controller = new ApointmentController();


            PageResponse<Apointment> result = controller.GetAll(0, 30, "");

            Assert.AreEqual(result.Total, 6);
        }
    }
}
