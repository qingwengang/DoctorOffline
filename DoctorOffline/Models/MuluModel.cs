using DoctorOffline.Entity;

using System.Collections.Generic;


namespace DoctorOffline.Models
{
    public class MuluModel
    {
        public string MuluName { get; set; }
        public int Level { get; set; }
        public long ParentId { get; set; }
        public OnlineMulu mulu { get; set; }
        public long MuluId { get; set; }
        private List<MuluModel> childrens;
        public List<MuluModel> children {
            get { if (childrens == null) { childrens = new List<MuluModel>(); } return childrens; }
            set { this.childrens = value; }
        }
        public RelationModel relationModel { get; set; }
    }
    public class RelationModel
    {
        public string ask120Relation { get; set; }
        public string fhRelation { get; set; }
        public string JJRelation { get; set; }
        public string JKRelation { get; set; }
        public string SJRelation { get; set; }
    }
}
