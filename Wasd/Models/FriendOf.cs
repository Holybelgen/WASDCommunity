using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Wasd.Models
{
    public class FriendOf
    {
        [Key]
        [Column(Order = 1)]
        //[ForeignKey("ApplicationUser")]
        public String userId { get; set; }

        [Key]
        [Column(Order = 2)]
        //[ForeignKey("ApplicationUser")]
        public String friendId { get; set; }

        public FriendOf()
        {
        }

        public FriendOf(String userId, String friendId)
        {
            // TODO: Complete member initialization
            this.userId = userId;
            this.friendId = friendId;
        }

    }
}