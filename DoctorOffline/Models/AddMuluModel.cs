using System.ComponentModel.DataAnnotations;
namespace DoctorOffline.Models
{
    public class AddMuluModel
    {
        [Required]
        public int Level{get;set;}
        [Required]
        public string Name{get;set;}
    }
}