using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSV2.Controllers;
using PSV2.Model;

namespace PSV2_test
{
    [TestClass]
    public class DrugTest
    {
        [TestMethod]
        public async Task AddDrug()
        {
            DrugController controller = new DrugController();

            Drugs drugs = new Drugs();

            drugs.Name = "Hemomicin";

            var result = await controller.AddDrug(drugs);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task DeleteById()
        {
            DrugController controller = new DrugController();

            Drugs drugs = new Drugs();

            drugs.Name = "Brufen";
            drugs.Deleted = true;

            var result = await controller.DeleteById(drugs.Id);

            Assert.IsNotNull(result);

            
        }

        [TestMethod]
        public async Task GetById()
        {
            DrugController controller = new DrugController();

            Drugs drugs = new Drugs();

            drugs.Name = "Brufen";

            var result = await controller.GetById(drugs.Id);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetAllDrugs()
        {
            DrugController controller = new DrugController();

            PageResponse<Drugs> result = controller.GetAllDrugs(0,30, "");

            Assert.AreEqual(result.Total, 2);
        }
    }
}
