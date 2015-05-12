using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wasd.Models
{
    public class UserPost
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }

    }
}