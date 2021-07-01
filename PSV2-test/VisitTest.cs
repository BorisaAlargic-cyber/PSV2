using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSV2.Controllers;
using PSV2.Model;

namespace PSV2_test
{
    [TestClass]
    public class VisitTest
    {
        [TestMethod]
        public void GetAllVisits()
        {
            VisitController controller = new VisitController();

            PageResponse<Visit> result = controller.GetAllVisits(0, 30, "");

            Assert.AreEqual(result.Total, 0);

        }
    }
}
