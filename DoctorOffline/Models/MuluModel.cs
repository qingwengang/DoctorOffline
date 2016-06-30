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
    }
}
