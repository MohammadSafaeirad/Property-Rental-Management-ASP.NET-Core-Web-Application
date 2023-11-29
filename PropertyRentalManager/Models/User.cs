using System;
using System.Collections.Generic;

namespace PropertyRentalManager.Models
{
    public partial class User
    {
        public User()
        {
            PropertyManagers = new HashSet<PropertyManager>();
            PropertyOwners = new HashSet<PropertyOwner>();
            Tenants = new HashSet<Tenant>();
        }

        public int UserId { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public int? UserType { get; set; }

        public virtual UserType? UserTypeNavigation { get; set; }
        public virtual ICollection<PropertyManager> PropertyManagers { get; set; }
        public virtual ICollection<PropertyOwner> PropertyOwners { get; set; }
        public virtual ICollection<Tenant> Tenants { get; set; }
    }
}
