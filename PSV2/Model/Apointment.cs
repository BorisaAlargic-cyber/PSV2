using System;
namespace PSV2.Model
{
  
        public class Apointment : BaseModel
        {
            public User Patient { get; set; }
            public DateTime Date { get; set; }
            public User Doctor { get; set; }
            public bool Taken { get; set; }
            public string Comment { get; set; }
        }
}
