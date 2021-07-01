using System;
namespace PSV2.Model
{
    public class PriorityRequest
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public User Doctor { get; set; }
        public string Priority { get; set; }
    }
}
