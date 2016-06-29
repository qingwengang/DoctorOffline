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
        private List<OnlineMulu> childrens;
        public List<OnlineMulu> children {
            get { if (childrens == null) { childrens = new List<OnlineMulu>(); } return childrens; }
            set { this.childrens = value; }
        }
    }
}
