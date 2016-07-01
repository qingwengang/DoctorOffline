using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorOffline.Models
{
    public class OnlineMuluRelation
    {
        public long Id { get; set; }
        public long OnlineMuluId { get; set; }
        public string Ask120Relation { get; set; }
        public string FHRelation { get; set; }
        public string JJRelation { get; set; }
        public string JKRelation { get; set; }
        public string SJRelation { get; set; }
    }
}
