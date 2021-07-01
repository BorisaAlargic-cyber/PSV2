using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSV2.Controllers;
using PSV2.Model;

namespace PSV2_test
{
    [TestClass]
    public class RecepieTest
    {
        [TestMethod]
        public async Task GetById()
        {
            RecepieController controller = new RecepieController();

            Recepie recepie = new Recepie();

            var result = await controller.GetById(recepie.Id);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetAllRecepies()
        {
            RecepieController controller = new RecepieController();

            PageResponse<Recepie> result = controller.GetAllRecepies(0, 30, "");

            Assert.AreEqual(result.Total, 0);
        }
    }
}
