using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExternalPrescriptionService.Data
{
    public class Prescription
    {
        public int Id { get; set; }
        public string Medicine { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Amount { get; set; }
    }
}
