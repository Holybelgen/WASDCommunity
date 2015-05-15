using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Wasd.Models;

namespace Wasd.Models
{
    public class UserPost
    {
        public int Id { get; set; }
        public string userName { get; set; }
        public string userID { get; set; }
        [DataType(DataType.MultilineText)]
        public string content { get; set; }
        public string date { get; set; }
    }
}