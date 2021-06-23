using System;
namespace PSV2.Model
{
    public class Recepie : BaseModel
    {
        public User Pacient { get; set; }
        public User Doctor { get; set; }
        public Drugs Drug { get; set; }
        public int Quantity { get; set; }
    }
}
