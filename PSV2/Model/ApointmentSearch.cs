using System;
namespace PSV2.Model
{
    public class ApointmentSearch : BaseModel
    {
        public User Doctor { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}

