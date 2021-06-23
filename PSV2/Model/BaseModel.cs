using System;
using System.ComponentModel.DataAnnotations;

namespace PSV2.Model
{
   
        public class BaseModel
        {
            [Key]
            public int Id { get; set; }
            public bool Deleted { get; set; }
        }
   
}
