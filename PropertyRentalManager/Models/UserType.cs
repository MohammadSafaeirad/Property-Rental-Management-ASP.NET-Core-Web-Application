using System;
using System.Collections.Generic;

namespace PropertyRentalManager.Models
{
    public partial class UserType
    {
        public UserType()
        {
            Users = new HashSet<User>();
        }

        public int UserTypeId { get; set; }
        public string? UserTypeDescription { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
