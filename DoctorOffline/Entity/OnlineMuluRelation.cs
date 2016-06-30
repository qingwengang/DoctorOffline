using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorOffline.Models
{
    public class OnlineMuluRelation
    {
        public long Id { get; set; }
        public long MuluId { get; set; }
        public string Source { get; set; }
        public string OutMulu { get; set; }
    }
}
