using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExternalPrescriptionService.Data
{
    public class Database
    {
        private static Database instance;
        private Dictionary<int, Prescription> data;

        public Database()
        {
            data = new Dictionary<int, Prescription>();
        }

        public static Database Instance {
            get
            {
                if (instance == null)
                {
                    instance = new Database();
                }

                return instance;
            }
        }

        public Dictionary<int, Prescription> Data
        {
            get
            {
                return data;
            }
        }
    }
}
