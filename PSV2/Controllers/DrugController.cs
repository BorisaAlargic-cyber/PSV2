using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PSV2.Model;
using PSV2.Repository;

namespace PSV2.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class DrugController : DefaultController
    {
        [Authorize]
        [Route("/api/drugs/get-all")]
        [HttpGet]
        public PageResponse<Drugs> GetAllDrugs([FromQuery(Name = "page")] int page, [FromQuery(Name = "perPage")] int perPage, [FromQuery(Name = "search")] string search)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new ModelContext()))
                {
                    return unitOfWork.Drugs.GetPage(new Pager(page, perPage, search));
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        [Route("/api/recepie/get/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new ModelContext()))
                {
                    Drugs drug;
                    drug = unitOfWork.Drugs.GetDrugById(id);

                }

            }
            catch (Exception e)
            {
                BadRequest();
            }

            return Ok();
        }
        [Route("/api/drugs/delete/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteById(int id)
        {

            try
            {
                using (var unitOfWork = new UnitOfWork(new ModelContext()))
                {
                    Drugs drug;
                    drug = unitOfWork.Drugs.GetDrugById(id);
                    drug.Deleted = true;
                    unitOfWork.Complete();
                }

            }
            catch (Exception e)
            {
                BadRequest();
            }

            return Ok();
        }
        [Route("/api/drugs/add")]
        [HttpPost]
        public async Task<IActionResult> AddDrug(Drugs input)
        {
            Drugs drug = null;

            if (input.Name == null)
            {
                return BadRequest();
            }

            drug = new Drugs();
            drug.Name = input.Name;
            try
            {
                using (var unitOfWork = new UnitOfWork(new ModelContext()))
                {
                    unitOfWork.Drugs.Add(drug);
                    unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
                return BadRequest();
            }
            return Ok(drug);
        }



    }
}
