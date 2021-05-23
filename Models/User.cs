using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace twitter_clone.Models {
    public class User {
        [Key]
        public int Id { get; set; }
        public string Username;
        public string At;
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Joined;

        public List<User> Following { get; set; }
        public List<User> Followers { get; set; }
    }
}