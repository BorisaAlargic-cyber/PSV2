using System;
namespace PSV2.Model
{
    public class Feedback : BaseModel
    {
        public User Patient { get; set; }
        public string Comment { get; set; }
        public bool Published { get; set; }
    }
}
