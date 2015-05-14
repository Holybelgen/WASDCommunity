using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Wasd.Models
{
    public class SearchViewModel
    {
        [DisplayName("Search query")]
        [Required]
        public string Query { get; set; }
    }
}