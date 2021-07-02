using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExternalPrescriptionService.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ExternalPrescriptionService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainController
    {
        [Route("/prescription/{id}")]
        [HttpGet]
        public Prescription Get(int id)
        {
            return Database.Instance.Data.GetValueOrDefault(id);
        }

        [Route("/prescription")]
        [HttpGet]
        public IEnumerable<Prescription> GetAll(int id)
        {
            return Database.Instance.Data.Values;
        }

        [Route("/prescription")]
        [HttpGet]
        public Prescription Add(Prescription p)
        {
            Database.Instance.Data.Add(p.Id, p);
            return p;
        }
    }
}
