using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Wasd.Models
{
    public class Group
    {
        public int Id { get; set; }
        [Display(Name="Group Name:")]
        public string groupName { get; set; }
        [Display(Name = "Specify game:")]
        public string gameName { get; set; }
        [Display(Name = "About this group:")]
        public string aboutGroup {get; set; }
    }
}