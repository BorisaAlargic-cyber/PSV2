using System;
namespace PSV2.Model
{
    public class Visit : BaseModel
    {
        public Apointment Apointment { get; set; }

        public String Results { get; set; }

    }
}
