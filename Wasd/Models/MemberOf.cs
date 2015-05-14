using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Wasd.Models
{
    public class MemberOf
    {
        [Key]
        [Column(Order = 1)]
        //[ForeignKey("ApplicationUser")]
        public String userId { get; set; }

        [Key]
        [Column(Order = 2)]
        //[ForeignKey("ApplicationUser")]
        public String groupId { get; set; }

        public MemberOf()
        {
        }

        public MemberOf(String userId, String groupId)
        {
            // TODO: Complete member initialization
            this.userId = userId;
            this.groupId = groupId;
        }
    }
}