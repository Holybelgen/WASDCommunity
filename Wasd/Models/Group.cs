using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wasd.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public string GameName { get; set; }
        public string AboutGroup {get; set; }
        public ICollection<Group> Groups { get; set; }
    }
}