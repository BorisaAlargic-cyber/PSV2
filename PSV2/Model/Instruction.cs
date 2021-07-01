using System;
namespace PSV2.Model
{
    public class Instruction : BaseModel
    {
        public User Patient { get; set; }
        public string Speciality { get; set; }
        public bool Taken { get; set; }
        
    }
}
