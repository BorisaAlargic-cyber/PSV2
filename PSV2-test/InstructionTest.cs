using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSV2.Controllers;
using PSV2.Model;

namespace PSV2_test
{
    [TestClass]
    public class InstructionTest
    {
        [TestMethod]
       public async Task CreateInstruction()
        {
            InstructionController controller = new InstructionController();
            Instruction instruction = new Instruction();
           
            User patient = new User();

            patient.FirstName = "Petar";
            patient.LastName = "Nikolic";
            patient.Email = "peronikic@gmail.com";
            patient.Password = "12345";
            patient.FirstTime = true;

            instruction.Patient = patient;
            instruction.Speciality = "Dermatolog";
            instruction.Taken = false;

            var result = await controller.CreateInstruction(instruction);
            Assert.IsNotNull(result);


        }
    }
}
