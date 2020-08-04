using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelService
{
    public class User
    {
        [Key]
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
        public string Avatar { get; set; }

        [ForeignKey("UserType")]
        public virtual Role Roles { get; set; }
    }
}
