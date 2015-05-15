using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wasd.Models
{
    public class GroupPost
    {
        public int Id { get; set; }
        public string userName { get; set; }
        public string userID { get; set; }
        public string content { get; set; }
        public string date { get; set; }
        public int groupID { get; set; }
        public string groupName { get; set; }
    }
}