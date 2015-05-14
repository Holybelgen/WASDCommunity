using System.ComponentModel.DataAnnotations;


namespace Wasd.Models
{
    public class Group
    {
        [Key]
        public int Id { get; set; }
        [Display(Name="Group Name:")]
        public string groupName { get; set; }
        [Display(Name = "About this group:")]
        public string aboutGroup {get; set; }
    }
}