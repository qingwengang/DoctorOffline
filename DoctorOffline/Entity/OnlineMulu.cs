using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorOffline.Entity
{
    public class OnlineMulu
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Level{get;set;}
        public long ParentId { get; set; }
    }
}
