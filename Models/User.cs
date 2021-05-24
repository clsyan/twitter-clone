using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace twitter_clone.Models {
    public class User {
        public string Username { get; set; }

        public string At { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Joined { get; set; }
        [EmailAddress]
        public string Email { get; set; }

        public List<User> Following { get; set; }
        public List<User> Followers { get; set; }
    }
}